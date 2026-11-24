
using BibliotecaSena.Models;

namespace BibliotecaSena.Services;

public class LibroService
{
    private List<Libro> libros = new List<Libro>();

    // Agregar libro
    public void AgregarLibro(Libro libro)
    {
        libros.Add(libro);
    }

    // Eliminar libro por ID
    public bool EliminarLibro(int id)
    {
        Libro? libro = libros.Find(l => l.Id == id);

        if (libro != null && libro.Disponible)
        {
            libros.Remove(libro);
            return true;
        }

        return false;
    }

    // Obtener todos los libros
    public List<Libro> ObtenerTodos()
    {
        return new List<Libro>(libros);
    }

    // Buscar por ID
    public Libro? BuscarPorId(int id)
    {
        return libros.Find(l => l.Id == id);
    }

    // Buscar por título
    public List<Libro> BuscarPorTitulo(string titulo)
    {
        return libros.FindAll(l =>
            l.Titulo.Contains(titulo,
            StringComparison.OrdinalIgnoreCase));
    }

    // Buscar por autor
    public List<Libro> BuscarPorAutor(string autor)
    {
        return libros.FindAll(l =>
            l.Autor.Contains(autor,
            StringComparison.OrdinalIgnoreCase));
    }

    // Ordenar por título
    public List<Libro> OrdenarPorTitulo()
    {
        return libros.OrderBy(l => l.Titulo).ToList();
    }

    // Ordenar por año
    public List<Libro> OrdenarPorAnio()
    {
        return libros.OrderBy(l =>
            l.AnioPublicacion).ToList();
    }
}
