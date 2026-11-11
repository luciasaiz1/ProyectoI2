using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Text;
using Windows;

namespace Windows
{
    public class Estilo
    {
        private Color fondo = Color.FromArgb(235, 243, 248);

        public void PintarFondo(Graphics g, Rectangle zona)
        {
            if (zona.Width == 0 || zona.Height == 0)
                return; //ventana miinimizada: no hay nada que pintar

            using (SolidBrush pincel = new SolidBrush(fondo))
            {
                g.FillRectangle(pincel, zona);
            }
        }
    }
}
