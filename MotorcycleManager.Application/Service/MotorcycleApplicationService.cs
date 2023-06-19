using AutoMapper;
using MotorcycleManager.Application.Mapper;
using MotorcycleManager.Application.Motorcycles.Request;
using MotorcycleManager.Application.Motorcycles.Response;
using MotorcycleManager.Application.Service.Impl;
using MotorcycleManager.Domain.Models;
using MotorcycleManager.Domain.Service.Impl;
using MotorcycleManager.Utilities.Logger;

namespace MotorcycleManager.Application.Service
{
    public class MotorcycleApplicationService : IMotorcycleApplicationService
    {
        private readonly IMotorcycleDomainService _motorcycleService;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public MotorcycleApplicationService(IMotorcycleDomainService motorcycleService, ILoggerManager logger)
        {
            _motorcycleService = motorcycleService;
            _mapper = MapperHelper.Instance.GetConfigureMapper();
            _logger = logger;
        }

        public async Task<IEnumerable<MotorcycleResponse>> CreateMotorcycle(MotorcycleRequest motorcycleRequest)
        {
            var response = await _motorcycleService.CreateMotorcycle(_mapper.Map<MotorcycleEntity>(motorcycleRequest));
            return _mapper.Map<IEnumerable<MotorcycleResponse>>(response);
        }

        public async Task<IEnumerable<MotorcycleResponse>> GetAllMotorcycles()
        {
            var response = await _motorcycleService.GetAllMotorcycles();
            return _mapper.Map<IEnumerable<MotorcycleResponse>>(response);
        }

        public async Task<MotorcycleResponse> GetMotorcycleById(int id)
        {
            var motorcycle = await _motorcycleService.GetMotorcycleById(id);
            return _mapper.Map<MotorcycleResponse>(motorcycle);
        }

        public async Task UpdateMotorcycle(MotorcycleRequest motorcycleRequest)
        {
            var motorcycleEntity = _mapper.Map<MotorcycleEntity>(motorcycleRequest);
            await _motorcycleService.UpdateMotorcycle(motorcycleEntity);
        }

        public async Task DeleteMotorcycle(int id)
        {
            await _motorcycleService.DeleteMotorcycle(id);
        }
    }
}
