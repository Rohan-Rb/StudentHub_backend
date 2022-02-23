using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_hub_backend.Models
{
    public class RoleContext: DbContext
    {
        public RoleContext(DbContextOptions options) : base(options) { }
        DbSet<Roles> Roles
        {
            get;
            set;
        }
    }
}
