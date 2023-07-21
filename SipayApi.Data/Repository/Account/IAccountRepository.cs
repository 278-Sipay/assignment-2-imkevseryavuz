using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SipayApi.Data.Domain;
using SipayApi.Data.Repository.Base;

namespace SipayApi.Data.Repository
{
    public interface IAccountRepository : IGenericRepository<Account>
    {

    }
}
