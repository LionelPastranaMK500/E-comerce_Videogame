using E_comerce_Videogame.Data;
using E_comerce_Videogame.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace E_comerce_Videogame.Controllers
{
    public class PlatformsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlatformsController(ApplicationDbContext context)
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
            string cad_sql = "EXEC sp_getAll_Platforms";
            List<Platform> platforms = _context.Platforms.FromSqlRaw(cad_sql).ToList();
            return Json(new { data = platforms });
        }

        [HttpGet]
        public JsonResult Consultar(int platformId)
        {
            string cad_sql = $"EXEC sp_getById_Platforms @PlatformId = {platformId}";
            Platform platform = _context.Platforms.FromSqlRaw(cad_sql).AsEnumerable().FirstOrDefault();
            return Json(platform);
        }

        [HttpPost]
        public IActionResult Grabar([FromBody] Platform platform)
        {
            bool rpta = true;
            try
            {
                if (platform.PlatformId == 0) // Crear
                {
                    string cad_sql = "EXEC sp_create_Platforms @Name";
                    _context.Database.ExecuteSqlRaw(cad_sql,
                        new SqlParameter("@Name", platform.Name));
                }
                else // Actualizar
                {
                    string cad_sql = "EXEC sp_update_Platforms @PlatformId, @Name";
                    _context.Database.ExecuteSqlRaw(cad_sql,
                        new SqlParameter("@PlatformId", platform.PlatformId),
                        new SqlParameter("@Name", platform.Name));
                }
            }
            catch
            {
                rpta = false;
            }
            return Json(new { resultado = rpta });
        }

        [HttpPost]
        public JsonResult Borrar(int platformId)
        {
            bool rpta = true;
            try
            {
                string cad_sql = $"EXEC sp_delete_Platforms @PlatformId = {platformId}";
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
