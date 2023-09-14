namespace ReplicandoAPI.Models;

public class Tarea
{
    public Guid TareId { get; set; }
    public Guid categoriaId { get; set; }
    public string Nombre { get; set;}
    public string? Descripcion { get; set;}
    public Categoria Categoria { get; set; }
    public Prioridad Prioridad { get; set; }
    public DateTime FechaCreacion { get; set; }
}
public enum Prioridad
{
    Bajo,
    Medio, 
    Alto

}