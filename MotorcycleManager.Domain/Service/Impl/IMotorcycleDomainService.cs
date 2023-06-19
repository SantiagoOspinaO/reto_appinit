using MotorcycleManager.Domain.Models;

namespace MotorcycleManager.Domain.Service.Impl
{
    public interface IMotorcycleDomainService
    {
        Task<IEnumerable<MotorcycleEntity>> CreateMotorcycle(MotorcycleEntity motorcycle);
        Task<IEnumerable<MotorcycleEntity>> GetAllMotorcycles();
        Task<MotorcycleEntity> GetMotorcycleById(int id);
        Task UpdateMotorcycle(MotorcycleEntity motorcycle);
        Task DeleteMotorcycle(int id);
    }
}
