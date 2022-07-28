using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    #region Status.Codes
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    #endregion
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
        [HttpPut("firstNameMod")]
        #region Status.Codes
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        #endregion
        public async Task<IActionResult> UpdateDataSheetDTO_FirstName(string id, [FromBody] UpdateDataSheetDTO_FirstName dto)
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

            user.DataSheet.FirstName = dto.FirstName;

            _unitOfWork.DataSheets.Update(user.DataSheet);
            await _unitOfWork.Save();

            return NoContent();
        }

        [Authorize]
        [HttpPut("lastNameMod")]
        #region Status.Codes
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        #endregion
        public async Task<IActionResult> UpdateDataSheetDTO_LastName(string id, [FromBody] UpdateDataSheetDTO_LastName dto)
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

            user.DataSheet.LastName = dto.LastName;

            _unitOfWork.DataSheets.Update(user.DataSheet);
            await _unitOfWork.Save();

            return NoContent();
        }

        [Authorize]
        [HttpPut("identificationNumberMod")]
        #region Status.Codes
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        #endregion
        public async Task<IActionResult> UpdateDataSheetDTO_IdentificationNumber(string id, [FromBody] UpdateDataSheetDTO_IdentificationNumber dto)
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

            user.DataSheet.IdentificationNumber = dto.IdentificationNumber;

            _unitOfWork.DataSheets.Update(user.DataSheet);
            await _unitOfWork.Save();

            return NoContent();
        }

        [Authorize]
        [HttpPut("pictureDatamod")]
        public async Task<IActionResult> AddPicture(string id, [FromForm] ImageUploadRequest imageRequest)
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

            var imageBytesSetSize = ImageDataParser.ImageDataToArray_Helper(imageRequest);

            user.DataSheet.ImageData = imageBytesSetSize;

            _unitOfWork.DataSheets.Update(user.DataSheet);
            await _unitOfWork.Save();

            return NoContent();
        }
    }
}