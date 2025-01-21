using Microsoft.AspNetCore.Mvc; // Import the MVC library for controller functionality

namespace YourNamespace.Controllers // Group this class logically in the project namespace
{
    [ApiController] // Marks this class as a Web API controller, automatically enabling validation and error handling
    [Route("api/[controller]")] // Specifies the base route for this controller
    public class MessageController : ControllerBase // Inherit from ControllerBase for API-focused controllers
    {
        [HttpGet("greet")] // Maps this method to HTTP GET requests at api/message/greet
        public IActionResult GetGreeting()
        {
            return Ok(new { message = "Hello from ASP.NET Core!" }); // Returns a JSON response with an HTTP 200 status
        }
    }
}