using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoppyFroggy
{
    class CompactCar : Vehicle
    {
        public CompactCar()
        {
            Bitmap unscaledImage = new Bitmap(Properties.Resources.CompactCar);
            VechicleImage = new Bitmap(unscaledImage, new Size(unscaledImage.Width / 5, unscaledImage.Height / 5));
            CurrentPosition = new Point(0, 20);
        }
    }
}
