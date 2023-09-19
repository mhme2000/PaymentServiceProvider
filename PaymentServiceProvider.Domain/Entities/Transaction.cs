using System.Text.Json.Serialization;

namespace PaymentServiceProvider.Domain.Entities;

public class Transaction : Entity
{
    public Transaction(double amount, string description, PaymentMethod paymentMethod, uint numberOfInstallments, string cardNumber, string cardName, DateTime cardExpireDate, string cardCvv)
    {
        Id = Guid.NewGuid();
        Amount = amount;
        Description = description;
        PaymentMethod = paymentMethod;
        NumberOfInstallments = numberOfInstallments;
        CardNumber = cardNumber;
        CardName = cardName;
        CardExpireDate = cardExpireDate;
        CardCvv = cardCvv;
        Payables = new List<Payable>() { };
        
        CreatePayables(amount, paymentMethod, numberOfInstallments);
    }
        
    public double Amount { get; private set; }
    public string Description { get; private set; }
    public PaymentMethod PaymentMethod { get; private set; }
    public uint NumberOfInstallments { get; private set; }
    public string CardNumber { get; private set; }
    public string CardName { get; private set; }
    public DateTime CardExpireDate { get; private set; }
    public string CardCvv { get; private set; }
    [JsonIgnore]
    public ICollection<Payable> Payables { get; private set; }

    private void CreatePayables(double amount, PaymentMethod paymentMethod, uint numberOfInstallments)
    {
        for (var i = 0; i < numberOfInstallments; i++)
        {
            var payable = paymentMethod == PaymentMethod.CreditCard
                ? CreatePayableByCreditCard(amount/numberOfInstallments)
                : CreatePayableByDebitCard(amount);
            Payables.Add(payable);
        }
    }

    private Payable CreatePayableByCreditCard(double amount)
    {
        var feeCreditCard = 0.05 * amount;
        return new Payable(amount, StatusPayable.WaitingFunds, DateTime.Now.AddDays(30) ,feeCreditCard, Id);
    }
    
    private Payable CreatePayableByDebitCard(double amount)
    {
        var feeDebitCard = 0.03 * amount;
        return new Payable(amount, StatusPayable.Payed, DateTime.Now ,feeDebitCard, Id);
    }
}

public enum PaymentMethod
{
    DebitCard = 1,
    CreditCard = 2
}