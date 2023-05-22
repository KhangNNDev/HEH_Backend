using Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Core;


namespace HealingAndHealthCareSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteExerciseController : ControllerBase
    {
        private readonly IFavoriteExerciseService _FavoriteExerciseservice;
        public FavoriteExerciseController(IFavoriteExerciseService FavoriteExerciseService)
        {
            _FavoriteExerciseservice = FavoriteExerciseService;
        }
        //[Authorize(AuthenticationSchemes = "Bearer")]

        [HttpPost("Create")]
        public IActionResult Post([FromBody] FavoriteExerciseCreateModel model)
        {
            var result = _FavoriteExerciseservice.Add(model);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }

        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public IActionResult Get()
        {
            var result = _FavoriteExerciseservice.GetAll();
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = _FavoriteExerciseservice.GetByUserIDAndExerciseID(id);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpDelete("[Action]")]
        public IActionResult DeleteByExerciseDetailIDAndUserID(Guid detailID, Guid userID)
        {
            var result = _FavoriteExerciseservice.DeleteByExerciseDetailIDAndUserID(detailID,userID);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpPut]
        public IActionResult Update(FavoriteExerciseUpdateModel model)
        {
            var result = _FavoriteExerciseservice.Update(model);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }

    }
}
