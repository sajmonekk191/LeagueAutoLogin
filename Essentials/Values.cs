using System.Drawing;

namespace LeagueAutoLogin.Essentials
{
    class Values
    {
        public static string username = string.Empty;
        public static string password = string.Empty;
        public static bool autologin_data = false;
        public static bool autologin_execute = false;
        public static string LeaguePath = string.Empty;

        // Colors //
        public static Color RiotClient_Find = Color.FromArgb(23, 113, 230);
        public static Color RiotClient_MyGames = Color.FromArgb(194, 165, 99);
        public static Color RiotClient_Play = Color.FromArgb(26, 171, 212);
        // Colors //

        // Succ //
        public static bool loginSucc = false;
        public static bool mygamesSucc = false;
        public static bool playSucc = false;
        // Succ //
    }
}
