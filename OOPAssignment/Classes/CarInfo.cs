
using System;

namespace OOPAssignment.Classes
{
    public class CarInfo
    {
        public Guid CarId;
        public Coordinates Coordinates;

        public CarInfo(Guid carId, Coordinates coordinates)
        {
            CarId = carId;
            Coordinates = coordinates;
        }
    }
}
