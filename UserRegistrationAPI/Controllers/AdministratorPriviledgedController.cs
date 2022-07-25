using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserRegistrationAPI.Models;
using UserRegistrationAPI.Repositories.IRepository;

namespace UserRegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorPriviledgedController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DataLoadingController> _logger;
        private readonly IMapper _mapper;

        public AdministratorPriviledgedController(IUnitOfWork unitOfWork,
                           ILogger<DataLoadingController> logger,
                           IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("AdminPriviledged_AllUserData")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _unitOfWork.Users.GetAll(include: q => q.Include(x => x.DataSheet));
                var result = _mapper.Map<List<UserDTO>>(users);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"(!) Something Went Wrong in the {nameof(GetUsers)}");
                return StatusCode(500, "(!) Internal Server Error. Please Try Again Later.");
            }
        }

        [HttpGet("GetUserById")]
        #region Status.Codes
        [ProducesResponseType(StatusCodes.Status200OK)]                     // <- these attributes gives more info for dev (in swagger)
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        #endregion
        public async Task<IActionResult> GetUserById(Guid id)
        {
            try
            {
                var user = await _unitOfWork.Users.Get(q => q.Id == id, include: q => q.Include(x => x.DataSheet));
                var result = _mapper.Map<UserDTO>(user);
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
