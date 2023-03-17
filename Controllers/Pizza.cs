using Microsoft.AspNetCore.Mvc;

namespace ApiPizzas.Controller;
[ApiController]
[Route("api/[controller]")]
public class PizzasController : ControllerBase
{pi
    [HttpGet]
    public IActionResult GetAll() { }

    [HttpGet("{id}")]
    public IActionResult GetById(int id) { }

    [HttpPost]
    public IActionResult Create(Pizza pizza) { }


    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza) { }

    [HttpDelete("{id}")]  
    public IActionResult DeleteById(int id) { }


}
