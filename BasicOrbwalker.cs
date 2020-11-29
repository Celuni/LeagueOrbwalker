using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Script
{
    // Basado en https://github.com/106FaceEater106/ExSharp-Base/blob/master/ExSharpBase/OrbService/Orbwalker.cs
    public class BasicOrbwalker
    {
        private static bool puedeAtacar = true;
        private static int ultimoAtaqueRealizado = 0;
        private static Point ultimoPuntoRaton;

        public static Task Ejecutar(int Windup)
        {
            int TiempoEntreAtaques = (int)(1000.0f / API.obtenerVelocidadAtaque());

            /*
                --------------------
                    Es posible lanzar un ataque.
                --------------------
             */
            if (puedeAtacar)
            {
                ultimoPuntoRaton = Cursor.Position;

                Teclado.Pulsar("A");

                Cursor.Position = ultimoPuntoRaton;

                /*
                --------------------
                    Una vez se lanza el ataque, espera a realizar el windup de la animación.
                --------------------
                */
                
                Task.Delay(Windup).Wait();

                /*
                --------------------
                    Se obtiene el tiempo para realizar el siguiente ataque.
                --------------------
                */
                ultimoAtaqueRealizado = (int)((API.obtenerTiempoPartida() * 1000) + TiempoEntreAtaques);

                puedeAtacar = false;
            }
            else
            {
                /*
                --------------------
                    Comprueba si ha pasado el tiempo suficiente para realizar otro ataque.
                --------------------
                */
                if ((API.obtenerTiempoPartida() * 1000) > ultimoAtaqueRealizado)
                {
                    //clickDerecho();
                    puedeAtacar = true;
                }
                /*
                --------------------
                    Mientras no haya pasado el tiempo suficiente para realizar otro ataque,
                    seguirá enviando ordenes de movimiento.
                --------------------
                */
                else
                {
                    ultimoPuntoRaton = Cursor.Position;
                    Raton.clickDerecho(Cursor.Position.X, Cursor.Position.Y);
                    ultimoPuntoRaton = Cursor.Position;
                }
            }

            return Task.CompletedTask;
        }
    }
}