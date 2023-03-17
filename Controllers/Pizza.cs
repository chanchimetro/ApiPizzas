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

    [HttpGet("{id}")]
    public IActionResult GetById(int id) {
        IActionResult respuesta;
        Pizza entity;

        entity = DB.GetById(id);
        if(id<=0) respuesta = BadRequest();
        else if(entity == null) respuesta = NotFound();
        else respuesta = Ok(entity);
        return respuesta;
    }

    [HttpPost]
    public IActionResult Create(Pizza pizza) {
        DB.Create(pizza);
        return CreatedAtAction(nameof(Create), new { id = pizza.id }, pizza);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza) {
        IActionResult respuesta;
        Pizza p;
        if(id!=pizza.id) respuesta = BadRequest();
        else {
            p = DB.GetById(id);
            if(p == null) respuesta = NotFound();
            else {
                DB.Update(id, pizza);
                respuesta = Ok(pizza);
            }
        }
        return respuesta;
    }


    [HttpDelete("{id}")]  
    public IActionResult DeleteById(int id) {
        IActionResult respuesta;
        Pizza p;
        if(id <= 0) respuesta = BadRequest();
        else {
            p = DB.GetById(id);
            if(p == null) respuesta = NotFound();
            else {
                DB.DeleteById(id);
                respuesta = Ok(p);
            }
        }
        return respuesta;
    }

}
