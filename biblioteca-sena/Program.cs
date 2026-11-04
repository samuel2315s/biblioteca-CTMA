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