using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HoppyFroggy
{
    class Street
    {
        public Lane[] _Lanes;
        public int MaxSpeed = 20;
        public int MinSpeed = 5;
        public int MaxSpace = 75;
        public int MinSpace = 50;
        public int SafeSpace = 75;
        public int LaneWitdth = 50;

        public Street(short numberOfLanes)
        {
            _Lanes = new Lane[numberOfLanes];
            Random mlaneSpeed = new Random(DateTime.Now.Millisecond);
            Random mlaneSpacing = new Random(DateTime.Now.Millisecond);

            for(int i = 0; i < numberOfLanes; i++)
            {
                _Lanes[i].LaneSpeed = (short)mlaneSpeed.Next(MinSpeed, MaxSpeed);
                _Lanes[i].LaneSpacing = (short)mlaneSpacing.Next(MinSpace, MaxSpace);
                _Lanes[i].LaneYPosition = SafeSpace + (LaneWitdth * i);
                _Lanes[i].Vehicles = new List<Vehicle>();                
            }
        }
        
        private void AddVehicleToLane(short lane)
        {
            Vehicle vehicle = VehicleFactory.CreateVehicle();
            vehicle.Speed = _Lanes[lane].LaneSpeed;
            vehicle.CurrentPosition.Y = _Lanes[lane].LaneYPosition;
            _Lanes[lane].Vehicles.Add(vehicle);
            _Lanes[lane].TimeUntilNextVehicle = _Lanes[lane].LaneSpacing;
        }

        public List<Vehicle> GetVehicles()
        {
            List<Vehicle> mVehicles = new List<Vehicle>();
            foreach(var lane in _Lanes)
                foreach(Vehicle vehicle in lane.Vehicles)
                    mVehicles.Add(vehicle);
            
            return mVehicles;
        }

        public void MoveVehicles()
        {
            for(short i = 0; i < _Lanes.Length; i++)
            {
                // Move all cars forward
                foreach(var vehicle in _Lanes[i].Vehicles)
                    vehicle.MoveForward();

                // Check if a new car needs to be added to a lane
                _Lanes[i].TimeUntilNextVehicle -= 1;
                if (_Lanes[i].TimeUntilNextVehicle <= 0)
                    AddVehicleToLane(i);

            }
        }
    }

    struct Lane
    {
        internal short LaneSpeed;
        internal short LaneSpacing;
        internal short TimeUntilNextVehicle;
        internal int LaneYPosition;
        internal List<Vehicle> Vehicles;

    }
}
