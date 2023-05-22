using Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using Services.Core;

namespace HealingAndHealthCareSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentservice;
        private readonly IPaymentService _paymentservice1;
        public PaymentController(IPaymentService paymentservice, IPaymentService paymentservice1)
        {
            _paymentservice = paymentservice;
            _paymentservice1 = paymentservice1;
        }
        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("callVNPayGW")]
        public IActionResult callVNPayGW([FromBody] PaymentModel paymentModel)
        {
            var ipAddress = Request.HttpContext?.Connection?.RemoteIpAddress?.MapToIPv4().ToString();
            var result = _paymentservice.callVNPayGW(paymentModel, ipAddress);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }

        [HttpGet("callbackVNPayGW")]
        public IActionResult callbackVNPayGW([FromQuery] VNPayModel vnpayModel)
        {
            var result = _paymentservice.callbackVNPayGW(vnpayModel);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }

        [HttpGet("checkVNPayResult")]
        public IActionResult checkVNPayResult([FromQuery] VNPayModel vnpayModel)
        {
            var result = _paymentservice.checkVNPayGWResult(vnpayModel);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }

    }
}
