using System;

namespace Script
{
    internal class Windup
    {
        internal static float Calcular(float VelocidadAtaque)
        {
            if (VelocidadAtaque <= 0.600f)
            {
                return 300;
            }
            if (VelocidadAtaque <= 0.700f)
            {
                return 290;
            }
            if (VelocidadAtaque <= 0.800f)
            {
                return 280;
            }
            if (VelocidadAtaque <= 0.900f)
            {
                return 255;
            }
            if (VelocidadAtaque > 0.900f && VelocidadAtaque <= 1.000f)
            {
                return 235;
            }
            if (VelocidadAtaque > 1.000f && VelocidadAtaque <= 1.100f)
            {
                return 218;
            }
            if (VelocidadAtaque > 1.100f && VelocidadAtaque <= 1.200f)
            {
                return 200;
            }
            if (VelocidadAtaque > 1.200f && VelocidadAtaque <= 1.300f)
            {
                return 196;
            }
            if (VelocidadAtaque > 1.300f && VelocidadAtaque <= 1.400f)
            {
                return 185;
            }
            if (VelocidadAtaque > 1.400f && VelocidadAtaque <= 1.500f)
            {
                return 180;
            }
            if (VelocidadAtaque > 1.500f && VelocidadAtaque <= 1.600f)
            {
                return 176;
            }
            if (VelocidadAtaque > 1.600f && VelocidadAtaque <= 1.700f)
            {
                return 158;
            }
            if (VelocidadAtaque > 1.700f && VelocidadAtaque <= 1.800f)
            {
                return 150;
            }
            if (VelocidadAtaque > 1.800f && VelocidadAtaque <= 1.900f)
            {
                return 145;
            }
            if (VelocidadAtaque > 1.900f && VelocidadAtaque <= 2.000f)
            {
                return 120;
            }
            if (VelocidadAtaque > 2.000f && VelocidadAtaque <= 2.300f)
            {
                return 118;
            }
            if (VelocidadAtaque > 2.300f && VelocidadAtaque <= 2.400f)
            {
                return 115;
            }
            if (VelocidadAtaque > 2.400f)
            {
                return 110;
            }
            // ----- WINDUP POR DEFECTO.
            return 220;
        }
    }
}