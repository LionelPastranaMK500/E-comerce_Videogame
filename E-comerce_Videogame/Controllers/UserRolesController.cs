using E_comerce_Videogame.Data;
using E_comerce_Videogame.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace E_comerce_Videogame.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserRolesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserRolesController(ApplicationDbContext context)
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
                // Cargar datos de UserRoles
                string cad_sql = "EXEC sp_getAll_UserRoles";
                var userRoles = _context.Set<UserRole>()
                    .FromSqlRaw(cad_sql)
                    .ToList();

                // Cargar datos de Users y Roles por separado
                var users = _context.Users.ToList();
                var roles = _context.Roles.ToList();

                // Realizar el Join en memoria
                var result = userRoles
                    .Join(users,
                        ur => ur.UserId,
                        u => u.UserId,
                        (ur, u) => new { ur.UserId, ur.RoleId, ur.AssignedAt, Email = u.Email })
                    .Join(roles,
                        ur => ur.RoleId,
                        r => r.RoleId,
                        (ur, r) => new UserRoleDTO
                        {
                            Email = ur.Email,
                            RoleName = r.Name
                        })
                    .ToList();

                return Json(new { data = result, error = (string)null });
            }
            catch (Exception ex)
            {
                return Json(new { data = new List<object>(), error = ex.Message });
            }
        }

        [HttpGet]
        public JsonResult Consultar(int userId, int roleId)
        {
            try
            {
                // Cargar datos de UserRoles
                string cad_sql = "EXEC sp_getById_UserRoles @UserId, @RoleId";
                var userRole = _context.Set<UserRole>()
                    .FromSqlRaw(cad_sql,
                        new SqlParameter("@UserId", userId),
                        new SqlParameter("@RoleId", roleId))
                    .ToList();

                // Cargar datos de Users y Roles por separado
                var users = _context.Users.ToList();
                var roles = _context.Roles.ToList();

                // Realizar el Join en memoria
                var result = userRole
                    .Join(users,
                        ur => ur.UserId,
                        u => u.UserId,
                        (ur, u) => new { ur.UserId, ur.RoleId, ur.AssignedAt, Email = u.Email })
                    .Join(roles,
                        ur => ur.RoleId,
                        r => r.RoleId,
                        (ur, r) => new UserRoleDTO
                        {
                            Email = ur.Email,
                            RoleName = r.Name
                        })
                    .FirstOrDefault();

                return Json(new { data = result, error = result == null ? "Asignación no encontrada" : null });
            }
            catch (Exception ex)
            {
                return Json(new { data = new { }, error = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult Grabar([FromBody] UserRoleRequest request)
        {
            try
            {
                if (request.UserId <= 0 || request.RoleId <= 0)
                    return Json(new { resultado = false, mensaje = "Usuario y rol son obligatorios" });

                if (request.OldUserId == 0 && request.OldRoleId == 0) // Crear
                {
                    string cad_sql = "EXEC sp_create_UserRoles @UserId, @RoleId";
                    _context.Database.ExecuteSqlRaw(cad_sql,
                        new SqlParameter("@UserId", request.UserId),
                        new SqlParameter("@RoleId", request.RoleId));
                    return Json(new { resultado = true });
                }
                else // Actualizar
                {
                    string cad_sql = "EXEC sp_update_UserRoles @OldUserId, @OldRoleId, @NewUserId, @NewRoleId";
                    _context.Database.ExecuteSqlRaw(cad_sql,
                        new SqlParameter("@OldUserId", request.OldUserId),
                        new SqlParameter("@OldRoleId", request.OldRoleId),
                        new SqlParameter("@NewUserId", request.UserId),
                        new SqlParameter("@NewRoleId", request.RoleId));
                    return Json(new { resultado = true });
                }
            }
            catch (Exception ex)
            {
                return Json(new { resultado = false, mensaje = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult Borrar(int userId, int roleId)
        {
            try
            {
                string cad_sql = "EXEC sp_delete_UserRoles @UserId, @RoleId";
                _context.Database.ExecuteSqlRaw(cad_sql,
                    new SqlParameter("@UserId", userId),
                    new SqlParameter("@RoleId", roleId));
                return Json(new { resultado = true });
            }
            catch (Exception ex)
            {
                return Json(new { resultado = false, mensaje = ex.Message });
            }
        }

        [HttpGet]
        public JsonResult GetUsers()
        {
            try
            {
                string cad_sql = "EXEC sp_getAll_Users";
                var users = _context.Users
                    .FromSqlRaw(cad_sql)
                    .AsEnumerable()
                    .Select(u => new { u.UserId, u.Email })
                    .ToList();
                return Json(new { data = users, error = (string)null });
            }
            catch (Exception ex)
            {
                return Json(new { data = new List<object>(), error = ex.Message });
            }
        }

        [HttpGet]
        public JsonResult GetRoles()
        {
            try
            {
                string cad_sql = "EXEC sp_getAll_Roles";
                var roles = _context.Roles
                    .FromSqlRaw(cad_sql)
                    .AsEnumerable()
                    .Select(r => new { r.RoleId, r.Name })
                    .ToList();
                return Json(new { data = roles, error = (string)null });
            }
            catch (Exception ex)
            {
                return Json(new { data = new List<object>(), error = ex.Message });
            }
        }
    }

    public class UserRoleDTO
    {
        public string Email { get; set; }
        public string RoleName { get; set; }
    }

    public class UserRoleRequest
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int OldUserId { get; set; }
        public int OldRoleId { get; set; }
    }
}