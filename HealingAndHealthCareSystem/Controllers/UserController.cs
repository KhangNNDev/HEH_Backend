using Data.Model;
using Microsoft.AspNetCore.Mvc;
using Services.Core;

namespace HealingAndHealthCareSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
   {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("Register")]
        public async Task<ActionResult> Register([FromBody] MemberCreateModel model)
        {
            var result = await _userService.Register(model);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpPost("Register-admin")]
        public async Task<ActionResult> RegisterAdmin([FromBody] UserCreateModel model)
        {
            var result = await _userService.RegisterAdmin(model);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = _userService.GetAll();
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] LoginModel model)
        {
            var result = await _userService.Login(model);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpGet("{email}")]
        public IActionResult getByEmail(string email)
        {
            var result = _userService.GetByEmail(email);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpGet("[action]/{id}")]
        public IActionResult getById(Guid id)
        {
            var result = _userService.GetByID(id);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpGet("[action]/{id}")]
        public IActionResult getUserRole(Guid id) {
            var result = _userService.GetUserRole(id);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage); 
        }
        [HttpPut]
        public IActionResult Update(UserUpdateModel model)
        {
            var result = _userService.Update(model);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpGet("[action]/{id}")]
        public IActionResult BanUser(Guid id) {
            var result = _userService.bannedUser(id);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpGet("[action]/{id}")]
        public IActionResult unBanUser(Guid id)
        {
            var result = _userService.unBannedUser(id);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpPost("Register-Physiotherapist")]
        public async Task<ActionResult> RegisterPhysiotherapist([FromBody] UserCreateModel model)
        {
            var result = await _userService.RegisterPhysiotherapist(model);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpPost("Register-Staff")]
        public async Task<ActionResult> RegisterStaff([FromBody] UserCreateModel model)
        {
            var result = await _userService.RegisterStaff(model);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpPost("ChangePassword")]
        public async Task<ActionResult> ChangePassword([FromBody] UserUpdatePasswordModel model)
        {
            var result = await _userService.ChangePassword(model);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpPut("[action]")]
        public IActionResult UpdatePhone(UserUpdatePhoneModel model)
        {
            var result = _userService.UpdatePhone(model);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpGet("RecoveryPassword")]
        public async Task<ActionResult> RecoveryPassword(string email)
        {
            var result = await _userService.RecoveryPassword(email);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpGet("ResetPassword")]
        public async Task<ActionResult> ResetPassword(string email, string token, string newPassword)
        {
            var result = await _userService.ResetPassword(email, token, newPassword);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }

    }
}
