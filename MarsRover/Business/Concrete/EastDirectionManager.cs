using MarsRover.Business.Abstract;
using MarsRover.Entities.Concrete;

namespace MarsRover.Business.Concrete
{
    public class EastDirectionManager : IDirectionService
    {
        public void MoveForward(Location location)
        {
            location.XCoordinate += 1;
        }

        public IDirectionService TurnLeft()
        {
            return new NorthDirectionManager();
        }

        public IDirectionService TurnRight()
        {
            return new SouthDirectionManager();
        }

        public override string ToString()
        {
            return "E";
        }
    }
}
