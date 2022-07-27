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
    //[Route("api/[controller]")]
    //[ApiController]
    //public class ModificationController_UserData : ControllerBase
    //{
    //    private readonly IUnitOfWork _unitOfWork;
    //    private readonly ILogger<DataLoadingController> _logger;
    //    private readonly IMapper _mapper;

    //    public ModificationController_UserData(IUnitOfWork unitOfWork,
    //                            ILogger<DataLoadingController> logger,
    //                            IMapper mapper)
    //    {
    //        _unitOfWork = unitOfWork;
    //        _logger = logger;
    //        _mapper = mapper;
    //    }


    //    [HttpPut("UsernameMod")]
    //    public async Task<IActionResult> UpdateUser_Username(string id, [FromBody] UpdateUserDTO_Username userDTO)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateUser_Username)}");
    //            return BadRequest(ModelState);
    //        }

    //        var user = await _unitOfWork.Users.Get(q => q.Id == id);
    //        if (user == null)
    //        {
    //            _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateUser_Username)}");
    //            return BadRequest("Submitted data is invalid");
    //        }

    //        _mapper.Map(userDTO, user);
    //        _unitOfWork.Users.Update(user);
    //        await _unitOfWork.Save();

    //        return NoContent();
    //    }

    //    [HttpPut("PasswordMod")]
    //    public async Task<IActionResult> UpdateUser_Password(string id, [FromBody] UpdateUserDTO_Password userDTO)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateUser_Password)}");
    //            return BadRequest(ModelState);
    //        }

    //        var user = await _unitOfWork.Users.Get(q => q.Id == id);
    //        if (user == null)
    //        {
    //            _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateUser_Password)}");
    //            return BadRequest("Submitted data is invalid");
    //        }

    //        _mapper.Map(userDTO, user);
    //        _unitOfWork.Users.Update(user);
    //        await _unitOfWork.Save();

    //        return NoContent();
    //    }
    //}
}