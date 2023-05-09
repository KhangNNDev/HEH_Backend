using Data.Model;
using Microsoft.AspNetCore.Mvc;
using Services.Core;

namespace HealingAndHealthCareSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;

        }
        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public IActionResult Post([FromBody] ScheduleCreateModel model)
        {
            var result = _scheduleService.Add(model);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }

        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public IActionResult Get()
        {
            var result = _scheduleService.GetAll();
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = _scheduleService.Get(id);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(Guid id)
        {
            var result = _scheduleService.Delete(id);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpPut]
        public IActionResult Update(ScheduleUpdateModel model)
        {
            var result = _scheduleService.Update(model);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpGet("[action]/{id}")]
        public IActionResult GetAllSlotByPhysiotherapistIDAndTypeOfSlot(Guid id, string typeOfSlot)
        {
            var result = _scheduleService.GetAllSlotByPhysiotherapistIDAndTypeOfSlot(id, typeOfSlot);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpGet("[action]")]
        public IActionResult GetAllPhysiotherapistBySlotTimeAndSkillAndTypeOfSlot(DateTime timeStart, DateTime timeEnd, string skill, string typeOfSlot)
        {
            var result = _scheduleService.GetAllPhysiotherapistBySlotTimeAndSkillAndTypeOfSlot(timeStart,timeEnd,skill,typeOfSlot);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpGet("[action]/{id}")]

        public IActionResult getBySlotID(Guid id)
        {
            var result = _scheduleService.GetBySlotID(id);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpGet("[action]/{slotID}")]
        public IActionResult GetNumberOfPhysioRegister(Guid slotID)
        {
            var result = _scheduleService.GetNumberOfPhysioRegister(slotID);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpGet("[action]/{id}")]
        public IActionResult getAllSlotByPhysiotherapistID(Guid id)
        {
            var result = _scheduleService.getAllSlotByPhysiotherapistID(id);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
      

    }
}
