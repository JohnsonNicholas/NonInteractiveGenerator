using System;
using TwilightShards.genLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonInteractiveGenerator
{
    public static class SystemGenerator
    {
        static double[][] stellarAge = new double[][]
        {
                new double[] {0,0,0},
                new double[] {.1,.3,.05},
                new double[] {.1,.3,.05},
                new double[] {.1,.3,.05},
                new double[] {2,.6,.1},
                new double[] {2,.6,.1},
                new double[] {2,.6,.1},
                new double[] {2,.6,.1},
                new double[] {5.6,.6,.1},
                new double[] {5.6,.6,.1},
                new double[] {5.6,.6,.1},
                new double[] {5.6,.6,.1},
                new double[] {8,.6,.1},
                new double[] {8,.6,.1},
                new double[] {8,.6,.1},
                new double[] {10,.6,.1},
        };



        public static int NumberOfStars(Dice d)
        {
            int numStars = (int)Math.Floor((d.gurpsRoll() / 3.0) - 1);

            if (numStars < 1)
                return 1;
            else if (numStars > 3)
                return 3;
            else
                return numStars;
        }

        public static double RollRandomAge(Dice d, bool habitableRoll)
        {
            //get roll
            int firstRoll = 0;
            if (!habitableRoll)
                firstRoll = d.gurpsRoll();
            else
                firstRoll = d.rng(2, 6, 2);

            firstRoll = firstRoll - 3; //make array compliant.

            //sanity check the bounds
            if (firstRoll < 0 || firstRoll > 15)
                return 3.87; //return a valid number that you won't get normally.

            // Add the initial value to the first step value (which is multiplied by 1d6-1) and then add the second step value (which is also multiplied by 1d6-1)
            return (stellarAge[firstRoll][0] + (stellarAge[firstRoll][1] * d.rng(1, 6, -1)) + (stellarAge[firstRoll][2] * d.rng(1, 6, -1)));         
        }
        
        public static double RandomStellarMass(Dice d, bool habitableRoll)
        {
            int firstRoll = 0, secondRoll = 0;

            //first roll
            if (!habitableRoll)
                firstRoll = d.gurpsRoll();
            else
            {
                switch (d.rng(1, 6))
                {
                    case 1:
                        firstRoll = 5;
                        break;
                    case 2:
                        firstRoll = 6;
                        break;
                    case 3:
                    case 4:
                        firstRoll = 7;
                        break;
                    case 5:
                    case 6:
                        firstRoll = 8;
                        break;
                    default:
                        firstRoll = 6;
                        break;
                }
            }

            //second roll
            secondRoll = d.gurpsRoll();

            switch (firstRoll)
            {
                case 0:
                    return 0;
                case 3:
                    if (secondRoll >= 3 && secondRoll <= 10)
                        return 2;
                    else
                        return 1.9;
                case 4:
                    if (secondRoll >= 3 && secondRoll <= 8)
                        return 1.8;
                    else if (secondRoll >= 9 && secondRoll <= 11)
                        return 1.7;
                    else
                        return 1.6;
                case 5:
                    if (secondRoll >= 3 && secondRoll <= 7)
                        return 1.5;
                    else if (secondRoll >= 8 && secondRoll <= 10)
                        return 1.45;
                    else if (secondRoll >= 11 && secondRoll <= 12)
                        return 1.4;
                    else
                        return 1.35;
                case 6:
                    if (secondRoll >= 3 && secondRoll <= 7)
                        return 1.3;
                    else if (secondRoll >= 8 && secondRoll <= 9)
                        return 1.25;
                    else if (secondRoll == 10)
                        return 1.2;
                    else if (secondRoll == 11 || secondRoll == 12)
                        return 1.15;
                    else
                        return 1.1;
                case 7:
                    if (secondRoll >= 3 && secondRoll <= 7)
                        return 1.05;
                    else if (secondRoll == 8 && secondRoll == 9)
                        return 1;
                    else if (secondRoll == 10)
                        return .95;
                    else if (secondRoll == 11 && secondRoll == 12)
                        return .9;
                    else
                        return .85;
                case 8:
                    if (secondRoll >= 3 && secondRoll <= 7)
                        return .8;
                    else if (secondRoll == 8 && secondRoll == 9)
                        return .75;
                    else if (secondRoll == 10)
                        return .7;
                    else if (secondRoll == 11 && secondRoll == 12)
                        return .65;
                    else
                        return .6;
                case 9:
                    if (secondRoll >= 3 && secondRoll <= 8)
                        return .55;
                    else if (secondRoll >= 9 && secondRoll <= 11)
                        return .5;
                    else
                        return .45;
                case 10:
                    if (secondRoll >= 3 && secondRoll <= 8)
                        return .4;
                    else if (secondRoll >= 9 && secondRoll <= 11)
                        return .35;
                    else
                        return .3;
                case 11:
                    return .25;
                case 12:
                    return .2;
                case 13:
                    return .15;
                default:
                    return .1;
            }
        }
        
    }
}
