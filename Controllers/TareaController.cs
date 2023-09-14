using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ReplicandoAPI.Models;
using ReplicandoAPI.Services;

namespace ReplicandoAPI.Controllers;

[ApiController]
[Route("Api/[Controller]")]
public class TareaController: ControllerBase
{
    public ITareaService Service { get; set; }

    public TareaController(ITareaService _service)
    {
        Service = _service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            return Ok(Service.Get());
        }
        catch (Exception e)
        {
            Console.WriteLine("Error COntroller Get",e);
            throw;
        }
        
    }
    [HttpPost]
    public IActionResult Post([FromBody] Tarea tarea)
    {
        //try
        //{
            return Ok(Service.Save(tarea));
       // }
        //catch (Exception e)
        //{
            //Console.WriteLine("Error Controlador POST",e);
           // throw;
       // }
        
    }
    
    [HttpPut("{id}")]
    public IActionResult Put([FromRoute] Guid id, [FromBody] Tarea tarea)
    {
        try
        {
           return Ok(Service.Update(id, tarea));
        }
        catch (Exception e)
        {
            Console.WriteLine("Error en Controlador PUT",e);
            throw;
        }
        
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] Guid id)
    {
        try
        {
            return Ok(Service.Delete(id));
        }
        catch (Exception e)
        {
            Console.WriteLine("Error en Controlador DELETE",e);
            throw;
        }
        
        
    }
    
}