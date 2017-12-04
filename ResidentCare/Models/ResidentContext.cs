using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResidentCare.Models
{
    public class ResidentContext : DbContext
    {
        public ResidentContext(DbContextOptions<ResidentContext> options) : base(options)
        {
        }

        public DbSet<Resident> Resident { get; set; }
        public DbSet<Note> Note { get; set; }


    }
}
