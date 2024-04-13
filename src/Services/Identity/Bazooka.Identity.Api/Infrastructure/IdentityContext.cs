using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bazooka.Identity.Api.Infrastructure.Repositories;
using Bazooka.Identity.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Bazooka.Identity.Api.Infrastructure
{
    public class IdentityContext:DbContext,IUnitOfWork
    {
        public static string ContextSchema ="IDN";
        public IdentityContext(DbContextOptions<IdentityContext> options):base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}