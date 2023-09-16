namespace PaymentServiceProvider.Domain.Interfaces;

public interface IPayableRepository
{
    double GetBalanceAvailable();
    double GetBalanceWaitingFunds();
}