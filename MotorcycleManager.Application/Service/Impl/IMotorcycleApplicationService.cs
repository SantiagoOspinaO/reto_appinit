using MotorcycleManager.Application.Motorcycles.Request;
using MotorcycleManager.Application.Motorcycles.Response;

namespace MotorcycleManager.Application.Service.Impl
{
    public interface IMotorcycleApplicationService
    {
        Task<IEnumerable<MotorcycleResponse>> CreateMotorcycle(MotorcycleRequest motorcycleRequest);
        Task<IEnumerable<MotorcycleResponse>> GetAllMotorcycles();
        Task<MotorcycleResponse> GetMotorcycleById(int id);
        Task UpdateMotorcycle(MotorcycleRequest motorcycleRequest);
        Task DeleteMotorcycle(int id);
    }
}
