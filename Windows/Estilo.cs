using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using Windows;

namespace Windows
{
    public class Estilo
    {
        private Color lilaperla = Color.FromArgb(215, 196, 240); //lila
        private Color blancoperla = Color.FromArgb(253, 250, 255); //blanco perla
        private Color rosaperla = Color.FromArgb(246, 200, 220);

        public void PintarFondo(Graphics g, Rectangle zona)
        {
            if (zona.Width == 0 || zona.Height == 0)
                return; //ventana miinimizada: no hay nada que pintar

            using (LinearGradientBrush pincel = new LinearGradientBrush(zona, lilaperla, rosaperla, LinearGradientMode.ForwardDiagonal))
            {
                ColorBlend mezcla = new ColorBlend();
                mezcla.Colors = new Color[]
                {
                    lilaperla, blancoperla, rosaperla
                };
                mezcla.Positions = new float[]
                {
                    0f, 0.5f, 1f
                };
                pincel.InterpolationColors = mezcla;

                g.FillRectangle(pincel, zona);
            }
        }
    }
}
