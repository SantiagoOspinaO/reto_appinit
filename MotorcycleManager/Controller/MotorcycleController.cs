using Microsoft.AspNetCore.Mvc;
using MotorcycleManager.Application.Motorcycles.Request;
using MotorcycleManager.Application.Motorcycles.Response;
using MotorcycleManager.Application.Service.Impl;
using MotorcycleManager.Utilities;
using MotorcycleManager.Utilities.ExceptionHandler;
using MotorcycleManager.Utilities.Logger;

namespace MotorcycleManager.Api.Controller
{
    [Route("api/motorcycles")]
    [ApiController]
    public class MotorcycleController : ControllerBase
    {
        private readonly IMotorcycleApplicationService _motorcycleService;
        private readonly ILoggerManager _logger;

        public MotorcycleController(IMotorcycleApplicationService motorcycleService, ILoggerManager logger)
        {
            _motorcycleService = motorcycleService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<MotorcycleResponse>>> CreateMotorcycle([FromBody] MotorcycleRequest request)
        {
            try
            {
                _logger.LogInfo("Start Create Motorcycle");
                return Ok(await _motorcycleService.CreateMotorcycle(request));
            }
            catch (ExceptionHandler ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpGet]
        public async Task<ActionResult<IList<MotorcycleResponse>>> GetAllMotorcycles()
        {
            try
            {
                _logger.LogInfo("Start Get All Motorcycle");
                var response = await _motorcycleService.GetAllMotorcycles();
                return response != null && response.Count() > 0 ? Ok(response) : NotFound(Messages.IS_EMPTY);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MotorcycleResponse>> GetMotorcycleById(int id)
        {
            try
            {
                _logger.LogInfo("Start Get Motorcycle By Id");
                var motorcycle = await _motorcycleService.GetMotorcycleById(id);
                if (motorcycle == null)
                {
                    return NotFound();
                }
                return Ok(motorcycle);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MotorcycleResponse>> UpdateMotorcycle(int id, MotorcycleRequest motorcycleRequest)
        {
            try
            {
                _logger.LogInfo("Start Update Motorcycle");
                var existsMotorcycle = await _motorcycleService.GetMotorcycleById(id);
                if (existsMotorcycle == null)
                {
                    return NotFound();
                }

                await _motorcycleService.UpdateMotorcycle(motorcycleRequest);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMotorcycle(int id)
        {
            try
            {
                _logger.LogInfo("Start Delete Motorcycle");
                var existsMotorcycle = await _motorcycleService.GetMotorcycleById(id);
                if (existsMotorcycle == null)
                {
                    return NotFound(Messages.IS_EMPTY);
                }
                await _motorcycleService.DeleteMotorcycle(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }
    }
}
