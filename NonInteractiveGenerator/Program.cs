using System;
using TwilightShards.genLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonInteractiveGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            ///Variables
            string systemName, input;
            double systemAge;
            int numberOfStars = 0;
            bool habitableSystem = false;
            Dice d = new Dice();

            //setup console output parameters
            int charWidth = Console.BufferWidth;
            int leftFill = 50;
            
            //yet another generator.. ::sigh::
            Console.WriteLine("Welcome to the Generator!");
            Console.Write("Please enter the name of the system: ");
            systemName = Console.ReadLine();

            //Okay, so there's some interactivity.
            Console.Write("Enter Y or yes if you want to generate a habitable system: ");

            input = Console.ReadLine();
            if (input == "Y" || input == "yes" || input == "y" || input == "YES")
               habitableSystem = true;

            //start console output
            Console.WriteLine();
            Console.Write("Generating stars ".PadRight(leftFill));

            //first bit, generate age of the system and number of stars
            numberOfStars = SystemGenerator.NumberOfStars(d);
            systemAge = SystemGenerator.RollRandomAge(d, habitableSystem);

            //now generate stars

        }
    }
}
