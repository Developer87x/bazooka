using Bazooka.Customers.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bazooka.Customers.Api.Infrastructure.EntityConfigurations;

public class CustomerTypeConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("customers",CustomersContext.ContextSchema);
        builder.HasKey(s=>s.Id);
        builder.Property(s=>s.FirstName).HasMaxLength(70);
        builder.OwnsOne(s=>s.Address,a=>
        {
            a.ToTable("addresses",CustomersContext.ContextSchema);
            a.WithOwner();
        });
        builder.OwnsOne(s=>s.PersonalInformation, a=>
        {
            a.ToTable("personal_informaiton",CustomersContext.ContextSchema);
            a.WithOwner();
        });
        builder.OwnsOne(s=>s.JobInformation, a=>
        {
            a.ToTable("job_informaiton",CustomersContext.ContextSchema);
            a.WithOwner();
        });
    }
}