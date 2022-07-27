
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


using UserRegistrationAPI.Models;
using UserRegistrationAPI.Repositories.IRepository;
using UserRegistrationAPI.Services;

namespace UserRegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthManager _authManager;

        public AccountController(UserManager<User> userManager,
                                 ILogger<AccountController> logger,
                                 IMapper mapper,
                                 IUnitOfWork unitOfWork,
                                 IAuthManager authManager)
        {
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _authManager = authManager;
        }

        [HttpPost]
        [Route("register")]
        #region Status.Codes
        //[ProducesResponseType(StatusCodes.Status202Accepted)]                     // <- these attributes gives more info for dev (in swagger)
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        #endregion
        public async Task<IActionResult> Register([FromBody] CreateUserDTO userDto)
        {
            _logger.LogInformation($"Registration Attempt for {userDto.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = _mapper.Map<User>(userDto);

                user.UserName = userDto.Email;
                //user.DataSheetId = Guid.Parse(user.ConcurrencyStamp);


                var result = await _userManager.CreateAsync(user, userDto.Password);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }

                await _userManager.AddToRolesAsync(user, new List<string>() { "User" });
                return Accepted();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something Went Wrong in the {nameof(Register)}");
                return Problem($"Something Went Wrong in the {nameof(Register)}", statusCode: 500); // <- Different way to do this
            }
        }
        [HttpPost]
        [Route("FillDataSheet")]
        public async Task<IActionResult> FillDataSheet([FromBody] CreateDataSheetDTO dataSheetDTO, string userId)
        {
            _logger.LogInformation($"Registration Attempt for {dataSheetDTO}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = await _unitOfWork.Users.Get(q => q.Id == userId, include: x => x.Include(x => x.DataSheet));

                var dataSheet = _mapper.Map<DataSheet>(dataSheetDTO);

                user.DataSheet = dataSheet;
                _unitOfWork.Users.Update(user);

                await _unitOfWork.DataSheets.Insert(dataSheet);
                await _unitOfWork.Save();

                return Accepted();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something Went Wrong in the {nameof(Register)}");
                return Problem($"Something Went Wrong in the {nameof(Register)}", statusCode: 500); // <- Different way to do this
            }
        }

        [HttpPost]
        [Route("FillAdress")]
        public async Task<IActionResult> FillAdress([FromBody] CreateAddressDTO adressDTO, string userId)
        {
            _logger.LogInformation($"Registration Attempt for {adressDTO}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = await _unitOfWork.Users.Get(q => q.Id == userId, include: x => x.Include(y => y.DataSheet));
                var dataSheet = await _unitOfWork.DataSheets.Get(q => q.Id == user.DataSheetId, include: x => x.Include(y => y.Address));

                var adress = _mapper.Map<Address>(adressDTO);

                dataSheet.Address = adress;
                _unitOfWork.DataSheets.Update(dataSheet);

                _ = _unitOfWork.Addresses.Insert(dataSheet.Address);

                await _unitOfWork.Save();

                return Accepted();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something Went Wrong in the {nameof(Register)}");
                return Problem($"Something Went Wrong in the {nameof(Register)}", statusCode: 500); // <- Different way to do this
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO userDTO)
        {
            _logger.LogInformation($"Login Attempt for {userDTO.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (!await _authManager.ValidateUser(userDTO))
                {
                    return Unauthorized();
                }

                return Accepted(new { Token = await _authManager.CreateToken() });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(Login)}");
                return Problem($"Something Went Wrong in the {nameof(Login)}", statusCode: 500); // <- Different way to do this
            }
        }
    }
}
