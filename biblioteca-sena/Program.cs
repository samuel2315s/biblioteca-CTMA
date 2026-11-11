using BibliotecaSena.Models;

// Objetos de prueba 
Libro libro1 = new Libro(1, "Cien años de soledad", "Gabriel García Márquez", 1967);
Libro libro2 = new Libro(2, "Don Quijote de la Mancha", "Miguel de Cervantes", 1605);

Usuario usuario1 = new Usuario(1, "Carlos Pérez", "carlos@gmail.com");
Usuario usuario2 = new Usuario(2, "Ana Gómez", "ana@gmail.com");

Prestamo prestamo1 = new Prestamo(1, libro1, usuario1, DateTime.Now, DateTime.Now.AddDays(14));
libro1.Disponible = false;

List<Libro> libros = new List<Libro> { libro1, libro2 };
List<Usuario> usuarios = new List<Usuario> { usuario1, usuario2 };
List<Prestamo> prestamos = new List<Prestamo> { prestamo1 };

string opcion = "";

while (opcion != "0")
{
    Console.Clear();
    Console.WriteLine("===== SISTEMA DE BIBLIOTECA =====");
    Console.WriteLine("1. Libros");
    Console.WriteLine("2. Usuarios");
    Console.WriteLine("3. Préstamos");
    Console.WriteLine("4. Probar todos los objetos");
    Console.WriteLine("0. Salir");
    Console.Write("Elige una opción: ");
    opcion = Console.ReadLine() ?? "";

    switch (opcion)
    {
        case "1":
            MenuLibros();
            break;
        case "2":
            MenuUsuarios();
            break;
        case "3":
            MenuPrestamos();
            break;
        case "4":
            ProbarObjetos();
            break;
        case "0":
            Console.WriteLine("Hasta pronto.");
            break;
        default:
            Console.WriteLine("Opción incorrecta.");
            Pausa();
            break;
    }
}

void MenuLibros()
{
    Console.Clear();
    Console.WriteLine("===== LIBROS =====");
    Console.WriteLine("1. Ver resúmenes");
    Console.WriteLine("2. Ver detalles completos");
    Console.Write("Opción: ");
    string opcionLibro = Console.ReadLine() ?? "";

    foreach (Libro libro in libros)
    {
        if (opcionLibro == "1")
            Console.WriteLine(libro.ResumenCorto());
        else if (opcionLibro == "2")
        {
            Console.WriteLine(libro.DetalleCompleto());
            Console.WriteLine("ToString(): " + libro.ToString());
            Console.WriteLine("Disponible: " + libro.Disponible);
        }
    }
    Pausa();
}

void MenuUsuarios()
{
    Console.Clear();
    Console.WriteLine("===== USUARIOS =====");
    Console.WriteLine("1. Ver resúmenes");
    Console.WriteLine("2. Ver detalles completos");
    Console.Write("Opción: ");
    string opcionUsuario = Console.ReadLine() ?? "";

    foreach (Usuario usuario in usuarios)
    {
        if (opcionUsuario == "1")
            Console.WriteLine(usuario.ResumenCorto());
        else if (opcionUsuario == "2")
        {
            Console.WriteLine(usuario.DetalleCompleto());
            Console.WriteLine("ToString(): " + usuario.ToString());
            Console.WriteLine("Activo: " + usuario.Activo);
        }
    }
    Pausa();
}

void MenuPrestamos()
{
    Console.Clear();
    Console.WriteLine("===== PRÉSTAMOS =====");
    Console.WriteLine("1. Ver resúmenes");
    Console.WriteLine("2. Ver detalles y validaciones");
    Console.Write("Opción: ");
    string opcionPrestamo = Console.ReadLine() ?? "";

    foreach (Prestamo prestamo in prestamos)
    {
        if (prestamo.FechaDevolucion != null)
            prestamo.Estado = EstadoPrestamo.Devuelto;
        else if (prestamo.EstaVencido())
            prestamo.Estado = EstadoPrestamo.Vencido;
        else
            prestamo.Estado = EstadoPrestamo.Activo;

        if (opcionPrestamo == "1")
            Console.WriteLine(prestamo.ResumenCorto());
        else if (opcionPrestamo == "2")
        {
            Console.WriteLine(prestamo.DetalleCompleto());
            Console.WriteLine("ToString(): " + prestamo.ToString());
            Console.WriteLine("Estado: " + prestamo.Estado);
            Console.WriteLine("EstaVencido(): " + prestamo.EstaVencido());
            Console.WriteLine("DiasTranscurridos(): " + prestamo.DiasTranscurridos());
        }
    }
    Pausa();
}

void ProbarObjetos()
{
    Console.Clear();
    Console.WriteLine("===== OBJETOS DE PRUEBA =====");

    Console.WriteLine("\nLIBROS:");
    foreach (Libro libro in libros)
    {
        Console.WriteLine(libro.ResumenCorto());
        Console.WriteLine(libro.DetalleCompleto());
        Console.WriteLine("Disponible: " + libro.Disponible);
        Console.WriteLine("ToString(): " + libro.ToString());
    }

    Console.WriteLine("\nUSUARIOS:");
    foreach (Usuario usuario in usuarios)
    {
        Console.WriteLine(usuario.ResumenCorto());
        Console.WriteLine(usuario.DetalleCompleto());
        Console.WriteLine("Activo: " + usuario.Activo);
        Console.WriteLine("ToString(): " + usuario.ToString());
    }

    Console.WriteLine("\nPRÉSTAMOS:");
    foreach (Prestamo prestamo in prestamos)
    {
        if (prestamo.FechaDevolucion != null)
            prestamo.Estado = EstadoPrestamo.Devuelto;
        else if (prestamo.EstaVencido())
            prestamo.Estado = EstadoPrestamo.Vencido;
        else
            prestamo.Estado = EstadoPrestamo.Activo;

        Console.WriteLine(prestamo.ResumenCorto());
        Console.WriteLine(prestamo.DetalleCompleto());
        Console.WriteLine("Estado: " + prestamo.Estado);
        Console.WriteLine("EstaVencido(): " + prestamo.EstaVencido());
        Console.WriteLine("DiasTranscurridos(): " + prestamo.DiasTranscurridos());
        Console.WriteLine("ToString(): " + prestamo.ToString());
    }
    Pausa();
}

void Pausa()
{
    Console.WriteLine("\nPresiona Enter para continuar...");
    Console.ReadLine();
}
