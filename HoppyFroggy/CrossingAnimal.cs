using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoppyFroggy
{
    abstract class CrossingAnimal
    {
        public short Speed { get; set; }
        protected Point _CurrentPosition;
        public Point CurrentPosition { get { return _CurrentPosition; } }
        private Rectangle _formClientRectangle;
        public Bitmap AnimalImage;

        public CrossingAnimal(Rectangle formBorder)
        {            
            _formClientRectangle = formBorder;
            _CurrentPosition = new Point(formBorder.Right / 2, formBorder.Bottom - 75);
            
        }
        public Rectangle GetAnimalBounds() { return new Rectangle(CurrentPosition, AnimalImage.Size); }

        public void MoveRight() { _CurrentPosition.X = _CurrentPosition.X + AnimalImage.Width + Speed < _formClientRectangle.Right ? _CurrentPosition.X += Speed : _CurrentPosition.X; }       
        public void MoveLeft() { _CurrentPosition.X = _CurrentPosition.X - Speed > _formClientRectangle.Left ? _CurrentPosition.X -= Speed : _CurrentPosition.X; }
        public void MoveUp() { _CurrentPosition.Y -= Speed; }
        public void MoveDown() { _CurrentPosition.Y = _CurrentPosition.Y + AnimalImage.Height + Speed < _formClientRectangle.Bottom ? _CurrentPosition.Y += Speed : _CurrentPosition.Y; }
    }
}
