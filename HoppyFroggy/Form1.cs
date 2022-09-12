using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;



namespace HoppyFroggy { 

    public partial class Form1 : Form
    {
        private Street _Street;
        private CrossingAnimal _Animal;
        private Rectangle _FormBorder;
        private Rectangle _SafeZone;

        public Form1()
        {
            this.DoubleBuffered = true;  // gets rid of flickering by drawing screen to buffer before displaying
            InitializeComponent();
            InitializeGame();            
        }

        private void InitializeGame()
        {
            _FormBorder = this.ClientRectangle;
            _Street = new Street(4);
            _SafeZone = new Rectangle(0, 0, _FormBorder.Width, 1);
            _Animal = new Chicken(_FormBorder);
            timer1.Start();            
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;            
            g.DrawImage(_Animal.AnimalImage, _Animal.CurrentPosition);

            Rectangle mAnimalRectangle = _Animal.GetAnimalBounds();

            foreach (Vehicle vehicle in _Street.GetVehicles())
            {
                g.DrawImage(vehicle.VechicleImage, vehicle.CurrentPosition);
                if (mAnimalRectangle.IntersectsWith(vehicle.GetVehicleBounds()))
                {
                    timer1.Stop();
                    MessageBox.Show("Collision!!!");
                    InitializeGame();
                    break;
                }
                else if(mAnimalRectangle.IntersectsWith(_SafeZone))
                {
                    timer1.Stop();
                    MessageBox.Show("You WIN!!!");
                    InitializeGame();
                    break;
                }
            }                                                        
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            _Street.MoveVehicles();
            Invalidate();
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {                       
            switch (e.KeyCode)
            {
                case Keys.Left:
                    _Animal.MoveLeft();
                    break;
                case Keys.Right:
                    _Animal.MoveRight();
                    break;
                case Keys.Up:
                    _Animal.MoveUp();
                    break;
                case Keys.Down:
                    _Animal.MoveDown();
                    break;
            }
            Invalidate();
                           
        }
    }
}
