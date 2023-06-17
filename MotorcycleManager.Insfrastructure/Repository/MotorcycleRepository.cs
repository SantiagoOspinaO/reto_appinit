using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotorcycleManager.Domain.Abstraction;
using MotorcycleManager.Insfrastructure.Context;

namespace MotorcycleManager.Insfrastructure.Repository
{
    internal class MotorcycleRepository : IMotorcycleRepository
    {
        private readonly MotorcycleManagerContext context;
        private readonly ILoggerManager LoggerManager;
    }
}
