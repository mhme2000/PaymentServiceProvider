﻿using Microsoft.EntityFrameworkCore;
using PaymentServiceProvider.Domain.Entities;
using PaymentServiceProvider.Domain.Interfaces;
using PaymentServiceProvider.Infrastructure.Contexts;

namespace PaymentServiceProvider.Infrastructure.Repositories;

public class PayableRepository : IPayableRepository
{
    private readonly TransactionContext _context;

    public PayableRepository(TransactionContext context)
    {
        _context = context;
    }
    public double GetBalanceAvailable()
    {
        return _context.Payable.AsNoTracking().Where(p => p.Status == StatusPayable.Payed).Sum(p => p.Transaction.Amount - p.Fee);
    }

    public double GetBalanceWaitingFunds()
    {
        return _context.Payable.AsNoTracking().Where(p => p.Status == StatusPayable.WaitingFunds).Sum(p => p.Transaction.Amount - p.Fee);
    }
}