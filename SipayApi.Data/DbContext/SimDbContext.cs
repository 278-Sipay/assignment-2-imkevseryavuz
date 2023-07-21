using Microsoft.EntityFrameworkCore;
using SipayApi.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SipayApi.Data
{
    public class SimDbContext : DbContext
    {
        //public SimDbContext(DbContextOptions<SimDbContext> options) : base(options)
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=sipy;Integrated Security=True;");
        }


        // dbset
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Transaction> Transaction { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        internal IEnumerable<Transaction> GetByParameter(Expression<Func<Transaction, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
