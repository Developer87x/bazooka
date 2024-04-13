using Bazooka.Customers.Api.Applications.Validations;
using Bazooka.Customers.Api.Infrastructure;
using Bazooka.Customers.Api.Infrastructure.Repositories;
using Bazooka.Customers.Api.Infrastructure.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var logger= new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).Enrich.FromLogContext().CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);


logger.Debug("Application started..");
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// dbcontext 
builder.Services.AddDbContext<CustomersContext>(cfg=>cfg.UseSqlServer(builder.Configuration["ConnectionString"]),ServiceLifetime.Scoped);
builder.Services.AddValidatorsFromAssemblyContaining<CustomerValidation>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
