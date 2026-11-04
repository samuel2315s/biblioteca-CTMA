# Sistema de Gestión de Biblioteca en C# - Parte 1

Proyecto de consola en C# que simula un sistema de gestión de biblioteca. Esta primera parte se enfoca en la **sintaxis de C#**: menús, funciones y estructuras de control (`switch`, `do-while`, `if/else`).

## Descripción

El sistema ofrece un menú interactivo por consola para gestionar libros, usuarios y préstamos. En esta parte **todo es simulado**: cada opción solo imprime un mensaje alusivo a la acción (por ejemplo, "Libro registrado" o "Libro encontrado"). La funcionalidad real se desarrollará en la siguiente parte aplicando POO.

## Alcance de esta parte

- Todo se resuelve con **funciones**, sin clases ni programación orientada a objetos.
- **No hay base de datos** ni archivos: los datos no se guardan.
- Las acciones solo imprimen mensajes simulados.
- Todo el código va en un único archivo `Program.cs` (top-level statements).

## Requisitos

- [.NET SDK 6.0](https://dotnet.microsoft.com/download) o superior
- Terminal o consola
- Editor recomendado: Visual Studio o Visual Studio Code

## Cómo ejecutar

```bash
git clone https://github.com/samuel2315s/biblioteca-CTMA.git
cd biblioteca-CTMA
dotnet run
```

## Estructura del menú

```
Menú principal
├── 1. Libros
│   ├── Registrar libro
│   ├── Listar libros (todos / disponibles / prestados)
│   ├── Ver detalle de libro
│   ├── Actualizar libro (título / autor / año y categoría)
│   └── Eliminar libro
├── 2. Usuarios
│   ├── Registrar usuario
│   ├── Listar usuarios
│   ├── Ver detalle de usuario
│   ├── Actualizar usuario (nombre / contacto / activar-desactivar)
│   └── Eliminar usuario
├── 3. Préstamos
│   ├── Crear préstamo
│   ├── Listar préstamos (todos / activos / cerrados)
│   ├── Ver detalle de préstamo
│   ├── Registrar devolución
│   └── Eliminar préstamo
├── 4. Búsquedas y reportes
│   ├── Buscar libro (título / autor / ID-ISBN / categoría)
│   ├── Buscar usuario (nombre / ID-documento)
│   └── Reportes (por usuario / por libro / vencidos / resumen general)
├── 5. Guardar / Cargar datos
│   ├── Guardar datos
│   ├── Cargar datos
│   └── Reiniciar datos (con confirmación S/N)
└── 6. Salir (pregunta si desea guardar antes de salir)
```

## Funciones principales

| Módulo | Funciones |
|---|---|
| Menús y navegación | `ShowMainMenu`, `ShowBooksMenu`, `ShowUsersMenu`, `ShowLoansMenu`, `ShowSearchReportsMenu`, `ShowPersistenceMenu`, `ConfirmResetData`, `ConfirmExitAndSave` |
| Libros | `RegisterBook`, `ListBooksMenu`, `ListBooksAll`, `ListBooksAvailable`, `ListBooksBorrowed`, `ViewBookDetail`, `UpdateBookMenu`, `EditBookTitle`, `EditBookAuthor`, `EditBookYearCategory`, `DeleteBook` |
| Usuarios | `RegisterUser`, `ListUsers`, `ViewUserDetail`, `UpdateUserMenu`, `EditUserName`, `EditUserContact`, `ToggleUserActiveStatus`, `DeleteUser` |
| Préstamos | `CreateLoan`, `ListLoansMenu`, `ListLoansAll`, `ListLoansActive`, `ListLoansClosed`, `ViewLoanDetail`, `RegisterReturn`, `DeleteLoan` |
| Búsquedas y reportes | `SearchBook`, `SearchUser`, `ReportsMenu`, `ReportByUser`, `ReportByBook`, `ReportOverdue`, `ReportSummary` |
| Guardar / Cargar | `SaveData`, `LoadData`, `ResetData` |
| Utilidades | `ReadText`, `ReadOption`, `Pause`, `InvalidOption` |

## Ejemplo de uso

```
===== SISTEMA DE BIBLIOTECA =====
1. Libros
2. Usuarios
3. Préstamos
4. Búsquedas y reportes
5. Guardar / Cargar datos
6. Salir

Elige una opción: 1
```

Al registrar un libro, el sistema pide el título y muestra:

```
Libro registrado: "Cien años de soledad"
```

## Estrategia de ramas

Cada módulo se desarrolló en su propia rama, que luego se fusiona a `main`.

| Rama | Contenido |
|---|---|
| `feature/main-menu-navigation` | Punto de entrada, utilidades y menú principal |
| `feature/books-menu` | Menú y funciones de libros |
| `feature/users-menu` | Menú y funciones de usuarios |
| `feature/loans-menu` | Menú y funciones de préstamos |
| `feature/search-reports-menu` | Búsquedas y reportes |
| `feature/persistence-menu` | Guardar, cargar y reiniciar datos |
| `feature/exit-flow` | Confirmación al salir |
| `feature/docs-readme` | Documentación (este archivo) |

### Convención de commits

Se usa el formato `tipo: descripción en español`, por ejemplo:

```
feat: agregar menú de libros y funciones CRUD
```

## Próximos pasos

- **Parte 2:** implementar la funcionalidad real con programación orientada a objetos (clases `Libro`, `Usuario`, `Prestamo`).
- Agregar manejo de excepciones y validaciones reales.
- Implementar persistencia de datos.

## Autor

Samuel Vanegas - 3412768 / c#