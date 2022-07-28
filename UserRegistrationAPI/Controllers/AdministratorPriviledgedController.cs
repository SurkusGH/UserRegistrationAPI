using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserRegistrationAPI.Core.DTOs;
using UserRegistrationAPI.Core.Repositories.IRepository;

namespace UserRegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    #region Status.Codes
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    #endregion
    public class AdministratorPriviledgedController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AdministratorPriviledgedController> _logger;
        private readonly IMapper _mapper;

        public AdministratorPriviledgedController(IUnitOfWork unitOfWork,
                                                  ILogger<AdministratorPriviledgedController> logger,
                                                  IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        #region Status.Codes
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        #endregion
        [Authorize(Roles = "Administrator")]
        [HttpGet("adminPriviledged_userData")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _unitOfWork.Users.GetAll(include: q => q.Include(x => x.DataSheet).ThenInclude(x => x.Address));

                var result = _mapper.Map<List<UserDTO>>(users);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"(!) Something Went Wrong in the {nameof(GetUsers)}");
                return StatusCode(500, "(!) Internal Server Error. Please Try Again Later.");
            }
        }
        [Authorize(Roles = "Administrator")]
        [HttpDelete("deleteUser")]
        #region Status.Codes
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        #endregion
        public async Task<IActionResult> DeleteUser(string id)
        {
            try
            {
                var user = await _unitOfWork.Users.Get(h => h.Id == id, include: q => q.Include(x => x.DataSheet)
                                                                                       .ThenInclude(x => x.Address));
                if (user == null)
                {
                    _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteUser)}");
                    return BadRequest("Submited data is invalid");
                }

                await _unitOfWork.Users.Delete(id);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"(!) Something Went Wrong in the {nameof(DeleteUser)}");
                return StatusCode(500, "(!) Internal Server Error. Please Try Again Later.");
            }
        }
    }
}