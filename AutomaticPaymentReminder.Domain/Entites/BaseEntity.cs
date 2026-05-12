namespace AutomaticPaymentReminder.Domain.Entites;

public class BaseEntity
{
    public Guid Id { get; set; } =  Guid.NewGuid();
}