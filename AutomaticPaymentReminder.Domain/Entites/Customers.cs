namespace AutomaticPaymentReminder.Domain.Entites;

public class Customers : BaseEntity
{
    public int CustomerNum { get; set; }
    public string NameSurname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } =  string.Empty;
    public string? Address { get; set; } = string.Empty;
    public string? City { get; set; }  = string.Empty;
    public string? State { get; set; } = string.Empty;
    public List<Subscriptions>? Subscriptions { get; set; }
}