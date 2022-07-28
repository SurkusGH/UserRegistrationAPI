
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserRegistrationAPI.Core.DTOs;
using UserRegistrationAPI.Core.Helpers;
using UserRegistrationAPI.Core.Repositories.IRepository;
using UserRegistrationAPI.Core.Services;
using UserRegistrationAPI.Data.Data;

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
        [ProducesResponseType(StatusCodes.Status202Accepted)]               
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        #endregion
        public async Task<IActionResult> Register([FromBody] CreateUserDTO dto)
        {
            _logger.LogInformation($"Registration Attempt for {dto.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = _mapper.Map<User>(dto);

                user.UserName = dto.Email;
                //user.DataSheetId = Guid.Parse(user.ConcurrencyStamp);


                var result = await _userManager.CreateAsync(user, dto.Password);

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
        [Route("login")]
        #region Status.Codes
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        #endregion
        public async Task<IActionResult> Login([FromBody] LoginUserDTO dto)
        {
            _logger.LogInformation($"Login Attempt for {dto.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (!await _authManager.ValidateUser(dto))
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

        [Authorize]
        [HttpPost]
        [Route("FillAllUserData")]
        #region Status.Codes
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        #endregion
        public async Task<IActionResult> FillAllUserData([FromForm] CreateDataSheetDTO dto, string userId)
        {
            _logger.LogInformation($"Registration Attempt for {dto}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = await _unitOfWork.Users.Get(q => q.Id == userId, include: x => x.Include(y => y.DataSheet)
                                                                                           .ThenInclude(f => f.Address));

                if (user.DataSheet != null)
                {
                    _logger.LogError($"Invalid UPDATE attempt CAUSE DataSheet is Filled, TRY updating by field {nameof(CreateDataSheetDTO)}");
                    return BadRequest("Invalid UPDATE attempt CAUSE DataSheet is Filled, TRY updating by field");
                }

                user.DataSheet = _mapper.Map<DataSheet>(dto);
                user.DataSheet.ImageData = ImageDataParser.ImageDataToArray_Helper(dto.ImageUpload);

                user.DataSheet.Address = _mapper.Map<Address>(dto.Address);

                await _unitOfWork.DataSheets.Insert(user.DataSheet);
                await _unitOfWork.Addresses.Insert(user.DataSheet.Address);

                _unitOfWork.Users.Update(user);

                await _unitOfWork.Save();

                return Accepted();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(FillAllUserData)}");
                return Problem($"(!) Internal Server Error. Please Try Again Later. {nameof(FillAllUserData)}", statusCode: 500);
            }
        }

        [Authorize]
        [HttpGet("GetUserById")]
        #region Status.Codes
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        #endregion
        public async Task<IActionResult> GetUserById(string userId)
        {
            try
            {
                var user = await _unitOfWork.Users.Get(q => q.Id == userId, include: x => x.Include(x => x.DataSheet).ThenInclude(f => f.Address));
                var result = _mapper.Map<UserDTOwithoutId>(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"(!) Something Went Wrong in the {nameof(GetUserById)}");
                return StatusCode(500, "(!) Internal Server Error. Please Try Again Later.");
            }
        }
    }
}
