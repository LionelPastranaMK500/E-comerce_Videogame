using Microsoft.AspNetCore.Http;

namespace E_comerce_Videogame.Helpers
{
    public static class SessionHelper
    {
        public static string GetUserId(ISession session) => session.GetString("UserId");
        public static string GetUserName(ISession session) => session.GetString("UserName");
        public static string[] GetRoles(ISession session) =>
            System.Text.Json.JsonSerializer.Deserialize<string[]>(session.GetString("Roles") ?? "[]");
    }
}