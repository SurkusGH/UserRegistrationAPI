using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using UserRegistrationAPI.Core.DTOs;
using UserRegistrationAPI.Core.Repositories.IRepository;

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
        public async Task<IActionResult> UpdateAddressDTO_City(string id, [FromBody] UpdateAddressDTO_City dto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateAddressDTO_City)}");
                return BadRequest(ModelState);
            }

            var user = await _unitOfWork.Users.Get(x => x.Id == id, include: y => y.Include(j => j.DataSheet).ThenInclude(x => x.Address));
            if (user == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateAddressDTO_City)}");
                return BadRequest("Submitted data is invalid");
            }

            user.DataSheet.Address.City = dto.City;

            _unitOfWork.Addresses.Update(user.DataSheet.Address);
            await _unitOfWork.Save();


            return NoContent();
        }

        [HttpPut("StreetMod")]
        public async Task<IActionResult> UpdateAddressDTO_Street(string id, [FromBody] UpdateAddressDTO_Street dto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateAddressDTO_Street)}");
                return BadRequest(ModelState);
            }

            var user = await _unitOfWork.Users.Get(x => x.Id == id, include: y => y.Include(j => j.DataSheet).ThenInclude(x => x.Address));
            if (user == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateAddressDTO_City)}");
                return BadRequest("Submitted data is invalid");
            }

            user.DataSheet.Address.Street = dto.Street;

            _unitOfWork.Addresses.Update(user.DataSheet.Address);
            await _unitOfWork.Save();


            return NoContent();
        }

        [HttpPut("HouseMod")]
        public async Task<IActionResult> UpdateAddressDTO_House(string id, [FromBody] UpdateAddressDTO_House dto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateAddressDTO_House)}");
                return BadRequest(ModelState);
            }

            var user = await _unitOfWork.Users.Get(x => x.Id == id, include: y => y.Include(j => j.DataSheet).ThenInclude(x => x.Address));
            if (user == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateAddressDTO_City)}");
                return BadRequest("Submitted data is invalid");
            }

            user.DataSheet.Address.House = dto.House;

            _unitOfWork.Addresses.Update(user.DataSheet.Address);
            await _unitOfWork.Save();


            return NoContent();
        }

        [HttpPut("ApartamentMod")]
        public async Task<IActionResult> UpdateAddressDTO_Apartament(string id, [FromBody] UpdateAddressDTO_Apartament dto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateAddressDTO_Apartament)}");
                return BadRequest(ModelState);
            }

            var user = await _unitOfWork.Users.Get(x => x.Id == id, include: y => y.Include(j => j.DataSheet).ThenInclude(x => x.Address));
            if (user == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateAddressDTO_City)}");
                return BadRequest("Submitted data is invalid");
            }

            user.DataSheet.Address.Apartament = dto.Apartament;

            _unitOfWork.Addresses.Update(user.DataSheet.Address);
            await _unitOfWork.Save();


            return NoContent();
        }

    }
}

