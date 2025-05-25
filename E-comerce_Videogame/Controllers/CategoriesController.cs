using E_comerce_Videogame.Data;
using E_comerce_Videogame.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace E_comerce_Videogame.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
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
            try
            {
                string cad_sql = "EXEC sp_getAll_Categories";
                var categories = _context.Categories.FromSqlRaw(cad_sql).ToList();
                return Json(new { data = categories ?? new List<Category>() });
            }
            catch (Exception ex)
            {
                return Json(new { data = new List<Category>(), error = ex.Message });
            }
        }

        [HttpGet]
        public JsonResult Consultar(int categoryId)
        {
            string cad_sql = $"EXEC sp_getById_Categories @CategoryId = {categoryId}";
            Category category = _context.Categories.FromSqlRaw(cad_sql).AsEnumerable().FirstOrDefault();
            return Json(category);
        }

        [HttpPost]
        public IActionResult Grabar([FromBody] Category category)
        {
            bool rpta = true;
            try
            {
                if (category.CategoryId == 0) // Crear
                {
                    string cad_sql = "EXEC sp_create_Categories @Name, @Description";
                    _context.Database.ExecuteSqlRaw(cad_sql,
                        new SqlParameter("@Name", category.Name),
                        new SqlParameter("@Description", (object)category.Description ?? DBNull.Value));
                }
                else // Actualizar
                {
                    string cad_sql = "EXEC sp_update_Categories @CategoryId, @Name, @Description";
                    _context.Database.ExecuteSqlRaw(cad_sql,
                        new SqlParameter("@CategoryId", category.CategoryId),
                        new SqlParameter("@Name", category.Name),
                        new SqlParameter("@Description", (object)category.Description ?? DBNull.Value));
                }
            }
            catch
            {
                rpta = false;
            }
            return Json(new { resultado = rpta });
        }

        [HttpPost]
        public JsonResult Borrar(int categoryId)
        {
            bool rpta = true;
            try
            {
                string cad_sql = $"EXEC sp_delete_Categories @CategoryId = {categoryId}";
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
