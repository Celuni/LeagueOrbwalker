using Script.Componentes;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Script
{
    public partial class Main : Form
    {
        private GlobalKeyboardHook _globalKeyboardHook;
        private bool OrbwalkActivado = false;
        private BasicOrbwalker Orbwalker;

        public Main()
        {
            InitializeComponent();
        }

        public void InicializarKeyboardHook()
        {
            _globalKeyboardHook = new GlobalKeyboardHook();
            _globalKeyboardHook.KeyboardPressed += handlePulsarTecla;
        }

        private async void handlePulsarTecla(object sender, GlobalKeyboardHookEventArgs e)
        {
            await Task.Delay(100);

            if (e.KeyboardData.VirtualCode == Convert.ToInt32(labelTeclaIniciarDetener.Text) && e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyDown)
            {
                OrbwalkActivado = !OrbwalkActivado;
                switch (OrbwalkActivado)
                {
                    case true:
                        labelInformativo.Text = "Orbwalk iniciado.";
                        labelInformativo.ForeColor = Color.Green;
                        break;
                    case false:
                        labelInformativo.Text = "Orbwalk no iniciado.";
                        labelInformativo.ForeColor = Color.Red;
                        break;
                }

                e.Handled = true;
            }

            if (OrbwalkActivado)
            {
                if (!API.Disponible())
                    return;

                textBoxVelocidadAtaque.Text = API.obtenerVelocidadAtaque().ToString();

                float windup = Windup.Calcular(API.obtenerVelocidadAtaque());

                textBoxWindup.Text = windup.ToString();

                float total = (windup + API.obtenerVelocidadAtaque()) * 1000;

                textBoxTotalDelayTime.Text = total.ToString();

                if (e.KeyboardData.VirtualCode == Convert.ToInt32(labelTeclaEjecutarOrbwalk.Text) && e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyDown)
                {
                    BasicOrbwalker.Ejecutar(Convert.ToInt32(windup)).Wait();
                    // Scripts para campeones?

                    e.Handled = true;
                }
            }
        }
        private void Main_Load(object sender, EventArgs e)
        {
            Orbwalker = new BasicOrbwalker();
            InicializarKeyboardHook();
        }
    }
}
