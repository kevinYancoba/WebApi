using Microsoft.AspNetCore.Mvc;
using ReplicandoAPI.Models;
using ReplicandoAPI.Services;

namespace ReplicandoAPI.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class CategoriaController : ControllerBase
{
    public ICategoriaService Service { get; set; }

    public CategoriaController( ICategoriaService service)
    {
        Service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        
        return Ok(Service.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Categoria categoria)
    {
        try
        {
            return Ok(Service.Save(categoria));
        }
        catch (Exception e)
        {
            Console.WriteLine("Error de contrlador POST: ", e);
            throw;
        }
      
        
    }

    [HttpPut ("{id}")]
    public IActionResult Put([FromRoute] Guid id, [FromBody] Categoria categoria)
    {
        try
        {
            return Ok(Service.Update(id, categoria));
        }
        catch (Exception e)
        {
            Console.WriteLine("Error de contrloadro PUT",e);
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
            Console.WriteLine("Error de controlador DELETE",e);
            NotFound();
            throw;
        }
        
      
    }
}