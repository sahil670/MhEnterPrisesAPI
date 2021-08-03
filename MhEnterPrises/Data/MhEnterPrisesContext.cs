using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MhEnterPrises.Models;

namespace MhEnterPrises.Data
{
    public class MhEnterPrisesContext : DbContext
    {
        public MhEnterPrisesContext (DbContextOptions<MhEnterPrisesContext> options)
            : base(options)
        {
        }

        public DbSet<MhEnterPrises.Models.Authentication> Authentication { get; set; }

        public DbSet<MhEnterPrises.Models.HomeAppliances> HomeAppliances { get; set; }

        public DbSet<MhEnterPrises.Models.StaffMember> StaffMember { get; set; }

        public DbSet<MhEnterPrises.Models.PlaceOrder> PlaceOrder { get; set; }
    }
}
