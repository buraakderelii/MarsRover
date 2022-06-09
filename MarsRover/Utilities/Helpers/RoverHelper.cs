using MarsRover.Business.Abstract;
using MarsRover.Business.Concrete;
using MarsRover.Entities.Concrete;
using System;

namespace MarsRover.Utilities.Helpers
{
    public static class RoverHelper
    {
        public static Rover CreateRover(Plateau plateau)
        {
            Rover rover = null;

            bool result = false;
            while (!result)
            {
                Console.WriteLine("Please locate the rover by entering a combination of x and y coordinates and \na letter representing one of the four main compass points.\nExample: 1 2 N");
                string[] rovers = Console.ReadLine().ToUpper().Trim().Split(' ');

                try
                {
                    rover = GetRover(rovers);

                    if (rover != null)
                    {
                        if (plateau.FirstXCoordinate > rover.Location.XCoordinate || plateau.FirstYCoordinate > rover.Location.YCoordinate
                            || plateau.LastYCoordinate < rover.Location.YCoordinate || plateau.LastXCoordinate < rover.Location.XCoordinate)
                            Console.WriteLine("The rover cannot be located outside the plateau!");
                        else
                            result = true;
                    }
                    else
                        Console.WriteLine("Incorrect value!");

                }
                catch (Exception)
                {
                    Console.WriteLine("Incorrect value!");
                }
            }

            return rover;
        }

        public static Rover GetRover(string[] rovers)
        {
            Rover rover = null;

            if (rovers.Length == 3)
            {
                try
                {
                    int x = Convert.ToInt32(rovers[0]);
                    int y = Convert.ToInt32(rovers[1]);
                    string direction = rovers[2];

                    IDirectionService directionService = null;
                    switch (direction)
                    {
                        case "N":
                            directionService = new NorthDirectionManager();
                            break;
                        case "S":
                            directionService = new SouthDirectionManager();
                            break;
                        case "W":
                            directionService = new WestDirectionManager();
                            break;
                        case "E":
                            directionService = new EastDirectionManager();
                            break;
                        default:
                            break;
                    }

                    if (directionService != null)
                        rover = new Rover(new Location { XCoordinate = x, YCoordinate = y }, directionService);

                }
                catch (Exception)
                {
                    rover = null;
                }
            }

            return rover;
        }

        public static void MoveRover(Rover rover)
        {
            IDirectionService firestDirectionService = rover.Direction;
            int firstX = rover.Location.XCoordinate;
            int firstY = rover.Location.YCoordinate;

            bool result = false;
            while (!result)
            {
                Console.WriteLine("Please enter instructions that tell the rover how to explore the plateau. \nL for turn left, R for turn right and M for move forward.\nExample: LMLMLMLMM");
                string instructions = Console.ReadLine().ToUpper().Trim();
                if (instructions.Length > 0)
                {
                    try
                    {
                        ApplyInstructions(rover, instructions);

                        result = true;
                    }
                    catch (Exception)
                    {
                        rover.Direction = firestDirectionService;
                        rover.Location = new Location { XCoordinate = firstX, YCoordinate = firstY };
                        Console.WriteLine("Incorrect instruction!");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a value!");
                }
            }
        }

        public static void ApplyInstructions(Rover rover, string instructions)
        {
            foreach (char instruction in instructions)
            {
                switch (instruction)
                {
                    case 'L':
                        rover.Direction = rover.Direction.TurnLeft();
                        break;
                    case 'R':
                        rover.Direction = rover.Direction.TurnRight();
                        break;
                    case 'M':
                        rover.Direction.MoveForward(rover.Location);
                        break;
                    default:
                        throw new Exception("Incorrect instruction!");
                }
            }
        }

        public static void CheckRover(Rover rover, Plateau plateau)
        {
            Console.WriteLine("Last position of the rover: " + rover.ToString());
            if (plateau.FirstXCoordinate > rover.Location.XCoordinate || plateau.FirstYCoordinate > rover.Location.YCoordinate
                            || plateau.LastYCoordinate < rover.Location.YCoordinate || plateau.LastXCoordinate < rover.Location.XCoordinate)
                Console.WriteLine("The rover is out of the plateau!");
        }
    }
}
