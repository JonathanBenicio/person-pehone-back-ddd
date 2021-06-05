using Examples.Charge.Domain.Aggregates.ExampleAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Examples.Charge.Infra.Data.Context
{
    public class ExampleContext : DbContext
    {
        public static bool firstRun = true;

        public ExampleContext(DbContextOptions<ExampleContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(ExampleContext)));


        }

        public DbSet<Example> Examples { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonPhone> PersonPhones { get; set; }
        public DbSet<PhoneNumberType> PhoneNumberTypes { get; set; }
    }
}