using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotorcycleManager.Domain.Models;
using MotorcycleManager.Infrastructure.Repository.Impl;
using MotorcycleManager.Infrastructure.Context;
using MotorcycleManager.Utilities;
using MotorcycleManager.Utilities.ExceptionHandler;
using MotorcycleManager.Utilities.Logger;

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
                throw new ExceptionHandler(string.Format(Messages.ID_EXIST, motorcycle.MotorcycleId));
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
                throw new ExceptionHandler(string.Format(Messages.ID_EXIST));
            }
        }

        public async Task<MotorcycleEntity> GetMotorcycleById(Guid id)
        {
            try
            {
                return await _context.Motorcycles.FirstOrDefaultAsync(entity => entity.MotorcycleId == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR: {ex.Message}");
                throw new ExceptionHandler(string.Format(Messages.ID_EXIST));
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
                throw new ExceptionHandler(string.Format(Messages.ID_EXIST));
            }
        }

        public async Task DeleteMotorcycle(Guid id)
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
                throw new ExceptionHandler(string.Format(Messages.ID_EXIST));
            }
        }
    }
}
