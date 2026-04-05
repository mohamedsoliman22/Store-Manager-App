using System;

namespace StoreManagerApp
{
    public static class UserSession
    {
        public static UserInfo CurrentUser { get; set; }

        public static bool IsLoggedIn => CurrentUser != null;
        public static bool IsAdmin => CurrentUser?.IsAdmin ?? false;
    }

    public class UserInfo
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public bool IsAdmin { get; set; }
    }
} 