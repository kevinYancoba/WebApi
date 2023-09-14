using Microsoft.EntityFrameworkCore;
using ReplicandoAPI.Context;
using ReplicandoAPI.Models;

namespace ReplicandoAPI.Services;

public class TareaService : ITareaService
{
    public TareasContext Context { get; set; }

    public TareaService(TareasContext context)
    {
        Context = context;
    }

    public IEnumerable<Tarea>  Get()
    {
        return Context.Tareas.Include(c => c.Categoria);
    }

    public async Task Save(Tarea tarea)
    {
        tarea.TareId = new Guid();
        tarea.FechaCreacion = DateTime.Now;
        Context.Add(tarea);
        await Context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Tarea tarea)
    {
        var tareaActual = Context.Tareas.Find(id);
        if (tareaActual != null)
        {
            tareaActual.Nombre = tarea.Nombre;
            tareaActual.Prioridad = tarea.Prioridad;
            tareaActual.Descripcion = tarea.Descripcion;

            await Context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id)
    {
        var tareaActual = Context.Tareas.Find(id);
        if (tareaActual != null)
        {
            Context.Remove(tareaActual);
            await Context.SaveChangesAsync();
        }
    }
}

public interface ITareaService
{
    public IEnumerable<Tarea> Get();
    public Task Save(Tarea tarea);
    public Task Update(Guid id, Tarea tarea);
    public Task Delete(Guid id);

}