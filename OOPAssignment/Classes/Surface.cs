using OOPAssignment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OOPAssignment.Classes
{
    public class Surface : ISurface, ICollidableSurface, Interfaces.IObserver<CarInfo>
    {
        private long _width;
        private long _height;

        private readonly List<CarInfo> ObservableCars = new();

        public Surface(long width, long height)
        {
            _width = width;
            _height = height;
        }

        public long Width
        {
            get => _width;
            set => _width = value;
        }

        public long Height
        {
            get => _height;
            set => _height = value;
        }

        public bool IsCoordinatesInBounds(Coordinates coordinates)
        {
            return coordinates.X >= 0 && coordinates.X <= Width && coordinates.Y >= 0 && coordinates.Y <= Height;
        }

        public bool IsCoordinatesEmpty(Coordinates coordinates)
        {
            var CarInfo = ObservableCars.FirstOrDefault(CarInfo => 
                CarInfo.Coordinates.X.Equals(coordinates.X) && 
                CarInfo.Coordinates.Y.Equals(coordinates.Y)); // Where && FirstOrDefault

            if (CarInfo != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Update(CarInfo provider)
        {
            var value = ObservableCars.FirstOrDefault(CarInfo => CarInfo.CarId.Equals(provider.CarId)); // Where && FirstOrDefault

            if (!IsCoordinatesInBounds(new Coordinates(provider.Coordinates.X, provider.Coordinates.Y)))
            {
                throw new Exception("Desteklenen aralığın dışında.");
            }
            else if (!IsCoordinatesEmpty(new Coordinates(provider.Coordinates.X, provider.Coordinates.Y)))
            {
                var CarInfo = ObservableCars.FirstOrDefault(CarInfo =>
                CarInfo.CarId.Equals(provider.CarId) &&
                CarInfo.Coordinates.X.Equals(provider.Coordinates.X) &&
                CarInfo.Coordinates.Y.Equals(provider.Coordinates.Y)); // Where && FirstOrDefault

                if (CarInfo == null) // Null değilse aynı id'li araç aynı yere konumlandırılmak isteniyor.
                {
                    throw new Exception("Bu konumda araç bulunuyor.");
                }
            }
            else if(value != null)
            {
                int i = ObservableCars.IndexOf(value);
                ObservableCars[i] = provider;
            }
            else
            {
                ObservableCars.Add(provider);
            }
        }

        public List<CarInfo> GetObservables()
        {
            List<CarInfo> carInfos = new();
            carInfos.AddRange(ObservableCars);

            return carInfos;
        }

	}
}