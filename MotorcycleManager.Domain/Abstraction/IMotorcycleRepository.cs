using MotorcycleManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleManager.Domain.Abstraction
{
    internal interface IMotorcycleRepository
    {
        Task<IEnumerable<MotorcycleEntity>> GetMotorcycles();
        Task<IEnumerable<MotorcycleEntity>> GetMotorcycleById(int id);
        Task CreateMotorcycle(MotorcycleEntity motorcycle);
    }
}
