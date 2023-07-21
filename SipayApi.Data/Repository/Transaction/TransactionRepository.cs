using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using SipayApi.Data.Domain;
using SipayApi.Data.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;



namespace SipayApi.Data.Repository
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        private readonly SimDbContext dbContext;
 
        public TransactionRepository(SimDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        // IGenericRepository'den gelen metotların implementasyonu burada
        public IEnumerable<Transaction> GetByFilter(int? accountNumber, string referenceNumber,
                                        decimal? minAmountCredit, decimal? maxAmountCredit,
                                        decimal? minAmountDebit, decimal? maxAmountDebit,
                                        string description, DateTime? beginDate, DateTime? endDate)
        {
            Expression<Func<Transaction, bool>> filter = t =>
            (!accountNumber.HasValue || t.AccountNumber == accountNumber.Value) &&
            (string.IsNullOrEmpty(referenceNumber) || t. ReferenceNumber.Contains(referenceNumber)) &&
            (!minAmountCredit.HasValue || t.CreditAmount >= minAmountCredit.Value) &&
            (!maxAmountCredit.HasValue || t.CreditAmount <= maxAmountCredit.Value) &&
            (!minAmountDebit.HasValue || t.DebitAmount >= minAmountDebit.Value) &&
            (!maxAmountDebit.HasValue || t.DebitAmount <= maxAmountDebit.Value) &&
            (string.IsNullOrEmpty(description) || t.Description.Contains(description)) &&
            (!beginDate.HasValue || t.TransactionDate >= beginDate.Value) &&
            (!endDate.HasValue || t.TransactionDate <= endDate.Value);

            return dbContext.Transaction.Where(filter).ToList();
        }

        public List<Transaction> GetByReference(string reference)
        {
            return dbContext.Set<Transaction>().Where(x => x.ReferenceNumber == reference).ToList();
        }
    }

    }

