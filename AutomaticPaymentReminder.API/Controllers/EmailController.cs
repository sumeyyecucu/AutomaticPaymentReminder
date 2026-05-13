using AutomaticPaymentReminder.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace AutomaticPaymentReminder.API.Controllers;

[ApiController]
[Route("api/email")]
public class EmailController : BaseController
{
    private readonly SendEmailService _sendEmailService;

    public EmailController(SendEmailService sendEmailService)
    {
        _sendEmailService = sendEmailService;
    }

    [HttpPost("send-reminders")]
    public async Task<IActionResult> SendReminders()
    {
        var sentCount = await _sendEmailService.SendReminder();
        return Ok(new { message = $"{sentCount} adet hatırlatma e-postası gönderildi." });
    }

    [HttpGet("unpaid-debts")]
    public async Task<IActionResult> GetUnpaidDebts()
    {
        var result = await _sendEmailService.GetUnpaidDebts();
        return Ok(result);
    }
}