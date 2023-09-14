using Microsoft.EntityFrameworkCore;
using ReplicandoAPI.Models;

namespace ReplicandoAPI.Context;

public class TareasContext : DbContext
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }
    
    public TareasContext(DbContextOptions<TareasContext> options): base(options){}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        List<Categoria> categorias = new List<Categoria>();
        categorias.Add(new Categoria(){CategoriaId = Guid.Parse("20769474-d3b8-44c4-a55d-8f22d45e085e"), Nombre = "Personales",Peso = 20, });
        categorias.Add(new Categoria(){CategoriaId = Guid.Parse("34dcc8e6-3f78-4d7c-bb7a-a0210dec424d"), Nombre = "Laborales",Peso = 20, });
        builder.Entity<Categoria>(categoria =>
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(c => c.CategoriaId);
            categoria.Property(c => c.Nombre).IsRequired();
            categoria.Property(c => c.Descripcion).IsRequired(false);
            categoria.Property(c => c.Peso);
            categoria.HasData(categorias);
        });

        List<Tarea> tareas = new List<Tarea>();
        tareas.Add(new Tarea(){TareId = Guid.Parse("71c3ac95-768d-4d95-bff8-e523f2a37210"),categoriaId =  Guid.Parse("20769474-d3b8-44c4-a55d-8f22d45e085e"),Nombre = "Ir GYM", Prioridad = Prioridad.Bajo, FechaCreacion = DateTime.Now});
        tareas.Add(new Tarea(){TareId = Guid.Parse("71c3ac95-768d-4d95-bff8-e523f2a37211"),categoriaId = Guid.Parse("34dcc8e6-3f78-4d7c-bb7a-a0210dec424d"),Nombre = "Presentar API", Prioridad = Prioridad.Alto, FechaCreacion = DateTime.Now});
        builder.Entity<Tarea>(tarea =>
        {
            tarea.ToTable("Tarea");
            tarea.HasKey(t => t.TareId);
            tarea.HasOne(t => t.Categoria).WithMany(t => t.Tarea).HasForeignKey(t => t.categoriaId);
            tarea.Property(t => t.Nombre).IsRequired().HasMaxLength(200);
            tarea.Property(t => t.Descripcion).IsRequired(false);
            tarea.Property(t => t.Prioridad);
            tarea.Property(t => t.FechaCreacion);
            tarea.HasData(tareas);
        });
    }
    
    
}