using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab10_Marquez.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TicketsController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<string>> GetProtectedData()
    {
        return Ok(new string[] { "Ticket #001: Login Error", "Ticket #002: Error Database" });
    }
}