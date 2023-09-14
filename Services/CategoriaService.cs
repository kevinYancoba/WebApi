using ReplicandoAPI.Context;
using ReplicandoAPI.Models;

namespace ReplicandoAPI.Services;

public class CategoriaService: ICategoriaService
{
    public TareasContext Context { get; set; }

    public CategoriaService(TareasContext context)
    {
        Context = context;
    }
    
    public List<Categoria> Get()
    {
        return Context.Categorias.ToList();
    }

    public async Task Save(Categoria categoria)
    {
        categoria.CategoriaId = new Guid();
        Context.Add(categoria);
        await Context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Categoria categoria)
    {
        var categoriaActual = Context.Categorias.Find(id);
        if (categoriaActual != null)
        {
            categoriaActual.Nombre = categoria.Nombre;
            categoriaActual.Descripcion = categoriaActual.Descripcion;
            categoriaActual.Peso = categoria.Peso;

           await Context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id)
    {
        Categoria categoriaActual = Context.Categorias.Find(id);
        if (categoriaActual != null)
        {
            Context.Remove(categoriaActual);
            await Context.SaveChangesAsync();
        }
    }
    
}

public interface ICategoriaService
{
    public List<Categoria> Get();
    public Task Save(Categoria categoria);
    public Task Update(Guid id, Categoria categoria);
    public Task Delete(Guid id);
}