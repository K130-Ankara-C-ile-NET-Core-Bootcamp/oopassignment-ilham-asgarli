
using OOPAssignment.Interfaces;
using System;

namespace OOPAssignment.Classes
{
    public class CarStringCommandExecutor : CarCommandExecutorBase, IStringCommand
    {
        private Car car;

        public CarStringCommandExecutor(Car car)
        {
            this.car = car;
        }

        public void ExecuteCommand(string commandObject)
        {
            if(commandObject == null || commandObject.Equals(""))
            {
                throw new Exception("Komut hatalı girildi.");
            }

            commandObject = commandObject.ToUpper();

            for (int i = 0; i < commandObject.Length; i++)
            {
                char command = commandObject[i];

                switch (command)
                {
                    case 'R':
                        car.TurnRight();
                        break;
                    case 'L':
                        car.TurnLeft();
                        break;
                    case 'M':
                        car.Move();
                        break;
                    default:
                        throw new Exception("Komut hatalı girildi.");
                }
            }
        }
    }
}
