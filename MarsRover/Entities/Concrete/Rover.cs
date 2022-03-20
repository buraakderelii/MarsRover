using MarsRover.Business.Abstract;

namespace MarsRover.Entities.Concrete
{
    public class Rover
    {
        public Rover(Location location, IDirectionService direction)
        {
            Location = location;
            Direction = direction;
        }
        public Location Location { get; set; }
        public IDirectionService Direction { get; set; }

        public override string ToString()
        {
            return Location.XCoordinate + " " + Location.YCoordinate + " " + Direction.ToString();
        }
    }
}
