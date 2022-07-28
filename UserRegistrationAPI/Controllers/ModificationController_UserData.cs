using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using UserRegistrationAPI.Core.DTOs;
using UserRegistrationAPI.Core.Repositories.IRepository;

namespace UserRegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModificationController_UserData : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ModificationController_UserData> _logger;
        private readonly IMapper _mapper;

        public ModificationController_UserData(IUnitOfWork unitOfWork,
                                ILogger<ModificationController_UserData> logger,
                                IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPut("usernameMod")]
        public async Task<IActionResult> UpdateUser_Username(string id, [FromBody] UpdateUserDTO_Username dto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateUser_Username)}");
                return BadRequest(ModelState);
            }

            var user = await _unitOfWork.Users.Get(q => q.Id == id);
            if (user == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateUser_Username)}");
                return BadRequest("Submitted data is invalid");
            }

            _mapper.Map(dto, user);
            _unitOfWork.Users.Update(user);
            await _unitOfWork.Save();

            return NoContent();
        }

        [Authorize]
        [HttpPut("passwordMod")]
        public async Task<IActionResult> UpdateUser_Password(string id, [FromBody] UpdateUserDTO_Password dto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateUser_Password)}");
                return BadRequest(ModelState);
            }

            var user = await _unitOfWork.Users.Get(q => q.Id == id);
            if (user == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateUser_Password)}");
                return BadRequest("Submitted data is invalid");
            }

            _mapper.Map(dto, user);
            _unitOfWork.Users.Update(user);
            await _unitOfWork.Save();

            return NoContent();
        }
    }
}