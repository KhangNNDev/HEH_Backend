using Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Core;


namespace HealingAndHealthCareSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserExerciseController : ControllerBase
    {
        private readonly IUserExerciseService _UserExerciseservice;
        public UserExerciseController(IUserExerciseService UserExerciseService)
        {
            _UserExerciseservice = UserExerciseService;
        }
        //[Authorize(AuthenticationSchemes = "Bearer")]

        [HttpPost("Create")]
        public IActionResult Post([FromBody] UserExerciseCreateModel model)
        {
            var result = _UserExerciseservice.Add(model);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }

        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public IActionResult Get()
        {
            var result = _UserExerciseservice.GetAll();
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = _UserExerciseservice.Get(id);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(Guid id)
        {
            var result = _UserExerciseservice.Delete(id);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpPut]
        public IActionResult Update(UserExerciseUpdateModel model)
        {
            var result = _UserExerciseservice.Update(model);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }

    }
}
