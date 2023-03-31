﻿using Domain.Models;

namespace Domain.Services.Interfaces
{
    public interface ITransactionService
    {
        public void AddTransaction(Transaction transaction);
        public List<Transaction> GetUserTransactions(int UserId);
    }
}
