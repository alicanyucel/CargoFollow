using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebApplication2.Hubs;


namespace CargoTracking.Controllers
    {
        [Route("api/[controller]/[action]")]
        [ApiController]
        public class CargoController : ControllerBase
        {
            private readonly IHubContext<CargoHub> _hubContext;

            public CargoController(IHubContext<CargoHub> hubContext)
            {
                _hubContext = hubContext;
            }
            [HttpPost("{cargoId}")]
            public async Task<IActionResult> UpdateCargoStatus(string cargoId, [FromBody] string status)
            {
             
                await _hubContext.Clients.All.SendAsync("ReceiveCargoStatus", cargoId, status);

                return Ok(new { CargoId = cargoId, Status = status });
            }
        }
    }
