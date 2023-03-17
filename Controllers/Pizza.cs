using Pizzas.Api.Controller;

namespace Pizzas.Api.Controller{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzasController : ControllerBase {
        [HttpGet]
        public IActionResult GetAll
    }
}