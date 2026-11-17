# Sistema Web de Cartelera de Cine - Grupo 7

## Planteamiento del Problema
Un cine necesita publicar y administrar su cartelera en línea validando los datos antes de guardarlos, relacionando cada película con su género y restringiendo las modificaciones según el rol del usuario.

* **Entidad Principal:** Genero (Id, Nombre, Descripcion?)
* **Entidad Dependiente:** Pelicula (Id, Titulo, Director, DuracionMinutos, GeneroId)
* **Rol de Gestión:** Curador
* **Rol de Consulta:** Espectador

## Integrantes y Orden de Turnos
1. **Alexander Rafael Infante Sala:** Fase 1 (Proyecto inicial, repositorio, modelo dependiente Pelicula y CRUD).
2. **Violeta Tapia:** Fase 2 y Fase 3 (Validaciones de Pelicula, modelo principal Genero y CRUD).
3. **Eliecer Mateo:** Fase 3 y Fase 4 (Relación uno a muchos, lista desplegable y agregar Identity).
4. **Vivi:** Fase 4 y Fase 5 (Protección con Authorize, creación de roles Curador/Espectador y restricción en vistas).

## Credenciales de Usuarios de Prueba
| Rol | Correo Electrónico | Contraseña |
| :--- | :--- | :--- |
| **Curador (Gestión)** | curador@cine.com | Cine2026* |
| **Espectador (Consulta)** | espectador@cine.com | Cine2026* |

## Pasos para Ejecutar el Proyecto
1. Clonar el repositorio desde Visual Studio con `Git > Clonar repositorio`.
2. Verificar en `appsettings.json` que el servidor apunte a `localhost\SQLEXPRESS`.
3. Abrir la Consola del Administrador de paquetes y ejecutar `Update-Database`.
4. Compilar y ejecutar la aplicación.