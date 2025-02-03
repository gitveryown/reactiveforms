using angularBackend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

/* updated the formcontroller to recieve data from model/user 
   import system.text.json to use jsonserializer
   NOW NEED TO CHECK WHAT IS BEING RECEIVED
   ERRORS WITH CORS, EVEN THOUGH I ENABLE CORS GLOBAL IN PROGRAM.CS
*/

namespace angularBackend.Controllers
{
    [ApiController]
    [Route("api/form")]
    public class FormController : ControllerBase
    {


        [HttpPost()]
        public IActionResult RecieveFormData([FromBody] Users model)
        {
            if (model == null)
            {
                return BadRequest("Invalid data received");
            }

            Console.WriteLine("Recieved Form Data:");
            Console.WriteLine(JsonSerializer.Serialize(model, new JsonSerializerOptions { WriteIndented = true }));


            return Ok(new { message = "Form submitted successfully" });
        }
    }
}