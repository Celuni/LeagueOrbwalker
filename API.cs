using Leaf.xNet;
using Newtonsoft.Json;
using System;

namespace Script
{
    public class API
    {
        public static string ApiUrl = "https://127.0.0.1:" + Constantes.GameApiPort + "/liveclientdata";

        public static string ActivePlayerUrl = ApiUrl + "/activeplayer";

        public static string PlayerListUrl = ApiUrl + "/playerlist";

        public static string GameStatsUrl = ApiUrl + "/gamestats";

        public static bool Disponible()
        {
            try
            {
                using (HttpRequest request = new HttpRequest())
                {
                    request.CharacterSet = Constantes.HttpRequestEncoding;
                    request.IgnoreProtocolErrors = true;
                    request.ConnectTimeout = Constantes.HttpRequestTimeout;
                    request.ReadWriteTimeout = Constantes.HttpRequestTimeout;

                    var response = request.Get(PlayerListUrl);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch
            {
                return false;
            }
        }
        // ----------------------------------- // CONSULTAS A LA API
        public static bool estasMuerto()
        {
            return obtenerEstados().currentHealth == 0;
        }
        public static float obtenerVelocidadAtaque()
        {
            return obtenerEstados().attackSpeed;
        }
        public static int obtenerNivel()
        {
            var resultStr = HttpGetString(ActivePlayerUrl);
            dynamic dyn = JsonConvert.DeserializeObject(resultStr);
            return dyn.level;
        }
        public static string obtenerNombre()
        {
            var resultStr = HttpGetString(ActivePlayerUrl);
            dynamic dyn = JsonConvert.DeserializeObject(resultStr);
            return dyn.summonerName;
        }
        public static double obtenerTiempoPartida()
        {
            var resultStr = HttpGetString(GameStatsUrl);
            dynamic dyn = JsonConvert.DeserializeObject(resultStr);
            return dyn.gameTime;
        }
        public static dynamic obtenerAliado(int id)
        {
            var resultStr = HttpGetString(PlayerListUrl);
            dynamic dyn = JsonConvert.DeserializeObject(resultStr);
            return dyn[id - 1];
        }
        public static LadoMapa obtenerLadoMapa()
        {
            string playerName = obtenerNombre();

            var resultStr = HttpGetString(PlayerListUrl);

            dynamic dyn = JsonConvert.DeserializeObject(resultStr);

            foreach (var element in dyn)
            {
                if (element.summonerName == playerName)
                {
                    if (element.team == "ORDER")
                    {
                        return LadoMapa.ORDER;
                    }
                    else
                    {
                        return LadoMapa.CHAOS;
                    }
                }
            }

            return LadoMapa.DESCONOCIDO;
        }
        public static int obtenerOro()
        {
            var resultStr = HttpGetString(ActivePlayerUrl);
            dynamic dyn = JsonConvert.DeserializeObject(resultStr);
            return (int)dyn.currentGold;
        }
        public static dynamic obtenerAliados()
        {
            var resultStr = HttpGetString(PlayerListUrl);
            dynamic dyn = JsonConvert.DeserializeObject(resultStr);
            return dyn;
        }
        public static dynamic obtenerEstados()
        {
            var resultStr = HttpGetString(ActivePlayerUrl);
            dynamic dyn = JsonConvert.DeserializeObject(resultStr);
            return dyn.championStats;
        }
        // ----------------------------------- // FIN DE CONSULTAS A LA API
        public static string HttpGetString(string url)
        {
            using (HttpRequest request = new HttpRequest())
            {
                request.IgnoreProtocolErrors = true;
                request.CharacterSet = Constantes.HttpRequestEncoding;
                request.ConnectTimeout = Constantes.HttpRequestTimeout;
                request.ReadWriteTimeout = Constantes.HttpRequestTimeout;
                return request.Get(url).ToString();
            }
        }
    }
}