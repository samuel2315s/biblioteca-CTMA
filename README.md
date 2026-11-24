# Sistema de Biblioteca – EV08

**Evidencia:** 220501097-04-AA1 – EV08

## Descripción

Sistema de biblioteca desarrollado en C# que implementa colecciones dinámicas List<T> y una arquitectura básica por capas para gestionar libros, usuarios y préstamos.

## Estructura del proyecto

- Models: contiene las entidades Libro, Usuario, Prestamo y EstadoPrestamo.
- Services: contiene LibroService, UsuarioService y PrestamoService.
- Program.cs: contiene los menús, la interacción con el usuario y las pruebas en consola.

## Funcionalidades

- Agregar, eliminar y consultar libros.
- Registrar, consultar y desactivar usuarios.
- Registrar, consultar, eliminar y devolver préstamos.
- Búsquedas por diferentes criterios.
- Ordenación de colecciones.
- Generación de KPIs y estadísticas.
- Comparación entre arrays y listas.

## Tecnologías utilizadas

- C#
- .NET
- LINQ
- Git y Git Flow
- Visual Studio Code

## Ejecución

Desde la carpeta principal del repositorio:

`dotnet run --project biblioteca-sena`

## Git Flow

El desarrollo se realiza mediante las siguientes ramas:

- feature/services-setup
- feature/libro-service
- feature/usuario-service
- feature/prestamo-service
- feature/services-kpis
- feature/services-testing

Cada funcionalidad se desarrolla en una rama independiente y posteriormente se integra a develop.

## Conclusión

El uso de List<T> permite gestionar colecciones dinámicas de objetos. La capa Services permite separar la lógica de gestión de datos de los modelos y de la interacción con el usuario, mejorando la organización y el mantenimiento del código.