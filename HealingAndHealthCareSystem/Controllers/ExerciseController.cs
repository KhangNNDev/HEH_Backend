using Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Core;

namespace HealingAndHealthCareSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService _exerciseservice;
        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseservice = exerciseService;
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Post([FromBody] ExerciseCreateModel model)
        {
            var result = _exerciseservice.Add(model);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        //[Authorize(Roles = "Admin")]

        [HttpGet]
        public IActionResult Get()
        {
            var result = _exerciseservice.GetAll();
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = _exerciseservice.Get(id);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(Guid id)
        {
            var result = _exerciseservice.Delete(id);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpPut]
        public IActionResult Update(ExerciseUpdateModel model)
        {
            var result = _exerciseservice.Update(model);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpGet("[action]/{id}")]
        public IActionResult GetByCategoryId(Guid id)
        {
            var result = _exerciseservice.GetByCategoryID(id);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
    }
}
