using SipayApi.Data.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SipayApi.Data.Domain;
using System.Linq.Expressions;

namespace SipayApi.Data.Repository
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {
        List<Transaction> GetByReference(string reference);
        IEnumerable<Transaction> GetByFilter(int? accountNumber, string referenceNumber,
                                              decimal? minAmountCredit, decimal? maxAmountCredit,
                                              decimal? minAmountDebit, decimal? maxAmountDebit,
                                              string description, DateTime? beginDate, DateTime? endDate);

    }
}
