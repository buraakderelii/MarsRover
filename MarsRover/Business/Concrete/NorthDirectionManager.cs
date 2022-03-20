using MarsRover.Business.Abstract;
using MarsRover.Entities.Concrete;

namespace MarsRover.Business.Concrete
{
    public class NorthDirectionManager : IDirectionService
    {
        public void MoveForward(Location location)
        {
            location.YCoordinate += 1;
        }

        public IDirectionService TurnLeft()
        {
            return new WestDirectionManager();
        }

        public IDirectionService TurnRight()
        {
            return new EastDirectionManager();
        }

        public override string ToString()
        {
            return "N";
        }
    }
}
