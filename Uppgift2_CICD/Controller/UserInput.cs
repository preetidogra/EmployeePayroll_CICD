using System;
namespace Uppgift1_CICD.Controller
{
    public class UserInput
    {

        //checks if input is a correct given int between max and min value
        public static int IsInputInterger(int min, int max)
        {
            int parseOK;
            while (!int.TryParse(Console.ReadLine(), out parseOK) || parseOK < min || parseOK > max)
            {
                Console.WriteLine("Invalid input");
            }
            return parseOK;
        }
    }
}
