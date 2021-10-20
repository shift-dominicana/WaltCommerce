using BussinesLayer.Interfaces;
using BussinesLayer.Models.Mails;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WaltCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService mailService;
        public MailController(IMailService mailService)
        {
            this.mailService = mailService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMail([FromForm] Mail request)
        {
            try
            {
                await mailService.SendEmailAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

    }
}
