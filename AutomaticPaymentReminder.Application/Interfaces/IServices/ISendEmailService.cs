using AutomaticPaymentReminder.Application.DTOs;

namespace AutomaticPaymentReminder.Application.Interfaces.IServices;

public interface ISendEmailService
{

    Task<IQueryable<DebtQueryResult>> GetUnpaidDebts();
    Task<int> SendReminder();
}