using MotorcycleManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleManager.Infrastructure.Repository.Impl
{
    public interface IMotorcycleRepository
    {
        Task CreateMotorcycle(MotorcycleEntity motorcycle);
        Task<IEnumerable<MotorcycleEntity>> GetAllMotorcycles();
        Task<MotorcycleEntity> GetMotorcycleById(Guid id);
        Task UpdateMotorcycle(MotorcycleEntity motorcycle);
        Task DeleteMotorcycle(Guid id);
    }
}
