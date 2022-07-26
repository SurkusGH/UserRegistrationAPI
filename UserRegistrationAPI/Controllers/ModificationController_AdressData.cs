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
    public class ModificationController_AdressData : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DataLoadingController> _logger;
        private readonly IMapper _mapper;

        public ModificationController_AdressData(IUnitOfWork unitOfWork,
                                ILogger<DataLoadingController> logger,
                                IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPut("CityMod")]
        public async Task<IActionResult> UpdateAddressDTO_City(string id, [FromBody] UpdateAddressDTO_City userDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateAddressDTO_City)}");
                return BadRequest(ModelState);
            }

            var user = await _unitOfWork.Users.Get(q => q.Id == id);
            if (user == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateAddressDTO_City)}");
                return BadRequest("Submitted data is invalid");
            }

            _mapper.Map(userDTO, user);
            _unitOfWork.Users.Update(user);
            await _unitOfWork.Save();

            return NoContent();
        }

        [HttpPut("StreetMod")]
        public async Task<IActionResult> UpdateAddressDTO_Street(string id, [FromBody] UpdateAddressDTO_Street userDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateAddressDTO_Street)}");
                return BadRequest(ModelState);
            }

            var user = await _unitOfWork.Users.Get(q => q.Id == id);
            if (user == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateAddressDTO_Street)}");
                return BadRequest("Submitted data is invalid");
            }

            _mapper.Map(userDTO, user);
            _unitOfWork.Users.Update(user);
            await _unitOfWork.Save();

            return NoContent();
        }

        [HttpPut("HouseMod")]
        public async Task<IActionResult> UpdateAddressDTO_House(string id, [FromBody] UpdateAddressDTO_City userDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateAddressDTO_House)}");
                return BadRequest(ModelState);
            }

            var user = await _unitOfWork.Users.Get(q => q.Id == id);
            if (user == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateAddressDTO_House)}");
                return BadRequest("Submitted data is invalid");
            }

            _mapper.Map(userDTO, user);
            _unitOfWork.Users.Update(user);
            await _unitOfWork.Save();

            return NoContent();
        }

        [HttpPut("ApartamentMod")]
        public async Task<IActionResult> UpdateAddressDTO_Apartament(string id, [FromBody] UpdateAddressDTO_Apartament userDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateAddressDTO_Apartament)}");
                return BadRequest(ModelState);
            }

            var user = await _unitOfWork.Users.Get(q => q.Id == id);
            if (user == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateAddressDTO_Apartament)}");
                return BadRequest("Submitted data is invalid");
            }

            _mapper.Map(userDTO, user);
            _unitOfWork.Users.Update(user);
            await _unitOfWork.Save();

            return NoContent();
        }

    }
}

