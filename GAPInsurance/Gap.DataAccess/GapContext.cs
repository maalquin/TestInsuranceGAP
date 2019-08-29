using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gap.DataAccess
{
    internal class GapContext : DbContext
    {
        private const string DatabaseName = "GAPINSURANCETEST";

       

        public GapContext() : base(DatabaseName)
        {
            var connectionString = GAP.Common.Configuration.GetConnectionStringForKey(DatabaseName);
            Database.Connection.ConnectionString = connectionString;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<Book>().HasRequired(x => x.Publisher);
            //modelBuilder.Entity<Book>().HasRequired(x => x.Author);
        }
    }
}
