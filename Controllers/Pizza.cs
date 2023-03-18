using Microsoft.AspNetCore.Mvc;
using Pizzas.Models;

namespace Pizzas.API.Controller;
[ApiController]
[Route("api/[controller]")]
public class PizzasController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        IActionResult respuesta;
        List<Pizza> entityList;

        entityList = DB.getAll();
        respuesta = Ok(entityList);
        return respuesta;
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        IActionResult respuesta;
        Pizza entity;

        entity = DB.GetById(id);
        if (id <= 0) respuesta = BadRequest();
        else if (entity == null) respuesta = NotFound();
        else respuesta = Ok(entity);
        return respuesta;
    }

    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {
        int intRowsAffected;
        intRowsAffected = DB.Create(pizza);
        return CreatedAtAction(nameof(Create), new { id = pizza.id }, pizza);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        IActionResult respuesta = null;
        Pizza entity;
        int intRowsAffected;
        if (id != pizza.id)
        {
            respuesta = BadRequest();
        }
        else
        {
            entity = DB.GetById(id);
            if (entity == null)
            {
                respuesta = NotFound();
            }
            else
            {
                intRowsAffected = DB.Update(pizza);
                if (intRowsAffected > 0)
                {
                    respuesta = Ok(pizza);
                }
                else
                {
                    respuesta = NotFound();
                }
            }
        }
        return respuesta;
    }


    [HttpDelete("{id}")]
    public IActionResult DeleteById(int id)
    {
        IActionResult respuesta = null;
        Pizza entity;
        int intRowsAffected;
        entity = DB.GetById(id);

        if (entity == null)
        {
            respuesta = NotFound();
        }
        else
        {
            intRowsAffected = DB.DeleteById(id);
            if (intRowsAffected > 0)
            {
                respuesta = Ok(entity);
            }
            else
            {
                respuesta = NotFound();
            }
        }
        return respuesta;
    }
}
