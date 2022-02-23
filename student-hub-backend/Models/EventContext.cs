using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_hub_backend.Models
{
    public class EventContext: DbContext
    {
        public EventContext(DbContextOptions options) : base(options) { }
        DbSet<Events> Events
        {
            get;
            set;
        }
    }
}
