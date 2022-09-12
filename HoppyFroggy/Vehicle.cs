using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HoppyFroggy
{
    abstract class Vehicle
    {
        public Point CurrentPosition;
        
        public short Speed { get; set; }
        public short Lane { get; set; }

        public Bitmap VechicleImage;

        public Rectangle GetVehicleBounds() { return new Rectangle(CurrentPosition, VechicleImage.Size); }

        public void MoveForward() { CurrentPosition.X += Speed; }
    }
}
