using MarsRover.Entities.Concrete;
using System;

namespace MarsRover.Utilities.Helpers
{
    public static class PlateauHelper
    {
        public static Plateau CreatePlateau()
        {
            Plateau plateau = null;

            bool result = false;
            while (!result)
            {
                Console.WriteLine("Please define a plateau by entering two integers specifying the width and height.\nExample: 5 5");
                string[] plateaus = Console.ReadLine().ToUpper().Trim().Split(' ');

                try
                {
                    plateau = GetPlateau(plateaus);
                    if (plateau != null)
                        result = true;
                    else
                        Console.WriteLine("Incorrect value!");

                }
                catch (Exception)
                {
                    Console.WriteLine("Incorrect value!");
                }
            }

            return plateau;
        }

        public static Plateau GetPlateau(string[] plateaus)
        {
            Plateau plateau = null;
            if (plateaus.Length == 2)
            {
                try
                {
                    int weight = Convert.ToInt32(plateaus[0]);
                    int height = Convert.ToInt32(plateaus[1]);
                    plateau = new Plateau { LastXCoordinate = weight, LastYCoordinate = height };
                }
                catch (Exception)
                {
                    plateau = null;
                }
            }

            return plateau;
        }
    }
}
