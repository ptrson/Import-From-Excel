using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Import_From_Excel.Models.DataContext
{
    public class ImportDataContext : DbContext
    {
        public ImportDataContext() : base()
        {
        }

        public ImportDataContext(String ConnectionString) : base(ConnectionString)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Agreement> Agreements { get; set; }
        public DbSet<FinancialState> FinancialStates { get; set; }
        public DbSet<Person> Persons { get; set; }

    }
}