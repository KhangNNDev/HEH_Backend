using Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Core;

namespace HealingAndHealthCareSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingDetailController : ControllerBase
    {
        private readonly IBookingDetailService _bookingDetailservice;
        public BookingDetailController(IBookingDetailService bookingDetailservice)
        {
            _bookingDetailservice = bookingDetailservice;
        }
        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("Create")]
        public IActionResult Post([FromBody] BookingDetailCreateModel model)
        {
            var result = _bookingDetailservice.Add(model);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }

        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public IActionResult Get()
        {
            var result = _bookingDetailservice.GetAll();
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = _bookingDetailservice.Get(id);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(Guid id)
        {
            var result = _bookingDetailservice.Delete(id);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpPut]
        public IActionResult Update(BookingDetailUpdateModel model)
        {
            var result = _bookingDetailservice.Update(model);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpGet("[action]")]
        public IActionResult GetByUserIDAndTypeOfSlot(Guid userID, string typeOfSlot)
        {
            var result = _bookingDetailservice.GetByUserIDAndTypeOfSlot(userID, typeOfSlot);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpGet("[action]")]
        public IActionResult GetAllBookingDetailByPhysioIDAndTypeOfSlotAndShortTermLongTermStatus(Guid physioID,String typeOfSlot,int shortTermStatus, int longTermStatus ){
            var result = _bookingDetailservice.GetAllBookingDetailByPhysioIDAndTypeOfSlotAndShortTermLongTermStatus(
                physioID, typeOfSlot,shortTermStatus,longTermStatus);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }

        [HttpGet("[action]")]
        public IActionResult GetLongTermListByStatus(int shortTermStatus)
        {
            var result = _bookingDetailservice.GetLongTermListByStatus(shortTermStatus);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
    }
}
