// ===================== PUNTO DE ENTRADA =====================
ShowMainMenu();

// ===================== UTILIDADES =====================
string ReadText(string message)
{
    Console.Write(message);
    string? text = Console.ReadLine();
    return string.IsNullOrWhiteSpace(text) ? "(sin dato)" : text;
}

string ReadOption()
{
    Console.Write("\nElige una opción: ");
    return Console.ReadLine()?.Trim() ?? "";
}

void Pause()
{
    Console.WriteLine("\nPresiona una tecla para continuar...");
    Console.ReadKey();
}

void InvalidOption()
{
    Console.WriteLine("Opción no válida, intenta de nuevo.");
    Pause();
}

// ===================== MENÚ PRINCIPAL =====================
void ShowMainMenu()
{
    string option;
    do
    {
        Console.Clear();
        Console.WriteLine("===== SISTEMA DE BIBLIOTECA =====");
        Console.WriteLine("1. Libros");
        Console.WriteLine("2. Usuarios");
        Console.WriteLine("3. Préstamos");
        Console.WriteLine("4. Búsquedas y reportes");
        Console.WriteLine("5. Guardar / Cargar datos");
        Console.WriteLine("6. Salir");
        option = ReadOption();

        switch (option)
        {
            case "1": ShowBooksMenu(); break;
            case "2": ShowUsersMenu(); break;
            case "3": ShowLoansMenu(); break;
            case "4": ShowSearchReportsMenu(); break;
            case "5": ShowPersistenceMenu(); break;
            case "6": ConfirmExitAndSave(); break;
            default: InvalidOption(); break;
        }
    } while (option != "6");
    
}
// ===================== 1) LIBROS =====================
void ShowBooksMenu()
{
    string option;
    do
    {
        Console.Clear();
        Console.WriteLine("===== LIBROS =====");
        Console.WriteLine("1. Registrar libro");
        Console.WriteLine("2. Listar libros");
        Console.WriteLine("3. Ver detalle de libro (ID/ISBN)");
        Console.WriteLine("4. Actualizar libro");
        Console.WriteLine("5. Eliminar libro");
        Console.WriteLine("0. Volver");
        option = ReadOption();

        switch (option)
        {
            case "1": RegisterBook(); break;
            case "2": ListBooksMenu(); break;
            case "3": ViewBookDetail(); break;
            case "4": UpdateBookMenu(); break;
            case "5": DeleteBook(); break;
            case "0": break;
            default: InvalidOption(); break;
        }
    } while (option != "0");
}

void RegisterBook()
{
    string title = ReadText("Título del libro: ");
    Console.WriteLine($"Libro registrado: \"{title}\"");
    Pause();
}

void ListBooksMenu()
{
    string option;
    do
    {
        Console.Clear();
        Console.WriteLine("===== LISTAR LIBROS =====");
        Console.WriteLine("1. Listar todos");
        Console.WriteLine("2. Listar disponibles");
        Console.WriteLine("3. Listar prestados");
        Console.WriteLine("0. Volver");
        option = ReadOption();

        switch (option)
        {
            case "1": ListBooksAll(); break;
            case "2": ListBooksAvailable(); break;
            case "3": ListBooksBorrowed(); break;
            case "0": break;
            default: InvalidOption(); break;
        }
    } while (option != "0");
}

void ListBooksAll()
{
    Console.WriteLine("Listando todos los libros...");
    Pause();
}

void ListBooksAvailable()
{
    Console.WriteLine("Listando libros disponibles...");
    Pause();
}

void ListBooksBorrowed()
{
    Console.WriteLine("Listando libros prestados...");
    Pause();
}

void ViewBookDetail()
{
    string id = ReadText("ID/ISBN del libro: ");
    Console.WriteLine($"Mostrando detalle del libro con ID/ISBN: {id}");
    Pause();
}

void UpdateBookMenu()
{
    string option;
    do
    {
        Console.Clear();
        Console.WriteLine("===== ACTUALIZAR LIBRO =====");
        Console.WriteLine("1. Editar título");
        Console.WriteLine("2. Editar autor");
        Console.WriteLine("3. Editar año / categoría");
        Console.WriteLine("0. Volver");
        option = ReadOption();

        switch (option)
        {
            case "1": EditBookTitle(); break;
            case "2": EditBookAuthor(); break;
            case "3": EditBookYearCategory(); break;
            case "0": break;
            default: InvalidOption(); break;
        }
    } while (option != "0");
}

void EditBookTitle()
{
    string newTitle = ReadText("Nuevo título: ");
    Console.WriteLine($"Título actualizado a: \"{newTitle}\"");
    Pause();
}

void EditBookAuthor()
{
    string newAuthor = ReadText("Nuevo autor: ");
    Console.WriteLine($"Autor actualizado a: \"{newAuthor}\"");
    Pause();
}

void EditBookYearCategory()
{
    string year = ReadText("Nuevo año: ");
    string category = ReadText("Nueva categoría: ");
    Console.WriteLine($"Año ({year}) y categoría ({category}) actualizados.");
    Pause();
}

void DeleteBook()
{
    string id = ReadText("ID/ISBN del libro a eliminar: ");
    Console.WriteLine("Validando que el libro no esté prestado...");
    Console.WriteLine($"Libro {id} eliminado.");
    Pause();
}
// ===================== 2) USUARIOS =====================
void ShowUsersMenu()
{
    string option;
    do
    {
        Console.Clear();
        Console.WriteLine("===== USUARIOS =====");
        Console.WriteLine("1. Registrar usuario");
        Console.WriteLine("2. Listar usuarios");
        Console.WriteLine("3. Ver detalle de usuario (ID/documento)");
        Console.WriteLine("4. Actualizar usuario");
        Console.WriteLine("5. Eliminar usuario");
        Console.WriteLine("0. Volver");
        option = ReadOption();

        switch (option)
        {
            case "1": RegisterUser(); break;
            case "2": ListUsers(); break;
            case "3": ViewUserDetail(); break;
            case "4": UpdateUserMenu(); break;
            case "5": DeleteUser(); break;
            case "0": break;
            default: InvalidOption(); break;
        }
    } while (option != "0");
}

void RegisterUser()
{
    string name = ReadText("Nombre del usuario: ");
    Console.WriteLine($"Usuario registrado: {name}");
    Pause();
}

void ListUsers()
{
    Console.WriteLine("Listando todos los usuarios...");
    Pause();
}

void ViewUserDetail()
{
    string id = ReadText("ID/documento del usuario: ");
    Console.WriteLine($"Mostrando detalle del usuario con ID/documento: {id}");
    Pause();
}

void UpdateUserMenu()
{
    string option;
    do
    {
        Console.Clear();
        Console.WriteLine("===== ACTUALIZAR USUARIO =====");
        Console.WriteLine("1. Editar nombre");
        Console.WriteLine("2. Editar contacto");
        Console.WriteLine("3. Activar / desactivar");
        Console.WriteLine("0. Volver");
        option = ReadOption();

        switch (option)
        {
            case "1": EditUserName(); break;
            case "2": EditUserContact(); break;
            case "3": ToggleUserActiveStatus(); break;
            case "0": break;
            default: InvalidOption(); break;
        }
    } while (option != "0");
}

void EditUserName()
{
    string newName = ReadText("Nuevo nombre: ");
    Console.WriteLine($"Nombre actualizado a: {newName}");
    Pause();
}

void EditUserContact()
{
    string newContact = ReadText("Nuevo contacto (teléfono/email): ");
    Console.WriteLine($"Contacto actualizado a: {newContact}");
    Pause();
}

void ToggleUserActiveStatus()
{
    string id = ReadText("ID/documento del usuario: ");
    Console.WriteLine($"Estado del usuario {id} cambiado (activo/inactivo).");
    Pause();
}

void DeleteUser()
{
    string id = ReadText("ID/documento del usuario a eliminar: ");
    Console.WriteLine("Validando que no tenga préstamos activos...");
    Console.WriteLine($"Usuario {id} eliminado.");
    Pause();
}
// ===================== 3) PRÉSTAMOS =====================
void ShowLoansMenu()
{
    string option;
    do
    {
        Console.Clear();
        Console.WriteLine("===== PRÉSTAMOS =====");
        Console.WriteLine("1. Crear préstamo");
        Console.WriteLine("2. Listar préstamos");
        Console.WriteLine("3. Ver detalle de préstamo (por ID)");
        Console.WriteLine("4. Registrar devolución");
        Console.WriteLine("5. Eliminar préstamo");
        Console.WriteLine("0. Volver");
        option = ReadOption();

        switch (option)
        {
            case "1": CreateLoan(); break;
            case "2": ListLoansMenu(); break;
            case "3": ViewLoanDetail(); break;
            case "4": RegisterReturn(); break;
            case "5": DeleteLoan(); break;
            case "0": break;
            default: InvalidOption(); break;
        }
    } while (option != "0");
}

void CreateLoan()
{
    string user = ReadText("ID/documento del usuario: ");
    string book = ReadText("ID/ISBN del libro: ");
    Console.WriteLine("Validando que el usuario exista y esté activo...");
    Console.WriteLine("Validando que el libro exista y esté disponible...");
    Console.WriteLine("Validando máximo de préstamos activos por usuario (opcional)...");
    Console.WriteLine($"Préstamo creado: libro {book} prestado al usuario {user}.");
    Pause();
}

void ListLoansMenu()
{
    string option;
    do
    {
        Console.Clear();
        Console.WriteLine("===== LISTAR PRÉSTAMOS =====");
        Console.WriteLine("1. Todos");
        Console.WriteLine("2. Activos");
        Console.WriteLine("3. Cerrados (devueltos)");
        Console.WriteLine("0. Volver");
        option = ReadOption();

        switch (option)
        {
            case "1": ListLoansAll(); break;
            case "2": ListLoansActive(); break;
            case "3": ListLoansClosed(); break;
            case "0": break;
            default: InvalidOption(); break;
        }
    } while (option != "0");
}

void ListLoansAll()
{
    Console.WriteLine("Listando todos los préstamos...");
    Pause();
}

void ListLoansActive()
{
    Console.WriteLine("Listando préstamos activos...");
    Pause();
}

void ListLoansClosed()
{
    Console.WriteLine("Listando préstamos cerrados (devueltos)...");
    Pause();
}

void ViewLoanDetail()
{
    string id = ReadText("ID del préstamo: ");
    Console.WriteLine($"Mostrando detalle del préstamo {id}");
    Pause();
}

void RegisterReturn()
{
    string id = ReadText("ID del préstamo a devolver: ");
    Console.WriteLine($"Préstamo {id} marcado como devuelto.");
    Console.WriteLine("El libro ahora está disponible.");
    Pause();
}

void DeleteLoan()
{
    string id = ReadText("ID del préstamo a eliminar: ");
    Console.WriteLine($"Préstamo {id} eliminado (si estaba activo, el libro se devuelve automáticamente).");
    Pause();
}
// ===================== 4) BÚSQUEDAS Y REPORTES =====================
void ShowSearchReportsMenu()
{
    string option;
    do
    {
        Console.Clear();
        Console.WriteLine("===== BÚSQUEDAS Y REPORTES =====");
        Console.WriteLine("1. Buscar libro");
        Console.WriteLine("2. Buscar usuario");
        Console.WriteLine("3. Reportes");
        Console.WriteLine("0. Volver");
        option = ReadOption();

        switch (option)
        {
            case "1": SearchBook(); break;
            case "2": SearchUser(); break;
            case "3": ReportsMenu(); break;
            case "0": break;
            default: InvalidOption(); break;
        }
    } while (option != "0");
}

void SearchBook()
{
    string option;
    do
    {
        Console.Clear();
        Console.WriteLine("===== BUSCAR LIBRO =====");
        Console.WriteLine("1. Por título");
        Console.WriteLine("2. Por autor");
        Console.WriteLine("3. Por ID/ISBN");
        Console.WriteLine("4. Por categoría");
        Console.WriteLine("0. Volver");
        option = ReadOption();

        switch (option)
        {
            case "1": SearchBookBy("título"); break;
            case "2": SearchBookBy("autor"); break;
            case "3": SearchBookBy("ID/ISBN"); break;
            case "4": SearchBookBy("categoría"); break;
            case "0": break;
            default: InvalidOption(); break;
        }
    } while (option != "0");
}

void SearchBookBy(string criteria)
{
    string value = ReadText($"Ingresa el {criteria} a buscar: ");
    Console.WriteLine($"Libro buscado por {criteria}: \"{value}\"");
    Console.WriteLine("Libro encontrado.");
    Pause();
}

void SearchUser()
{
    string option;
    do
    {
        Console.Clear();
        Console.WriteLine("===== BUSCAR USUARIO =====");
        Console.WriteLine("1. Por nombre");
        Console.WriteLine("2. Por ID/documento");
        Console.WriteLine("0. Volver");
        option = ReadOption();

        switch (option)
        {
            case "1": SearchUserBy("nombre"); break;
            case "2": SearchUserBy("ID/documento"); break;
            case "0": break;
            default: InvalidOption(); break;
        }
    } while (option != "0");
}

void SearchUserBy(string criteria)
{
    string value = ReadText($"Ingresa el {criteria} a buscar: ");
    Console.WriteLine($"Usuario buscado por {criteria}: \"{value}\"");
    Console.WriteLine("Usuario encontrado.");
    Pause();
}

void ReportsMenu()
{
    string option;
    do
    {
        Console.Clear();
        Console.WriteLine("===== REPORTES =====");
        Console.WriteLine("1. Préstamos por usuario");
        Console.WriteLine("2. Préstamos por libro");
        Console.WriteLine("3. Préstamos vencidos");
        Console.WriteLine("4. Resumen general");
        Console.WriteLine("0. Volver");
        option = ReadOption();

        switch (option)
        {
            case "1": ReportByUser(); break;
            case "2": ReportByBook(); break;
            case "3": ReportOverdue(); break;
            case "4": ReportSummary(); break;
            case "0": break;
            default: InvalidOption(); break;
        }
    } while (option != "0");
}

void ReportByUser()
{
    Console.WriteLine("Generando reporte de préstamos por usuario...");
    Pause();
}

void ReportByBook()
{
    Console.WriteLine("Generando reporte de préstamos por libro...");
    Pause();
}

void ReportOverdue()
{
    Console.WriteLine("Generando reporte de préstamos vencidos...");
    Pause();
}

void ReportSummary()
{
    Console.WriteLine("Resumen general: total libros / disponibles / prestados...");
    Pause();
}
// ===================== 5) GUARDAR / CARGAR DATOS =====================
void ShowPersistenceMenu()
{
    string option;
    do
    {
        Console.Clear();
        Console.WriteLine("===== GUARDAR / CARGAR DATOS =====");
        Console.WriteLine("1. Guardar datos");
        Console.WriteLine("2. Cargar datos");
        Console.WriteLine("3. Reiniciar datos (vaciar todo)");
        Console.WriteLine("0. Volver");
        option = ReadOption();

        switch (option)
        {
            case "1": SaveData(); break;
            case "2": LoadData(); break;
            case "3": ResetData(); break;
            case "0": break;
            default: InvalidOption(); break;
        }
    } while (option != "0");
}

void SaveData()
{
    Console.WriteLine("Guardando datos de libros, usuarios y préstamos...");
    Pause();
}

void LoadData()
{
    Console.WriteLine("Cargando datos de libros, usuarios y préstamos...");
    Pause();
}

bool ConfirmResetData()
{
    Console.Write("¿Seguro que deseas vaciar todos los datos? (S/N): ");
    string answer = (Console.ReadLine() ?? "").Trim().ToUpper();
    return answer == "S";
}

void ResetData()
{
    if (ConfirmResetData())
        Console.WriteLine("Datos reiniciados.");
    else
        Console.WriteLine("Operación cancelada.");
    Pause();
}