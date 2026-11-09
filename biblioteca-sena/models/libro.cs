
namespace BibliotecaSena.Models;

public class Libro
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int AnioPublicacion { get; set; }
    public bool Disponible { get; set; }

    public Libro()
    {
        Titulo = "";
        Autor = "";
        Disponible = true;
    }

    public Libro(int id, string titulo, string autor,
                 int anioPublicacion)
    {
        Id = id;
        Titulo = titulo;
        Autor = autor;
        AnioPublicacion = anioPublicacion;
        Disponible = true;
    }

    public string ResumenCorto()
    {
        return $"{Id} - {Titulo} - {Autor}";
    }

    public string DetalleCompleto()
    {
        return $"ID: {Id}\n" +
               $"Título: {Titulo}\n" +
               $"Autor: {Autor}\n" +
               $"Año: {AnioPublicacion}\n" +
               $"Disponible: {Disponible}";
    }

    public override string ToString()
    {
        return ResumenCorto();
    }
}
