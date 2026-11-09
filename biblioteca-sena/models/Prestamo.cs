
namespace BibliotecaSena.Models;

public class Prestamo
{
    public int Id { get; set; }
    public Libro Libro { get; set; }
    public Usuario Usuario { get; set; }
    public DateTime FechaPrestamo { get; set; }
    public DateTime FechaVencimiento { get; set; }
    public DateTime? FechaDevolucion { get; set; }
    public EstadoPrestamo Estado { get; set; }

    public Prestamo()
    {
        Libro = new Libro();
        Usuario = new Usuario();
        FechaPrestamo = DateTime.Now;
        FechaVencimiento = DateTime.Now;
        FechaDevolucion = null;
        Estado = EstadoPrestamo.Activo;
    }

    public Prestamo(
        int id,
        Libro libro,
        Usuario usuario,
        DateTime fechaPrestamo,
        DateTime fechaVencimiento)
    {
        Id = id;
        Libro = libro;
        Usuario = usuario;
        FechaPrestamo = fechaPrestamo;
        FechaVencimiento = fechaVencimiento;
        FechaDevolucion = null;
        Estado = EstadoPrestamo.Activo;
    }

    public bool EstaVencido()
    {
        return FechaDevolucion == null &&
               DateTime.Now > FechaVencimiento;
    }

    public int DiasTranscurridos()
    {
        DateTime fechaFinal = FechaDevolucion ?? DateTime.Now;

        return Math.Max(0,
            (fechaFinal.Date - FechaPrestamo.Date).Days);
    }

    public string ResumenCorto()
    {
        return $"Préstamo {Id}: {Libro.Titulo} - {Usuario.Nombre}";
    }

    public string DetalleCompleto()
    {
        return $"ID: {Id}\n" +
               $"Libro: {Libro.Titulo}\n" +
               $"Usuario: {Usuario.Nombre}\n" +
               $"Fecha préstamo: {FechaPrestamo:dd/MM/yyyy}\n" +
               $"Fecha vencimiento: {FechaVencimiento:dd/MM/yyyy}\n" +
               $"Fecha devolución: " +
               $"{(FechaDevolucion.HasValue ? FechaDevolucion.Value.ToString("dd/MM/yyyy") : "Pendiente")}\n" +
               $"Estado: {Estado}";
    }

    public override string ToString()
    {
        return ResumenCorto();
    }
}
