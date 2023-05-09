using Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Core;

namespace HealingAndHealthCareSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubProfileController : ControllerBase
    {
        private readonly ISubProfileService _subProfileservice;
        public SubProfileController(ISubProfileService subProfileservice)
        {
            _subProfileservice = subProfileservice;

        }
        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("Create")]
        public IActionResult Post([FromBody] SubProfileCreateModel model)
        {
            var result = _subProfileservice.Add(model);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }

        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public IActionResult Get()
        {
            var result = _subProfileservice.GetAll();
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = _subProfileservice.Get(id);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(Guid id)
        {
            var result = _subProfileservice.Delete(id);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpPut]
        public IActionResult Update(SubProfileUpdateModel model)
        {
            var result = _subProfileservice.Update(model);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpGet("[action]/{userId}")]
        public IActionResult GetByUserId(Guid userId)
        {
            var result = _subProfileservice.GetByUserID(userId);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpGet("[action]")]
        public IActionResult GetByUserIdAndSlotID(Guid userId, Guid slotID)
        {
            var result = _subProfileservice.GetByUserIDAndSlotID(userId,slotID);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpGet("[action]")]
        public IActionResult GetBySubNameAndUserID(String subName, Guid userID)
        {
            var result = _subProfileservice.GetBySubNameAndUserID(subName,userID);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
    }
}
