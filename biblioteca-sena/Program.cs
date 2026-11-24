
using BibliotecaSena.Models;
using BibliotecaSena.Services;

// Instancias de los servicios
LibroService libroService = new LibroService();
UsuarioService usuarioService = new UsuarioService();
PrestamoService prestamoService = new PrestamoService();

// Datos de prueba: libros
Libro libro1 = new Libro(1, "Cien años de soledad",
    "Gabriel García Márquez", 1967);

Libro libro2 = new Libro(2, "Don Quijote",
    "Miguel de Cervantes", 1605);

Libro libro3 = new Libro(3, "El Principito",
    "Antoine de Saint-Exupéry", 1943);

Libro libro4 = new Libro(4, "La Odisea",
    "Homero", -700);

Libro libro5 = new Libro(5, "Libro de prueba",
    "Autor de prueba", 2026);

libroService.AgregarLibro(libro1);
libroService.AgregarLibro(libro2);
libroService.AgregarLibro(libro3);
libroService.AgregarLibro(libro4);
libroService.AgregarLibro(libro5);

// Datos de prueba: usuarios
Usuario usuario1 = new Usuario(1,
    "Carlos Pérez", "carlos@gmail.com");

Usuario usuario2 = new Usuario(2,
    "Ana Gómez", "ana@gmail.com");

Usuario usuario3 = new Usuario(3,
    "Miguel Torres", "miguel@gmail.com");

Usuario usuario4 = new Usuario(4,
    "Laura García", "laura@gmail.com");

usuarioService.AgregarUsuario(usuario1);
usuarioService.AgregarUsuario(usuario2);
usuarioService.AgregarUsuario(usuario3);
usuarioService.AgregarUsuario(usuario4);

// Datos de prueba: préstamos
Prestamo prestamo1 = new Prestamo(
    1, libro1, usuario1,
    DateTime.Now.AddDays(-2),
    DateTime.Now.AddDays(12));

Prestamo prestamo2 = new Prestamo(
    2, libro2, usuario2,
    DateTime.Now.AddDays(-20),
    DateTime.Now.AddDays(-6));

Prestamo prestamo3 = new Prestamo(
    3, libro3, usuario3,
    DateTime.Now.AddDays(-7),
    DateTime.Now.AddDays(7));

prestamoService.AgregarPrestamo(prestamo1);
prestamoService.AgregarPrestamo(prestamo2);
prestamoService.AgregarPrestamo(prestamo3);

// Simular devolución
prestamoService.DevolverPrestamo(3);

// Simular usuario inactivo
usuarioService.EliminarUsuario(4);

string opcion = "";

while (opcion != "0")
{
    Console.Clear();

    Console.WriteLine("===== SISTEMA DE BIBLIOTECA =====");
    Console.WriteLine("1. Gestionar libros");
    Console.WriteLine("2. Gestionar usuarios");
    Console.WriteLine("3. Gestionar préstamos");
    Console.WriteLine("4. Ver estadísticas");
    Console.WriteLine("5. Comparación Array vs List");
    Console.WriteLine("0. Salir");

    Console.Write("Seleccione una opción: ");
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
            MostrarEstadisticas();
            break;

        case "5":
            CompararArrayList();
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

// MENÚ DE LIBROS
void MenuLibros()
{
    Console.Clear();

    Console.WriteLine("===== LIBROS =====");
    Console.WriteLine("1. Mostrar todos");
    Console.WriteLine("2. Buscar por título");
    Console.WriteLine("3. Buscar por autor");
    Console.WriteLine("4. Ordenar por título");
    Console.WriteLine("5. Ordenar por año");
    Console.WriteLine("6. Eliminar libro");
    Console.WriteLine("7. Agregar libro");
    Console.WriteLine("0. Regresar");

    Console.Write("Opción: ");
    string op = Console.ReadLine() ?? "";

    switch (op)
    {
        case "1":
            MostrarLibros(libroService.ObtenerTodos());
            break;

        case "2":
            Console.Write("Ingrese el título: ");
            string titulo = Console.ReadLine() ?? "";

            MostrarLibros(
                libroService.BuscarPorTitulo(titulo));
            break;

        case "3":
            Console.Write("Ingrese el autor: ");
            string autor = Console.ReadLine() ?? "";

            MostrarLibros(
                libroService.BuscarPorAutor(autor));
            break;

        case "4":
            MostrarLibros(
                libroService.OrdenarPorTitulo());
            break;

        case "5":
            MostrarLibros(
                libroService.OrdenarPorAnio());
            break;

        case "6":
            Console.Write("ID del libro: ");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (libroService.EliminarLibro(id))
                    Console.WriteLine("Libro eliminado.");
                else
                    Console.WriteLine(
                        "Libro inexistente o prestado.");
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
            break;

        case "7":
            AgregarLibro();
            break;

        case "0":
            return;

        default:
            Console.WriteLine("Opción incorrecta.");
            break;
    }

    Pausa();
}

// AGREGAR LIBRO
void AgregarLibro()
{
    Console.Write("ID: ");

    if (!int.TryParse(Console.ReadLine(), out int id) ||
        id <= 0)
    {
        Console.WriteLine("ID inválido.");
        return;
    }

    if (libroService.BuscarPorId(id) != null)
    {
        Console.WriteLine("El ID ya existe.");
        return;
    }

    Console.Write("Título: ");
    string titulo = Console.ReadLine() ?? "";

    Console.Write("Autor: ");
    string autor = Console.ReadLine() ?? "";

    Console.Write("Año de publicación: ");

    if (!int.TryParse(Console.ReadLine(), out int anio))
    {
        Console.WriteLine("Año inválido.");
        return;
    }

    if (string.IsNullOrWhiteSpace(titulo) ||
        string.IsNullOrWhiteSpace(autor))
    {
        Console.WriteLine("Complete todos los campos.");
        return;
    }

    Libro libro = new Libro(id, titulo, autor, anio);

    libroService.AgregarLibro(libro);

    Console.WriteLine("Libro agregado correctamente.");
}

// MOSTRAR LIBROS
void MostrarLibros(List<Libro> libros)
{
    if (libros.Count == 0)
    {
        Console.WriteLine("No se encontraron libros.");
        return;
    }

    foreach (Libro libro in libros)
    {
        Console.WriteLine(libro.DetalleCompleto());
        Console.WriteLine("-----------------------");
    }
}

// MENÚ DE USUARIOS
void MenuUsuarios()
{
    Console.Clear();

    Console.WriteLine("===== USUARIOS =====");
    Console.WriteLine("1. Mostrar todos");
    Console.WriteLine("2. Buscar por nombre");
    Console.WriteLine("3. Ordenar por nombre");
    Console.WriteLine("4. Desactivar usuario");
    Console.WriteLine("5. Agregar usuario");
    Console.WriteLine("0. Regresar");

    Console.Write("Opción: ");
    string op = Console.ReadLine() ?? "";

    switch (op)
    {
        case "1":
            MostrarUsuarios(
                usuarioService.ObtenerTodos());
            break;

        case "2":
            Console.Write("Ingrese el nombre: ");
            string nombre = Console.ReadLine() ?? "";

            MostrarUsuarios(
                usuarioService.BuscarPorNombre(nombre));
            break;

        case "3":
            MostrarUsuarios(
                usuarioService.OrdenarPorNombre());
            break;

        case "4":
            Console.Write("ID del usuario: ");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (usuarioService.EliminarUsuario(id))
                    Console.WriteLine("Usuario desactivado.");
                else
                    Console.WriteLine(
                        "Usuario inexistente o inactivo.");
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
            break;

        case "5":
            AgregarUsuario();
            break;

        case "0":
            return;

        default:
            Console.WriteLine("Opción incorrecta.");
            break;
    }

    Pausa();
}

// AGREGAR USUARIO
void AgregarUsuario()
{
    Console.Write("ID: ");

    if (!int.TryParse(Console.ReadLine(), out int id) ||
        id <= 0)
    {
        Console.WriteLine("ID inválido.");
        return;
    }

    if (usuarioService.BuscarPorId(id) != null)
    {
        Console.WriteLine("El ID ya existe.");
        return;
    }

    Console.Write("Nombre: ");
    string nombre = Console.ReadLine() ?? "";

    Console.Write("Contacto: ");
    string contacto = Console.ReadLine() ?? "";

    if (string.IsNullOrWhiteSpace(nombre) ||
        string.IsNullOrWhiteSpace(contacto))
    {
        Console.WriteLine("Complete todos los campos.");
        return;
    }

    Usuario usuario = new Usuario(id, nombre, contacto);

    usuarioService.AgregarUsuario(usuario);

    Console.WriteLine("Usuario agregado correctamente.");
}

// MOSTRAR USUARIOS
void MostrarUsuarios(List<Usuario> usuarios)
{
    if (usuarios.Count == 0)
    {
        Console.WriteLine("No se encontraron usuarios.");
        return;
    }

    foreach (Usuario usuario in usuarios)
    {
        Console.WriteLine(usuario.DetalleCompleto());
        Console.WriteLine("-----------------------");
    }
}

// MENÚ DE PRÉSTAMOS
void MenuPrestamos()
{
    Console.Clear();

    Console.WriteLine("===== PRÉSTAMOS =====");
    Console.WriteLine("1. Mostrar todos");
    Console.WriteLine("2. Buscar por ID");
    Console.WriteLine("3. Buscar por estado");
    Console.WriteLine("4. Ordenar por fecha límite");
    Console.WriteLine("5. Registrar devolución");
    Console.WriteLine("6. Eliminar préstamo devuelto");
    Console.WriteLine("7. Agregar préstamo");
    Console.WriteLine("0. Regresar");

    Console.Write("Opción: ");
    string op = Console.ReadLine() ?? "";

    switch (op)
    {
        case "1":
            MostrarPrestamos(
                prestamoService.ObtenerTodos());
            break;

        case "2":
            Console.Write("ID del préstamo: ");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Prestamo? prestamo =
                    prestamoService.BuscarPorId(id);

                if (prestamo != null)
                    Console.WriteLine(
                        prestamo.DetalleCompleto());
                else
                    Console.WriteLine("Préstamo no encontrado.");
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
            break;

        case "3":
            Console.WriteLine("0. Activo");
            Console.WriteLine("1. Devuelto");
            Console.WriteLine("2. Vencido");

            Console.Write("Estado: ");

            if (int.TryParse(Console.ReadLine(),
                out int estado) &&
                estado >= 0 && estado <= 2)
            {
                MostrarPrestamos(
                    prestamoService.BuscarPorEstado(
                        (EstadoPrestamo)estado));
            }
            else
            {
                Console.WriteLine("Estado inválido.");
            }
            break;

        case "4":
            MostrarPrestamos(
                prestamoService.OrdenarPorFechaLimite());
            break;

        case "5":
            Console.Write("ID del préstamo: ");

            if (int.TryParse(Console.ReadLine(),
                out int idDevolver))
            {
                if (prestamoService.DevolverPrestamo(idDevolver))
                    Console.WriteLine("Devolución registrada.");
                else
                    Console.WriteLine("No se pudo devolver.");
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
            break;

        case "6":
            Console.Write("ID del préstamo: ");

            if (int.TryParse(Console.ReadLine(),
                out int idEliminar))
            {
                if (prestamoService.EliminarPrestamo(idEliminar))
                    Console.WriteLine("Préstamo eliminado.");
                else
                    Console.WriteLine("No se pudo eliminar.");
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
            break;

        case "7":
            AgregarPrestamo();
            break;

        case "0":
            return;

        default:
            Console.WriteLine("Opción incorrecta.");
            break;
    }

    Pausa();
}

// AGREGAR PRÉSTAMO
void AgregarPrestamo()
{
    Console.Write("ID del préstamo: ");

    if (!int.TryParse(Console.ReadLine(), out int id) ||
        id <= 0)
    {
        Console.WriteLine("ID inválido.");
        return;
    }

    if (prestamoService.BuscarPorId(id) != null)
    {
        Console.WriteLine("El ID ya existe.");
        return;
    }

    Console.Write("ID del libro: ");

    if (!int.TryParse(Console.ReadLine(), out int idLibro))
    {
        Console.WriteLine("ID inválido.");
        return;
    }

    Console.Write("ID del usuario: ");

    if (!int.TryParse(Console.ReadLine(), out int idUsuario))
    {
        Console.WriteLine("ID inválido.");
        return;
    }

    Libro? libro = libroService.BuscarPorId(idLibro);

    Usuario? usuario = usuarioService.BuscarPorId(idUsuario);

    if (libro == null || usuario == null)
    {
        Console.WriteLine("Libro o usuario no encontrado.");
        return;
    }

    Prestamo prestamo = new Prestamo(
        id, libro, usuario,
        DateTime.Now,
        DateTime.Now.AddDays(14));

    if (prestamoService.AgregarPrestamo(prestamo))
        Console.WriteLine("Préstamo agregado correctamente.");
    else
        Console.WriteLine("Libro no disponible o usuario inactivo.");
}

// MOSTRAR PRÉSTAMOS
void MostrarPrestamos(List<Prestamo> prestamos)
{
    if (prestamos.Count == 0)
    {
        Console.WriteLine("No se encontraron préstamos.");
        return;
    }

    foreach (Prestamo prestamo in prestamos)
    {
        Console.WriteLine(prestamo.DetalleCompleto());
        Console.WriteLine("-----------------------");
    }
}

// KPIs
void MostrarEstadisticas()
{
    Console.Clear();

    Console.WriteLine("===== ESTADÍSTICAS =====");

    Console.WriteLine("\nLIBROS");
    Console.WriteLine("Total: " +
        libroService.TotalLibros());

    Console.WriteLine("Disponibles: " +
        libroService.LibrosDisponibles());

    Console.WriteLine("Prestados: " +
        libroService.LibrosPrestados());

    Console.WriteLine("\nUSUARIOS");
    Console.WriteLine("Total: " +
        usuarioService.TotalUsuarios());

    Console.WriteLine("Activos: " +
        usuarioService.UsuariosActivos());

    Console.WriteLine("Inactivos: " +
        usuarioService.UsuariosInactivos());

    Console.WriteLine("\nPRÉSTAMOS");
    Console.WriteLine("Total: " +
        prestamoService.TotalPrestamos());

    Console.WriteLine("Activos: " +
        prestamoService.PrestamosActivos());

    Console.WriteLine("Vencidos: " +
        prestamoService.PrestamosVencidos());

    Console.WriteLine("Devueltos: " +
        prestamoService.PrestamosDevueltos());

    Console.WriteLine("Promedio de días: " +
        prestamoService.PromedioDiasPrestamo().ToString("F2"));

    Pausa();
}

// COMPARACIÓN ARRAY VS LIST
void CompararArrayList()
{
    Console.Clear();

    Console.WriteLine("===== ARRAY VS LIST =====");

    // Array: tamaño fijo
    Libro[] arrayLibros = new Libro[2];

    arrayLibros[0] = libro1;
    arrayLibros[1] = libro2;

    Console.WriteLine("\nARRAY:");

    foreach (Libro libro in arrayLibros)
    {
        Console.WriteLine(libro.Titulo);
    }

    Console.WriteLine("Cantidad: " + arrayLibros.Length);

    // List: tamaño dinámico
    List<Libro> listaLibros = new List<Libro>();

    listaLibros.Add(libro1);
    listaLibros.Add(libro2);
    listaLibros.Add(libro3);

    Console.WriteLine("\nLIST:");

    foreach (Libro libro in listaLibros)
    {
        Console.WriteLine(libro.Titulo);
    }

    Console.WriteLine("Cantidad: " + listaLibros.Count);

    // Eliminar un elemento de la lista
    listaLibros.Remove(libro3);

    Console.WriteLine("Cantidad después de eliminar: " +
        listaLibros.Count);

    Console.WriteLine("\nDIFERENCIA:");

    Console.WriteLine("Array: tiene un tamaño fijo.");
    Console.WriteLine("List: tiene un tamaño dinámico.");
    Console.WriteLine("List permite agregar y eliminar elementos.");
    Console.WriteLine("Array utiliza Length y List utiliza Count.");

    Pausa();
}

// PAUSA
void Pausa()
{
    Console.WriteLine("\nPresiona Enter para continuar...");
    Console.ReadLine();
}
