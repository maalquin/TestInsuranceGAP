﻿using Gap.Domain;
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

        public virtual DbSet<GAPCoverTypePolicy> GAPCoverTypePolicy { get; set; }
        public virtual DbSet<GAPCustomerPolicy> GAPCustomerPolicy { get; set; }
        public virtual DbSet<GAPPolicies> GAPPolicies { get; set; }
        public virtual DbSet<GAPTypeRisk> GAPTypeRisk { get; set; }
        public virtual DbSet<GAPWebApiUser> GAPWebAPIUsers { get; set; }
        public virtual DbSet<GAPWebAPIUserToken> GAPWebAPIUserToken { get; set; }

        public GapContext() : base(DatabaseName)
        {
            var connectionString = GAP.Common.Configuration.GetConnectionStringForKey(DatabaseName);
            Database.Connection.ConnectionString = connectionString;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          
        }
    }
}
