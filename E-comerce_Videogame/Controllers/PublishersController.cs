using E_comerce_Videogame.Data;
using E_comerce_Videogame.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace E_comerce_Videogame.Controllers
{
    public class PublishersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PublishersController(ApplicationDbContext context)
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
            string cad_sql = "EXEC sp_getAll_Publishers";
            List<Publisher> publishers = _context.Publishers.FromSqlRaw(cad_sql).ToList();
            return Json(new { data = publishers });
        }

        [HttpGet]
        public JsonResult Consultar(int publisherId)
        {
            string cad_sql = $"EXEC sp_getById_Publishers @PublisherId = {publisherId}";
            Publisher publisher = _context.Publishers.FromSqlRaw(cad_sql).AsEnumerable().FirstOrDefault();
            return Json(publisher);
        }

        [HttpPost]
        public IActionResult Grabar([FromBody] Publisher publisher)
        {
            bool rpta = true;
            try
            {
                if (publisher.PublisherId == 0) // Crear
                {
                    string cad_sql = "EXEC sp_create_Publishers @Name, @Website";
                    _context.Database.ExecuteSqlRaw(cad_sql,
                        new SqlParameter("@Name", publisher.Name),
                        new SqlParameter("@Website", (object)publisher.Website ?? DBNull.Value));
                }
                else // Actualizar
                {
                    string cad_sql = "EXEC sp_update_Publishers @PublisherId, @Name, @Website";
                    _context.Database.ExecuteSqlRaw(cad_sql,
                        new SqlParameter("@PublisherId", publisher.PublisherId),
                        new SqlParameter("@Name", publisher.Name),
                        new SqlParameter("@Website", (object)publisher.Website ?? DBNull.Value));
                }
            }
            catch
            {
                rpta = false;
            }
            return Json(new { resultado = rpta });
        }

        [HttpPost]
        public JsonResult Borrar(int publisherId)
        {
            bool rpta = true;
            try
            {
                string cad_sql = $"EXEC sp_delete_Publishers @PublisherId = {publisherId}";
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
