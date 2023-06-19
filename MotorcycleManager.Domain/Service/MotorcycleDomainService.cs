using MotorcycleManager.Domain.Abstraction;
using MotorcycleManager.Domain.Models;
using MotorcycleManager.Domain.Service.Impl;
using MotorcycleManager.Utilities;
using MotorcycleManager.Utilities.ExceptionHandler;
using MotorcycleManager.Utilities.Logger;

namespace MotorcycleManager.Domain.Service
{
    public class MotorcycleDomainService : IMotorcycleDomainService
    {
        private readonly IMotorcycleRepository _repository;
        private readonly ILoggerManager _logger;

        public MotorcycleDomainService(IMotorcycleRepository motorcycleRepository, ILoggerManager logger)
        {
            _repository = motorcycleRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<MotorcycleEntity>> CreateMotorcycle(MotorcycleEntity motorcycle)
        {
            MotorcycleEntity motorcycleExists = await _repository.GetMotorcycleById(motorcycle.MotorcycleId);
            if (motorcycleExists != null)
            {
                _logger.LogError($"ERROR, A database record already exists");
                throw new ExceptionHandler(string.Format(Messages.IS_EMPTY, motorcycle.MotorcycleId));
            }
            await _repository.CreateMotorcycle(motorcycle);
            return await GetAllMotorcycles();
        }

        public async Task<IEnumerable<MotorcycleEntity>> GetAllMotorcycles()
        {
            _logger.LogInfo("Start: Get All Motorcycles");
            return await _repository.GetAllMotorcycles();
        }

        public async Task<MotorcycleEntity> GetMotorcycleById(int id)
        {
            _logger.LogInfo("Start: Get Motorcycle By Id");
            return await _repository.GetMotorcycleById(id);
        }

        public async Task UpdateMotorcycle(MotorcycleEntity motorcycle)
        {
            _logger.LogInfo("Start: Update Motorcycle");
            await _repository.UpdateMotorcycle(motorcycle);
        }

        public async Task DeleteMotorcycle(int id)
        {
            _logger.LogInfo("Start: Delete Motorcycle");
            await _repository.DeleteMotorcycle(id);
        }
    }
}
