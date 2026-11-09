
namespace BibliotecaSena.Models;

public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Contacto { get; set; }
    public bool Activo { get; set; }

    public Usuario()
    {
        Nombre = "";
        Contacto = "";
        Activo = true;
    }

    public Usuario(int id, string nombre, string contacto)
    {
        Id = id;
        Nombre = nombre;
        Contacto = contacto;
        Activo = true;
    }

    public string ResumenCorto()
    {
        return $"{Id} - {Nombre}";
    }

    public string DetalleCompleto()
    {
        return $"ID: {Id}\n" +
               $"Nombre: {Nombre}\n" +
               $"Contacto: {Contacto}\n" +
               $"Activo: {Activo}";
    }

    public override string ToString()
    {
        return ResumenCorto();
    }
}
