using MarsRover.Entities.Concrete;
using MarsRover.Utilities.Helpers;
using System;

namespace MarsRover
{
    public class Program
    {
        static void Main(string[] args)
        {
            Plateau plateau = PlateauHelper.CreatePlateau();

            bool quit = false;
            do
            {
                Rover rover = RoverHelper.CreateRover(plateau);
                RoverHelper.MoveRover(rover);
                RoverHelper.CheckRover(rover, plateau);

                char yesno;
                do
                {
                    Console.WriteLine("Would you like to define another rover? (Y/N)");
                    yesno = Console.ReadKey(true).KeyChar;
                }
                while (yesno != 'Y' && yesno != 'y' && yesno != 'N' && yesno != 'n');

                if (yesno == 'N' || yesno == 'n')
                    quit = true;
            }
            while (!quit);
        }
    }
}
