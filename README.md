# Sistema Web de Cartelera de Cine - Grupo 7

## Planteamiento del Problema
Un cine necesita publicar y administrar su cartelera en línea mediante una aplicación web con base de datos relacional que valide los datos antes de guardarlos, relacione cada película con su género y restrinja las modificaciones según el rol del usuario autenticado.

* **Entidad Principal:** `Genero` (`Id`, `Nombre`, `Descripcion?`)
* **Entidad Dependiente:** `Pelicula` (`Id`, `Titulo`, `Director`, `DuracionMinutos`, `GeneroId`)
* **Rol de Gestión:** `Curador` (Crea, edita y elimina géneros y películas)
* **Rol de Consulta:** `Espectador` (Solo visualiza listados y detalles)

## Integrantes y Orden de Turnos

| Turno | Integrante (GitHub) | Fases Asignadas | Aporte Principal |
| :--- | :--- | :--- | :--- |
| **1** | **Alexander Rafael Infante Sala** | Fase 1 | Proyecto inicial, repositorio, modelo dependiente `Pelicula`, CRUD y migración inicial. |
| **2** | **Jannina Viviana** (`jvpuga-espe`) | Fase 2 y Fase 3A | Validaciones en `Pelicula`, modelo principal `Genero` con validaciones y CRUD. |
| **3** | **Violeta Tapia** | Fase 3B y Fase 4A | Relación uno a muchos (`GeneroId`), lista desplegable por nombre e integración de Identity. |
| **4** | **Eliecer Mateo** | Fase 4B, Fase 5 y Autónomo | Protección con `[Authorize]`, roles `Curador`/`Espectador`, usuarios de prueba y restricción en vistas. |

*(Nota: La elaboración del informe PDF y el video de demostración se realiza de forma colaborativa entre todos los integrantes al finalizar el desarrollo).*

## Credenciales de Usuarios de Prueba

| Rol | Correo Electrónico | Contraseña | Permisos |
| :--- | :--- | :--- | :--- |
| **Curador (Gestión)** | `curador@cine.com` | `Cine2026*` | Crear, leer, editar y eliminar (`Genero` y `Pelicula`). |
| **Espectador (Consulta)** | `espectador@cine.com` | `Cine2026*` | Solo lectura (`Index` y `Details`). |

## Pasos para Ejecutar el Proyecto
1. Clonar el repositorio desde Visual Studio con **Git > Clonar repositorio**.
2. Verificar en `appsettings.json` que la cadena de conexión apunte a `localhost\SQLEXPRESS`.
3. Abrir la **Consola del Administrador de paquetes** y ejecutar `Update-Database`.
4. Compilar y ejecutar la aplicación (`F5`). Los roles y usuarios de prueba se crean automáticamente al iniciar.