using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using net17_ImageThumbnail.Models;
using System;
using System.IO;
using System.Threading.Tasks;
using UserRegistrationAPI.Data.Image;
using UserRegistrationAPI.Models;
using UserRegistrationAPI.Repositories.IRepository;
using UserRegistrationAPI.Services;

namespace UserRegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModificationController_DataSheetData : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DataLoadingController> _logger;
        private readonly IMapper _mapper;
        private readonly IImageService _service;

        public ModificationController_DataSheetData(IUnitOfWork unitOfWork,
                                ILogger<DataLoadingController> logger,
                                IMapper mapper,
                                IImageService imageService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _service = imageService;
        }

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

        [HttpPost("AddPicture")]
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

            using var memoryStream = new MemoryStream();
            imageRequest.Image.CopyTo(memoryStream);
            var imageBytes = memoryStream.ToArray();

            var imageBytesSetSize = AdjustImage.ResizeImage(imageBytes);

            user.DataSheet.ImageData = imageBytesSetSize;

            _unitOfWork.DataSheets.Update(user.DataSheet);
            await _unitOfWork.Save();

            return NoContent();
        }
    }
}