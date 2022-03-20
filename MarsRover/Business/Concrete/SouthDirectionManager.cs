using MarsRover.Business.Abstract;
using MarsRover.Entities.Concrete;

namespace MarsRover.Business.Concrete
{
    public class SouthDirectionManager : IDirectionService
    {
        public void MoveForward(Location location)
        {
            location.YCoordinate -= 1;
        }

        public IDirectionService TurnLeft()
        {
            return new EastDirectionManager();
        }

        public IDirectionService TurnRight()
        {
            return new WestDirectionManager();
        }

        public override string ToString()
        {
            return "S";
        }
    }
}
