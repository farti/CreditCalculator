using CreditCalculator.Models;

namespace CreditCalculator
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CreditDb : DbContext
    {
        // Your context has been configured to use a 'Credit' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'CreditCalculator.Credit' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Credit' 
        // connection string in the application configuration file.
        public CreditDb()
            : base("name=Credit")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<Credit> Credits { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}