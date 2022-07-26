using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using UserRegistrationAPI.Models;
using UserRegistrationAPI.Repositories.IRepository;

namespace UserRegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModificationController_DataSheetData : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DataLoadingController> _logger;
        private readonly IMapper _mapper;

        public ModificationController_DataSheetData(IUnitOfWork unitOfWork,
                                ILogger<DataLoadingController> logger,
                                IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPut("FirstNameMod")]
        public async Task<IActionResult> UpdateDataSheetDTO_FirstName(string id, [FromBody] UpdateDataSheetDTO_FirstName userDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateDataSheetDTO_FirstName)}");
                return BadRequest(ModelState);
            }

            var user = await _unitOfWork.Users.Get(q => q.Id == id);
            if (user == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateDataSheetDTO_FirstName)}");
                return BadRequest("Submitted data is invalid");
            }

            _mapper.Map(userDTO, user);
            _unitOfWork.Users.Update(user);
            await _unitOfWork.Save();

            return NoContent();
        }

        [HttpPut("LastNameMod")]
        public async Task<IActionResult> UpdateDataSheetDTO_LastName(string id, [FromBody] UpdateDataSheetDTO_LastName userDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateDataSheetDTO_LastName)}");
                return BadRequest(ModelState);
            }

            var user = await _unitOfWork.Users.Get(q => q.Id == id);
            if (user == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateDataSheetDTO_LastName)}");
                return BadRequest("Submitted data is invalid");
            }

            _mapper.Map(userDTO, user);
            _unitOfWork.Users.Update(user);
            await _unitOfWork.Save();

            return NoContent();
        }

        [HttpPut("PersonalNumberMod")]
        public async Task<IActionResult> UpdateDataSheetDTO_PersonalNumber(string id, [FromBody] UpdateDataSheetDTO_PersonalNumber userDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateDataSheetDTO_PersonalNumber)}");
                return BadRequest(ModelState);
            }

            var user = await _unitOfWork.Users.Get(q => q.Id == id);
            if (user == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateDataSheetDTO_PersonalNumber)}");
                return BadRequest("Submitted data is invalid");
            }

            _mapper.Map(userDTO, user);
            _unitOfWork.Users.Update(user);
            await _unitOfWork.Save();

            return NoContent();
        }

        [HttpPut("EmailMod")]
        public async Task<IActionResult> UpdateDataSheetDTO_Email(string id, [FromBody] UpdateDataSheetDTO_Email userDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateDataSheetDTO_Email)}");
                return BadRequest(ModelState);
            }

            var user = await _unitOfWork.Users.Get(q => q.Id == id);
            if (user == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateDataSheetDTO_Email)}");
                return BadRequest("Submitted data is invalid");
            }

            _mapper.Map(userDTO, user);
            _unitOfWork.Users.Update(user);
            await _unitOfWork.Save();

            return NoContent();
        }
    }
}

//CreateMap<DataSheet, UpdateDataSheetDTO_FirstName>().ReverseMap();
//CreateMap<DataSheet, UpdateDataSheetDTO_LastName>().ReverseMap();
//CreateMap<DataSheet, UpdateDataSheetDTO_PersonalNumber>().ReverseMap();
//CreateMap<DataSheet, UpdateDataSheetDTO_Email>().ReverseMap();