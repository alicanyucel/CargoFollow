using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebApplication2.Hubs;


namespace CargoTracking.Controllers;
[Route("Cargo/[action]")]
public class CargoController : Controller
{
    private readonly IHubContext<CargoHub> _hubContext;

    public CargoController(IHubContext<CargoHub> hubContext)
    {
        _hubContext = hubContext;
    }

    [HttpPost("{cargoId}")]
    public async Task<IActionResult> UpdateCargoStatus(string cargoId, [FromBody] StatusUpdate statusUpdate)
    {
      

        await _hubContext.Clients.All.SendAsync("ReceiveCargoStatus", cargoId, statusUpdate.Status);

        return Ok(new { CargoId = cargoId, Status = statusUpdate.Status });
    }

    public class StatusUpdate
    {
        public string Status { get; set; }
    }
}