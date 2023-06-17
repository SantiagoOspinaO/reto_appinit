using Microsoft.EntityFrameworkCore;
using MotorcycleManager.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleManager.Insfrastructure.Context
{
    internal class MotorcycleManagerContext : DbContext
    {
        public MotorcycleManagerContext(DbContextOptions<MotorcycleManagerContext> options) : base(options) { }
        public DbSet<MotorcycleEntity> Motorcycles { get; set; }
    }
}
