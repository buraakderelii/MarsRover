using MarsRover.Entities.Concrete;

namespace MarsRover.Business.Abstract
{
    public interface IDirectionService
    {
        public void MoveForward(Location location);
        public IDirectionService TurnLeft();
        public IDirectionService TurnRight();        
        public string ToString();
    }
}
