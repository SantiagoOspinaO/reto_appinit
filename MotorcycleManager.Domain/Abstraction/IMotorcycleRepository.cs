using MotorcycleManager.Domain.Models;

namespace MotorcycleManager.Domain.Abstraction
{
    public interface IMotorcycleRepository
    {
        Task CreateMotorcycle(MotorcycleEntity motorcycle);
        Task<IEnumerable<MotorcycleEntity>> GetAllMotorcycles();
        Task<MotorcycleEntity> GetMotorcycleById(int id);
        Task UpdateMotorcycle(MotorcycleEntity motorcycle);
        Task DeleteMotorcycle(int id);
    }
}
