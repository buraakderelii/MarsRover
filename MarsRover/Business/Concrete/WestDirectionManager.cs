using MarsRover.Business.Abstract;
using MarsRover.Entities.Concrete;

namespace MarsRover.Business.Concrete
{
    public class WestDirectionManager : IDirectionService
    {
        public void MoveForward(Location location)
        {
            location.XCoordinate -= 1;
        }

        public IDirectionService TurnLeft()
        {
            return new SouthDirectionManager();
        }

        public IDirectionService TurnRight()
        {
            return new NorthDirectionManager();
        }

        public override string ToString()
        {
            return "W";
        }
    }
}
