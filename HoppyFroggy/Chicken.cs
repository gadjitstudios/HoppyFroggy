using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoppyFroggy
{
    class Chicken : CrossingAnimal
    {
        public Chicken(Rectangle formBorder) : base(formBorder)
        {
            Bitmap unscaledImage = new Bitmap(Properties.Resources.Chicken);
            AnimalImage = new Bitmap(unscaledImage, new Size(unscaledImage.Width / 2, unscaledImage.Height / 2));             
            Speed = 10;

        }
    }
}