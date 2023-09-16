using PaymentServiceProvider.Domain.Entities;

namespace PaymentServiceProvider.Domain.DTOs;

public class TransactionDto
{
    public double Amount { get; set; }
    public string Description { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public string CardNumber { get; set; }
    public string CardName { get; set; }
    public DateTime CardExpireDate { get; set; }
    public string CardCvv { get; set; }
}