using Microsoft.AspNetCore.Mvc;
using Pizzas.Models;

namespace Pizzas.API.Controller;
[ApiController]
[Route("api/[controller]")]
public class PizzasController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll() {
        IActionResult respuesta;
        List<Pizza> entityList;

        entityList = DB.getAll();
        respuesta = Ok(entityList);
        return respuesta;
    }

/*
    [HttpGet("{id}")]
    public IActionResult GetById(int id) { }

    [HttpPost]
    public IActionResult Create(Pizza pizza) { }


    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza) { }

    [HttpDelete("{id}")]  
    public IActionResult DeleteById(int id) { }
*/

}
