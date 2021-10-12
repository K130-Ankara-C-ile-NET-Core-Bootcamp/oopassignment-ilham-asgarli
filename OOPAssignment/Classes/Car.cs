
using OOPAssignment.Interfaces;
using System;

namespace OOPAssignment.Classes
{
    public class Car : ICarCommand, Interfaces.IObservable<CarInfo>
    {
        public Guid Id;
        public Coordinates Coordinates;
        public Direction Direction;
        public ISurface Surface;
        private Interfaces.IObserver<CarInfo> Observer;

        public Car(Coordinates coordinates, Direction direction, ISurface surface)
        {
            Id = Guid.NewGuid();
            Coordinates = coordinates;
            Direction = direction;
            Surface = surface;
        }

        public void TurnLeft() {
            Direction = Direction switch
            {
                Direction.N => Direction.W,
                Direction.E => Direction.N,
                Direction.S => Direction.E,
                Direction.W => Direction.S,
                _ => throw new Exception("Yön hatalı girildi."),
            };
        }

        public void TurnRight() {
            Direction = Direction switch
            {
                Direction.N => Direction.E,
                Direction.E => Direction.S,
                Direction.S => Direction.W,
                Direction.W => Direction.N,
                _ => throw new Exception("Yön hatalı girildi."),
            };
        }

        public void Move() {
            long X = Coordinates.X;
            long Y = Coordinates.Y;

            switch (Direction)
            {
                case Direction.N:
                    Y++;
                    break;
                case Direction.E:
                    X++;
                    break;
                case Direction.S:
                    Y--;
                    break;
                case Direction.W:
                    X--;
                    break;
                default:
                    throw new Exception("Yön hatalı girildi.");
            }

            Coordinates.X = X;
            Coordinates.Y = Y;

            Notify();
        }

        public void Attach(Interfaces.IObserver<CarInfo> observer) {
            Observer = observer;
            Notify();
        }

        public void Notify() {
            Observer.Update(new CarInfo(Id, new Coordinates(Coordinates.X, Coordinates.Y)));
        }
    }

    public enum Direction
    {
        N,
        E,
        S,
        W
    }

    public struct Coordinates
    {
        public long X;
        public long Y;
        public Coordinates(long x, long y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    public struct MovementFactor
    {
        public int XFactor;
        public int YFactor;
        public MovementFactor(int xFactor, int yFactor)
        {
            this.XFactor = xFactor;
            this.YFactor = yFactor;
        }
    }
}
