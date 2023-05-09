using Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Core;

namespace HealingAndHealthCareSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhysiotherapistController : ControllerBase
    {
        private readonly IPhysiotherapistService _physiotherapistservice;
        private readonly IPhysiotherapistService _physiotherapistservice1;
        public PhysiotherapistController(IPhysiotherapistService physiotherapistService, IPhysiotherapistService physiotherapistService1)
        {
            _physiotherapistservice = physiotherapistService;
            _physiotherapistservice1 = physiotherapistService1;
        }
        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("Create")]
        public IActionResult Post([FromBody] PhysiotherapistCreateModel model)
        {
            var result = _physiotherapistservice.Add(model);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }

        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public IActionResult Get()
        {
            var result = _physiotherapistservice.GetAll();
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = _physiotherapistservice.Get(id);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(Guid id)
        {
            var result = _physiotherapistservice.Delete(id);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpPut]
        public IActionResult Update(PhysiotherapistUpdateModel model)
        {
            var result = _physiotherapistservice.Update(model);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpGet("[action]")]
        public IActionResult GetAllActivePhysiotherapist()
        {
            var result = _physiotherapistservice.getAllActivePhysiotherapist();
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }

        [HttpGet("[action]")]
        public IActionResult GetPhysiotherapistByUserID(Guid userID)
        {
            var result = _physiotherapistservice.GetPhysiotherapistByUserID(userID);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }

    }
}