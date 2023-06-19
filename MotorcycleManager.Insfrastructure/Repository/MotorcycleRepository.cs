using MotorcycleManager.Domain.Abstraction;
using MotorcycleManager.Domain.Models;
using MotorcycleManager.Infrastructure.Context;
using MotorcycleManager.Utilities;
using MotorcycleManager.Utilities.ExceptionHandler;
using MotorcycleManager.Utilities.Logger;
using System.Data.Entity;

namespace MotorcycleManager.Infrastructure.Repository
{
    public class MotorcycleRepository : IMotorcycleRepository
    {
        private readonly MotorcycleManagerContext _context;
        private readonly ILoggerManager _logger;

        public MotorcycleRepository(MotorcycleManagerContext context, ILoggerManager logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task CreateMotorcycle(MotorcycleEntity motorcycle)
        {
            try
            {
                await _context.Motorcycles.AddAsync(motorcycle);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR: {ex.Message}");
                throw new ExceptionHandler(string.Format(Messages.IS_EMPTY, motorcycle.MotorcycleId));
            }
        }

        public async Task<IEnumerable<MotorcycleEntity>> GetAllMotorcycles()
        {
            try
            {
                return await _context.Motorcycles.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR: {ex.Message}");
                throw new ExceptionHandler(string.Format(Messages.IS_EMPTY));
            }
        }

        public async Task<MotorcycleEntity> GetMotorcycleById(int id)
        {
            try
            {
                return await _context.Motorcycles.FirstOrDefaultAsync(entity => entity.MotorcycleId == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR: {ex.Message}");
                throw new ExceptionHandler(string.Format(Messages.NOT_ID_EXISTS));
            }
        }

        public async Task UpdateMotorcycle(MotorcycleEntity motorcycle)
        {
            try
            {
                _context.Motorcycles.Update(motorcycle);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR: {ex.Message}");
                throw new ExceptionHandler(string.Format(Messages.ERROR_UPDATE));
            }
        }

        public async Task DeleteMotorcycle(int id)
        {
            try
            {
                var motorcycle = await _context.Motorcycles.FindAsync(id);
                if (motorcycle != null)
                {
                    _context.Motorcycles.Remove(motorcycle);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR: {ex.Message}");
                throw new ExceptionHandler(string.Format(Messages.ERROR_DELETE));
            }
        }
    }
}
