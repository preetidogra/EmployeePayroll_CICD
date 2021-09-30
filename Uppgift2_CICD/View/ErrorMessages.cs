using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift1_CICD.View
{
    public class ErrorMessages
    {
        public ErrorMessages() {}
        public void ShowMessageAndClear(string message) 
            {
                Console.WriteLine(message);
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }


    }
}
