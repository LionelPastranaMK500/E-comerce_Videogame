using E_comerce_Videogame.Data;
using E_comerce_Videogame.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace E_comerce_Videogame.Controllers
{
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GamesController(ApplicationDbContext context)
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
                string cad_sql = "EXEC sp_getAll_Games";
                var games = _context.Database
                    .SqlQueryRaw<GameListDto>(cad_sql)
                    .AsEnumerable()
                    .Select(g => new
                    {
                        gameId = g.GameId,
                        title = g.Title,
                        description = g.Description ?? "",
                        releaseDate = g.ReleaseDate
                    })
                    .ToList();
                return Json(new { data = games, error = (string)null });
            }
            catch (Exception ex)
            {
                return Json(new { data = new List<object>(), error = ex.Message });
            }
        }

        [HttpGet]
        public JsonResult Consultar(int gameId)
        {
            try
            {
                string cad_sql = "EXEC sp_getById_Games @GameId";
                var game = _context.Games
                    .FromSqlRaw(cad_sql, new SqlParameter("@GameId", gameId))
                    .AsEnumerable()
                    .Select(g => new
                    {
                        gameId = g.GameId,
                        title = g.Title,
                        description = g.Description ?? "",
                        releaseDate = g.ReleaseDate,
                        categoryId = g.CategoryId,
                        categoryName = g.CategoryName ?? "",
                        publisherId = g.PublisherId,
                        publisherName = g.PublisherName ?? "",
                        genreId = g.GenreId,
                        genreName = g.GenreName ?? "",
                        createdAt = g.CreatedAt
                    })
                    .FirstOrDefault();

                return Json(new { data = game, error = game == null ? "Juego no encontrado" : null });
            }
            catch (Exception ex)
            {
                return Json(new { data = new { }, error = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult Grabar([FromBody] Game game)
        {
            try
            {
                // Depuración: Registrar el objeto recibido
                var receivedGame = new
                {
                    game.GameId,
                    game.Title,
                    game.Description,
                    game.ReleaseDate,
                    game.CategoryId,
                    game.PublisherId,
                    game.GenreId,
                    game.CreatedAt
                };
                System.Diagnostics.Debug.WriteLine($"Objeto recibido en Grabar: {System.Text.Json.JsonSerializer.Serialize(receivedGame)}");

                // Validar solo el título
                if (string.IsNullOrWhiteSpace(game.Title))
                {
                    // Depuración: Registrar errores de ModelState
                    var modelStateErrors = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage)
                        .ToList();
                    System.Diagnostics.Debug.WriteLine($"Errores de ModelState: {string.Join(", ", modelStateErrors)}");

                    return Json(new { resultado = false, mensaje = "El título es obligatorio" });
                }

                // Evitar que CreatedAt se envíe desde el cliente
                game.CreatedAt = default;

                if (game.GameId == 0) // Crear
                {
                    string cad_sql = "EXEC sp_create_Games @Title, @Description, @ReleaseDate, @CategoryId, @PublisherId, @GenreId";
                    var newGameId = _context.Database
                        .SqlQueryRaw<decimal>(cad_sql,
                            new SqlParameter("@Title", game.Title),
                            new SqlParameter("@Description", (object)game.Description ?? DBNull.Value),
                            new SqlParameter("@ReleaseDate", (object)game.ReleaseDate ?? DBNull.Value),
                            new SqlParameter("@CategoryId", (object)game.CategoryId ?? DBNull.Value),
                            new SqlParameter("@PublisherId", (object)game.PublisherId ?? DBNull.Value),
                            new SqlParameter("@GenreId", (object)game.GenreId ?? DBNull.Value))
                        .AsEnumerable()
                        .Single();
                    return Json(new { resultado = true, gameId = (int)newGameId });
                }
                else // Actualizar
                {
                    string cad_sql = "EXEC sp_update_Games @GameId, @Title, @Description, @ReleaseDate, @CategoryId, @PublisherId, @GenreId";
                    _context.Database.ExecuteSqlRaw(cad_sql,
                        new SqlParameter("@GameId", game.GameId),
                        new SqlParameter("@Title", game.Title),
                        new SqlParameter("@Description", (object)game.Description ?? DBNull.Value),
                        new SqlParameter("@ReleaseDate", (object)game.ReleaseDate ?? DBNull.Value),
                        new SqlParameter("@CategoryId", (object)game.CategoryId ?? DBNull.Value),
                        new SqlParameter("@PublisherId", (object)game.PublisherId ?? DBNull.Value),
                        new SqlParameter("@GenreId", (object)game.GenreId ?? DBNull.Value));
                    return Json(new { resultado = true });
                }
            }
            catch (Exception ex)
            {
                // Depuración: Registrar la excepción
                System.Diagnostics.Debug.WriteLine($"Excepción en Grabar: {ex.Message}");
                return Json(new { resultado = false, mensaje = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult Borrar(int gameId)
        {
            try
            {
                string cad_sql = "EXEC sp_delete_Games @GameId";
                _context.Database.ExecuteSqlRaw(cad_sql, new SqlParameter("@GameId", gameId));
                return Json(new { resultado = true });
            }
            catch (Exception ex)
            {
                return Json(new { resultado = false, mensaje = ex.Message });
            }
        }

        [HttpGet]
        public JsonResult GetCategories()
        {
            try
            {
                string cad_sql = "EXEC sp_getAll_Categories";
                var categories = _context.Categories
                    .FromSqlRaw(cad_sql)
                    .AsEnumerable()
                    .Select(c => new { c.CategoryId, c.Name, c.Description })
                    .ToList();
                return Json(new { data = categories, error = (string)null });
            }
            catch (Exception ex)
            {
                return Json(new { data = new List<object>(), error = ex.Message });
            }
        }

        [HttpGet]
        public JsonResult GetPublishers()
        {
            try
            {
                string cad_sql = "EXEC sp_getAll_Publishers";
                var publishers = _context.Publishers
                    .FromSqlRaw(cad_sql)
                    .AsEnumerable()
                    .Select(p => new { p.PublisherId, p.Name, p.Website })
                    .ToList();
                return Json(new { data = publishers, error = (string)null });
            }
            catch (Exception ex)
            {
                return Json(new { data = new List<object>(), error = ex.Message });
            }
        }

        [HttpGet]
        public JsonResult GetGenres()
        {
            try
            {
                string cad_sql = "EXEC sp_getAll_Genres";
                var genres = _context.Genres
                    .FromSqlRaw(cad_sql)
                    .AsEnumerable()
                    .Select(g => new { g.GenreId, g.Name })
                    .ToList();
                return Json(new { data = genres, error = (string)null });
            }
            catch (Exception ex)
            {
                return Json(new { data = new List<object>(), error = ex.Message });
            }
        }
    }
}