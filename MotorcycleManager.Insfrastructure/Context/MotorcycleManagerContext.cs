using Microsoft.EntityFrameworkCore;
using MotorcycleManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleManager.Infrastructure.Context
{
    public class MotorcycleManagerContext : DbContext
    {
        public MotorcycleManagerContext(DbContextOptions<MotorcycleManagerContext> options) : base(options) { }
        public DbSet<MotorcycleEntity> Motorcycles { get; set; }
    }
}
