using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace HoppyFroggy
{
    static class VehicleFactory
    {

        public static Vehicle CreateVehicle()
        {         
            Random vehicleType = new Random(DateTime.Now.Millisecond);            
            switch(vehicleType.Next(1,4))
            {
                case 1: return new SedanCar();                    
                case 2: return new PickUpTruck();
                case 3: return new CompactCar();
                default: return null;                      
            }
            System.Threading.Thread.Sleep(1);
        }        
    }
}
