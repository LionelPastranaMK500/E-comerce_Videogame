
https://senatipe-my.sharepoint.com/:u:/g/personal/1259248_senati_pe/EaDu2Gj9FTdCiQChkSJAR8oB1F31T9WO6JmZELZiLVxjSA?e=vg5K2L

EcommerceVideogame - Documentación del Proyecto
Descripción
EcommerceVideogame es una aplicación web desarrollada para la venta de videojuegos digitales, diseñada para ofrecer a los gamers en Perú acceso a títulos populares y exclusivos. La plataforma proporciona una experiencia de compra rápida, segura y confiable, con un catálogo que incluye clásicos y los últimos lanzamientos. Este proyecto utiliza ASP.NET Core como framework principal, integrando Bootstrap para el diseño responsive, Font Awesome para íconos, y DataTables para tablas interactivas.

Estado del Proyecto
Fecha de última actualización: 25 de mayo de 2025
Versión actual: 1.0
Estado: En desarrollo activo
Características Principales
Autenticación de usuarios: Inicio de sesión y cierre de sesión con roles (Admin y usuario estándar).
Gestión de contenido: Secciones para Juegos, Categorías, Editores, Plataformas, Géneros, y Asignaciones (solo para administradores).
Interfaz de usuario: Diseño responsive con navegación dinámica basada en el estado de autenticación.
Footer personalizado: Información de contacto, enlaces a redes sociales, secciones de empresa y legal, y derechos de autor.
Estilo consistente: Uso de fuentes como Roboto, colores personalizados, y componentes de Bootstrap.
Requisitos
Entorno de desarrollo:
.NET Core SDK (versión 8.0 )
IDE como Visual Studio 2022 o Visual Studio Code
Dependencias:
Bootstrap
Font Awesome
DataTables
Boxicons
Google Fonts (Roboto)
Instalación
Clonar el Repositorio
Abre una terminal y ejecuta:
text

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=tu-servidor;Database=EcommerceVideogameDb;Trusted_Connection=True;"
  }
}

Aplica las migraciones:
text

Abre un navegador y ve a https://localhost:5001 (o el puerto asignado).
Estructura del Proyecto
Views/Shared/_Layout.cshtml: Plantilla principal que define la estructura HTML, navegación, y footer.
Views/Home/Index.cshtml: Página principal con secciones como Funcionalidades Principales, Información de la empresa, Nuestra Empresa, Nuestros Valores, y Nuestras Soluciones Digitales.
wwwroot/css/site.css: Hojas de estilo personalizadas.
wwwroot/lib/: Bibliotecas de terceros (Bootstrap, Font Awesome, etc.).
Controllers/: Lógica de controladores para manejar rutas y acciones.
Models/: Modelos de datos para la base de datos.
Data/: Contexto de Entity Framework para la base de datos.
Cambios Realizados
Actualizaciones en _Layout.cshtml
Footer: Reemplazado con contenido basado en la imagen proporcionada:
Conéctate: Íconos de Facebook, Instagram, LinkedIn, y YouTube.
Contacto: contacto@ecomerce.com y +51 987 654 321.
Empresa: "Sobre nosotros", "Nuestro equipo", "Blog".
Legal: "Política de privacidad", "Términos de servicio", "Política de cookies".
Derechos: "© 2024. Todos los derechos reservados. Desarrollado por Grupo 3".
Navegación: Incluye enlaces dinámicos según el estado de autenticación (Home, Juegos, Categorías, etc., para usuarios autenticados; solo Inicio de Sesión para no autenticados).
Actualizaciones en Views/Home/Index.cshtml
Funcionalidades Principales: Secciones para Gestión de Ventas, Control de Inventario, y Reportes Avanzados.
Información de nuestra empresa: Tarjetas con Identidad Legal, Especialización, Misión Corporativa, y Visión Estratégica.
Nuestra Empresa: Reemplazada con tarjetas de Nuestras Soluciones Digitales (Constructor Web, Facturación Fácil, Correos Corporativos, Chat Buho).
Nuestros Valores: Consolidada en una sola sección con Integridad, Servicio, Compromiso, Respeto, y Responsabilidad.
Nuestras Soluciones Digitales: Mantuvo las cuatro tarjetas originales con etiquetas "Nuevo" y "Popular".
Footer: Añadido al final con "© 2025 - EcommerceVideogame" y estilos personalizados.
Estilos Aplicados
Colores: Fondo blanco (#ffffff) para tarjetas y footer, texto gris oscuro (#333333) para consistencia.
Fuentes: Roboto (400, 500, 700) para un diseño moderno.
Componentes: Uso de Bootstrap para diseño responsive y Font Awesome para íconos.
Personalización: Añadidos márgenes, padding, y sombras para mejorar la legibilidad.
Capturas de Pantalla
(Agregar capturas de pantalla aquí cuando estén disponibles)

Página principal (/Home).
Navegación autenticada.
Footer completo.
Contribuciones
Haz un fork del repositorio.
Crea una rama para tu característica (git checkout -b feature/nueva-caracteristica).
Realiza tus cambios y haz commit (git commit -m "Descripción del cambio").
Sube tus cambios (git push origin feature/nueva-caracteristica).
Abre un Pull Request en GitHub.
Licencia
Este proyecto está bajo la licencia MIT (o especifica la licencia que desees). Todos los derechos reservados según el footer.

Contacto
Correo: andriypastrana5@gmail.com
Teléfono: +51 987 654 321
Redes sociales: Sigue los íconos en el footer para más información.
Notas Finales
Asegúrate de probar el proyecto en diferentes tamaños de pantalla para verificar la responsividad.
Si encuentras errores, revisa la consola del navegador (F12) y los logs de la aplicación.
Este README se actualizará con cada nueva funcionalidad o cambio significativo.
