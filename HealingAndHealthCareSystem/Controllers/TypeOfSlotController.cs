using Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Core;

namespace HealingAndHealthCareSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOfSlotController : ControllerBase
    {
        private readonly ITypeOfSlotService _typeOfSlotservice;
        public TypeOfSlotController(ITypeOfSlotService typeOfSlotservice)
        {
            _typeOfSlotservice = typeOfSlotservice;
        }
        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("Create")]
        public IActionResult Post([FromBody] TypeOfSlotCreateModel model)
        {
            var result = _typeOfSlotservice.Add(model);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }

        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public IActionResult Get()
        {
            var result = _typeOfSlotservice.GetAll();
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = _typeOfSlotservice.Get(id);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(Guid id)
        {
            var result = _typeOfSlotservice.Delete(id);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpPut]
        public IActionResult Update(TypeOfSlotUpdateModel model)
        {
            var result = _typeOfSlotservice.Update(model);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpGet("[action]")]
        public IActionResult GetByTypeName(string typeName)
        {
            var result = _typeOfSlotservice.GetByTypeName(typeName);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
    }
}
