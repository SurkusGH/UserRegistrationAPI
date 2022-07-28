using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;
using UserRegistrationAPI.Core.DTOs;
using UserRegistrationAPI.Core.Helpers;
using UserRegistrationAPI.Core.Repositories.IRepository;
using UserRegistrationAPI.Core.Services;
using UserRegistrationAPI.Data.Configurations.Image;

namespace UserRegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModificationController_DataSheetData : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ModificationController_DataSheetData> _logger;
        private readonly IMapper _mapper;
        private readonly IImageService _service;

        public ModificationController_DataSheetData(IUnitOfWork unitOfWork,
                                ILogger<ModificationController_DataSheetData> logger,
                                IMapper mapper,
                                IImageService imageService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _service = imageService;
        }

        [Authorize]
        [HttpPut("FirstNameMod")]
        public async Task<IActionResult> UpdateDataSheetDTO_FirstName(string id, [FromBody] UpdateDataSheetDTO_FirstName DTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateDataSheetDTO_FirstName)}");
                return BadRequest(ModelState);
            }

            var user = await _unitOfWork.Users.Get(x => x.Id == id, include: y => y.Include(j => j.DataSheet));
            if (user == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateDataSheetDTO_FirstName)}");
                return BadRequest("Submitted data is invalid");
            }

            user.DataSheet.FirstName = DTO.FirstName;

            _unitOfWork.DataSheets.Update(user.DataSheet);
            await _unitOfWork.Save();

            return NoContent();
        }

        [Authorize]
        [HttpPut("LastNameMod")]
        public async Task<IActionResult> UpdateDataSheetDTO_LastName(string id, [FromBody] UpdateDataSheetDTO_LastName DTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateDataSheetDTO_LastName)}");
                return BadRequest(ModelState);
            }

            var user = await _unitOfWork.Users.Get(x => x.Id == id, include: y => y.Include(j => j.DataSheet));
            if (user == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateDataSheetDTO_LastName)}");
                return BadRequest("Submitted data is invalid");
            }

            user.DataSheet.LastName = DTO.LastName;

            _unitOfWork.DataSheets.Update(user.DataSheet);
            await _unitOfWork.Save();

            return NoContent();
        }

        [Authorize]
        [HttpPut("IdentificationNumberMod")]
        public async Task<IActionResult> UpdateDataSheetDTO_IdentificationNumber(string id, [FromBody] UpdateDataSheetDTO_IdentificationNumber DTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateDataSheetDTO_IdentificationNumber)}");
                return BadRequest(ModelState);
            }

            var user = await _unitOfWork.Users.Get(x => x.Id == id, include: y => y.Include(j => j.DataSheet));
            if (user == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateDataSheetDTO_IdentificationNumber)}");
                return BadRequest("Submitted data is invalid");
            }

            user.DataSheet.IdentificationNumber = DTO.IdentificationNumber;

            _unitOfWork.DataSheets.Update(user.DataSheet);
            await _unitOfWork.Save();

            return NoContent();
        }
    }
}