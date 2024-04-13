using Bazooka.Customers.Api.Infrastructure.EntityConfigurations;
using Bazooka.Customers.Api.Infrastructure.Repositories;
using Bazooka.Customers.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Bazooka.Customers.Api.Infrastructure;

public class CustomersContext : DbContext,IUnitOfWork
{
    public static readonly string  ContextSchema="CTM";
    public CustomersContext(DbContextOptions options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerTypeConfiguration());
        
    }
    public DbSet<Customer> Customers { get; set; }
    
}