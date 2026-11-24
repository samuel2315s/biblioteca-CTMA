
using BibliotecaSena.Models;

namespace BibliotecaSena.Services;

public class UsuarioService
{
    private List<Usuario> usuarios = new List<Usuario>();

    // Agregar usuario
    public void AgregarUsuario(Usuario usuario)
    {
        usuarios.Add(usuario);
    }

    // Eliminación simulada
    public bool EliminarUsuario(int id)
    {
        Usuario? usuario = usuarios.Find(u => u.Id == id);

        if (usuario != null && usuario.Activo)
        {
            usuario.Activo = false;
            return true;
        }

        return false;
    }

    // Obtener todos los usuarios
    public List<Usuario> ObtenerTodos()
    {
        return new List<Usuario>(usuarios);
    }

    // Buscar por ID
    public Usuario? BuscarPorId(int id)
    {
        return usuarios.Find(u => u.Id == id);
    }

    // Buscar por nombre
    public List<Usuario> BuscarPorNombre(string nombre)
    {
        return usuarios.FindAll(u =>
            u.Nombre.Contains(nombre,
            StringComparison.OrdinalIgnoreCase));
    }

    // Ordenar por nombre
    public List<Usuario> OrdenarPorNombre()
    {
        return usuarios.OrderBy(u => u.Nombre).ToList();
    }
}
