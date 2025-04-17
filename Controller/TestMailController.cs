using Microsoft.AspNetCore.Mvc;
using MyWebApi.Service;
using MyWebApi.ViewModel;
using Microsoft.Extensions.Logging;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestMailController : ControllerBase
    {
        private readonly ISendMailService _sendMailService;
        private readonly ILogger<TestMailController> _logger;
        private readonly IConfiguration _configuration;

        public TestMailController(ISendMailService sendMailService, ILogger<TestMailController> logger, IConfiguration configuration)
        {
            _sendMailService = sendMailService;
            _logger = logger;
            _configuration = configuration;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendTestEmail([FromBody] EmailModel request)
        {
            try
            {
                _logger.LogInformation("Starting to send email...");
                
                var mailContent = new EmailModel
                {
                    FromEmail = _configuration["Gmail:Username"],
                    ToEmail = request.ToEmail,
                    Subject = request.Subject,
                    Body = request.Body
                };

                _logger.LogInformation($"Sending email from {mailContent.FromEmail} to {mailContent.ToEmail}");
                await _sendMailService.SendEmail(mailContent);
                
                _logger.LogInformation("Email sent successfully");
                return Ok("Email sent successfully");
            }
            catch (Exception ex) 
            {
                _logger.LogError($"Failed to send email: {ex.Message}");
                _logger.LogError($"Stack trace: {ex.StackTrace}");
                return BadRequest($"Failed to send email: {ex.Message}");
            }
        }
    }
} 