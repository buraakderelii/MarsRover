namespace MarsRover.Entities.Concrete
{
    public class Plateau
    {
        private int _FirstXCoordinate = 0;
        public int FirstXCoordinate
        {
            get { return _FirstXCoordinate; }
        }

        private int _FirstYCoordinate = 0;
        public int FirstYCoordinate
        {
            get { return _FirstYCoordinate; }
        }

        public int LastXCoordinate { get; set; }
        public int LastYCoordinate { get; set; }
    }
}
