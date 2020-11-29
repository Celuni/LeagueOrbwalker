﻿using System.Text;

namespace Script
{
    public class Constantes
    {
        public const string ClientProcessName = "LeagueClientUX";

        public const string ClientHostProcessName = "LeagueClient";

        public const string GameProcessName = "League of Legends";

        public const string ClientExecutablePath = @"League of Legends\LeagueClient.exe";

        public const int HttpRequestTimeout = 10 * 1000;

        public static Encoding HttpRequestEncoding = Encoding.UTF8;

        public const string DefaultLeaguePath = @"E:\Riot Games";

        public const string ConfigPath = "config.json";

        public const string LeagueGameconfigPath = @"League of Legends\Config\game.cfg";

        public const string LeagueKeyconfigPath = @"League of Legends\Config\input.ini";

        public const string LeaguePersistedSettingsPath = @"League of Legends\Config\PersistedSettings.json";

        public const int GameWidth = 1920;

        public const int GameHeigth = 1080;

        public const int GameApiPort = 2999;
    }
}