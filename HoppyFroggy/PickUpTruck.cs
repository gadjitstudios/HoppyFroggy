using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoppyFroggy
{
    class PickUpTruck : Vehicle
    {
        public PickUpTruck()
        {
            Bitmap unscaledImage = new Bitmap(Properties.Resources.PickupTruck);
            VechicleImage = new Bitmap(unscaledImage, new Size(unscaledImage.Width / 5, unscaledImage.Height / 5));
            CurrentPosition = new Point(0, 20);
        }
    }
}
