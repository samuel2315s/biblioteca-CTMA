
using BibliotecaSena.Models;

namespace BibliotecaSena.Services;

public class PrestamoService
{
    private List<Prestamo> prestamos = new List<Prestamo>();

    // Agregar préstamo
    public bool AgregarPrestamo(Prestamo prestamo)
    {
        if (!prestamo.Libro.Disponible ||
            !prestamo.Usuario.Activo)
        {
            return false;
        }

        prestamo.Libro.Disponible = false;
        prestamos.Add(prestamo);

        ActualizarEstados();

        return true;
    }

    // Eliminar préstamo
    public bool EliminarPrestamo(int id)
    {
        Prestamo? prestamo = BuscarPorId(id);

        if (prestamo != null &&
            prestamo.Estado == EstadoPrestamo.Devuelto)
        {
            prestamos.Remove(prestamo);
            return true;
        }

        return false;
    }

    // Obtener todos los préstamos
    public List<Prestamo> ObtenerTodos()
    {
        ActualizarEstados();

        return new List<Prestamo>(prestamos);
    }

    // Buscar por ID
    public Prestamo? BuscarPorId(int id)
    {
        ActualizarEstados();

        return prestamos.Find(p => p.Id == id);
    }

    // Buscar por estado
    public List<Prestamo> BuscarPorEstado(EstadoPrestamo estado)
    {
        ActualizarEstados();

        return prestamos.FindAll(p => p.Estado == estado);
    }

    // Ordenar por fecha de vencimiento
    public List<Prestamo> OrdenarPorFechaLimite()
    {
        ActualizarEstados();

        return prestamos.OrderBy(p =>
            p.FechaVencimiento).ToList();
    }

    // Registrar devolución
    public bool DevolverPrestamo(int id)
    {
        Prestamo? prestamo = BuscarPorId(id);

        if (prestamo != null &&
            prestamo.Estado != EstadoPrestamo.Devuelto)
        {
            prestamo.FechaDevolucion = DateTime.Now;
            prestamo.Estado = EstadoPrestamo.Devuelto;
            prestamo.Libro.Disponible = true;

            return true;
        }

        return false;
    }

    // Actualizar estados
    private void ActualizarEstados()
    {
        foreach (Prestamo prestamo in prestamos)
        {
            if (prestamo.FechaDevolucion != null)
            {
                prestamo.Estado = EstadoPrestamo.Devuelto;
            }
            else if (prestamo.EstaVencido())
            {
                prestamo.Estado = EstadoPrestamo.Vencido;
            }
            else
            {
                prestamo.Estado = EstadoPrestamo.Activo;
            }
        }
    }
    // Total de préstamos
public int TotalPrestamos()
{
    return prestamos.Count;
}

// Préstamos activos
public int PrestamosActivos()
{
    ActualizarEstados();

    return prestamos.Count(p =>
        p.Estado == EstadoPrestamo.Activo);
}

// Préstamos vencidos
public int PrestamosVencidos()
{
    ActualizarEstados();

    return prestamos.Count(p =>
        p.Estado == EstadoPrestamo.Vencido);
}

// Préstamos devueltos
public int PrestamosDevueltos()
{
    ActualizarEstados();

    return prestamos.Count(p =>
        p.Estado == EstadoPrestamo.Devuelto);
}

// Promedio de días de préstamo
public double PromedioDiasPrestamo()
{
    if (prestamos.Count == 0)
    {
        return 0;
    }

    return prestamos.Average(p =>
        p.DiasTranscurridos());
}
}
