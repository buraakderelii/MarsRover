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
                if (plateaus.Length == 2)
                {
                    try
                    {
                        int weight = Convert.ToInt32(plateaus[0]);
                        int height = Convert.ToInt32(plateaus[1]);
                        plateau = new Plateau { LastXCoordinate = weight, LastYCoordinate = height };
                        result = true;
                        
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Incorrect value!");
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect value!");
                }
            }

            return plateau;
        }
    }
}
