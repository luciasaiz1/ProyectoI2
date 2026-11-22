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
        // ATRIBUTO
        private Color fondo = Color.FromArgb(240, 240, 240);

        // CONSTRUCTOR
        public void PintarFondo(Graphics g, Rectangle zona)
        {
            if (zona.Width == 0 || zona.Height == 0)
                return; //No hay nada que pintar

            using (SolidBrush pincel = new SolidBrush(fondo))
            {
                g.FillRectangle(pincel, zona);
            }
        }
    }
}
