namespace PaymentServiceProvider.Domain.Entities;

public class Payable : Entity
{
    public Payable(){}
    public Payable(StatusPayable status, DateTime paymentDate, double fee, Guid transactionId)
    {
        Id = Guid.NewGuid();
        Status = status;
        PaymentDate = paymentDate;
        Fee = fee;
        TransactionId = transactionId;
    }
    
    public StatusPayable Status { get; private set; }
    public DateTime PaymentDate { get; private set; }
    public double Fee { get; private set; }
    public Guid TransactionId { get; private set; }
    public Transaction? Transaction { get; private set; }
}

public enum StatusPayable
{
    Payed = 1,
    WaitingFunds = 2
}