using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bazooka.Identity.Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? EmailAddress { get; set; }
        public string? Password { get; set; }
        public string? UserName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public ICollection<UserRole>? UserRoles { get; set; }
        
    }
}