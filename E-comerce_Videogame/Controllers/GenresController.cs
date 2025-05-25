using E_comerce_Videogame.Data;
using E_comerce_Videogame.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace E_comerce_Videogame.Controllers
{
    public class GenresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GenresController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Listar()
        {
            string cad_sql = "EXEC sp_getAll_Genres";
            List<Genre> genres = _context.Genres.FromSqlRaw(cad_sql).ToList();
            return Json(new { data = genres });
        }

        [HttpGet]
        public JsonResult Consultar(int genreId)
        {
            string cad_sql = $"EXEC sp_getById_Genres @GenreId = {genreId}";
            Genre genre = _context.Genres.FromSqlRaw(cad_sql).AsEnumerable().FirstOrDefault();
            return Json(genre);
        }

        [HttpPost]
        public IActionResult Grabar([FromBody] Genre genre)
        {
            bool rpta = true;
            try
            {
                if (genre.GenreId == 0) // Crear
                {
                    string cad_sql = "EXEC sp_create_Genres @Name";
                    _context.Database.ExecuteSqlRaw(cad_sql,
                        new SqlParameter("@Name", genre.Name));
                }
                else // Actualizar
                {
                    string cad_sql = "EXEC sp_update_Genres @GenreId, @Name";
                    _context.Database.ExecuteSqlRaw(cad_sql,
                        new SqlParameter("@GenreId", genre.GenreId),
                        new SqlParameter("@Name", genre.Name));
                }
            }
            catch
            {
                rpta = false;
            }
            return Json(new { resultado = rpta });
        }

        [HttpPost]
        public JsonResult Borrar(int genreId)
        {
            bool rpta = true;
            try
            {
                string cad_sql = $"EXEC sp_delete_Genres @GenreId = {genreId}";
                _context.Database.ExecuteSqlRaw(cad_sql);
            }
            catch
            {
                rpta = false;
            }
            return Json(new { resultado = rpta });
        }
    }
}
