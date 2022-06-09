using MarsRover.Business.Abstract;
using MarsRover.Business.Concrete;
using MarsRover.Entities.Concrete;
using MarsRover.Utilities.Helpers;
using System;
using Xunit;

namespace MarsRover.Test
{
    public class RoverTest
    {
        [Theory]
        [InlineData(new object[] { "5 5", "1 2 N", "LMLMLMLMM", 1, 3, typeof(NorthDirectionManager) })]
        [InlineData(new object[] { "5 5", "3 3 E", "MMRMMRMRRM", 5, 1, typeof(EastDirectionManager) })]
        public void MoveRover(string plateaus, string rovers, string instructions, int expectedX, int expectedY, Type expectedDirection)
        {
            Plateau plateau = PlateauHelper.GetPlateau(plateaus.Split());
            Rover rover = RoverHelper.GetRover(rovers.Split());
            RoverHelper.ApplyInstructions(rover, instructions);

            Assert.NotNull(plateau);
            Assert.NotNull(rover);
            Assert.InRange(expectedX, plateau.FirstXCoordinate, plateau.LastXCoordinate);
            Assert.InRange(expectedY, plateau.FirstYCoordinate, plateau.LastYCoordinate);
            Assert.Equal(expectedX, rover.Location.XCoordinate);
            Assert.Equal(expectedY, rover.Location.YCoordinate);
            Assert.Equal(expectedDirection, rover.Direction.GetType());
        }
    }
}
