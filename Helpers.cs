using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testWoW
{
    public class Helpers
    {
        public static string GetInputFromUser(string prompt)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();
            while (string.IsNullOrEmpty(input))
            {
                Console.Write("Input can't be empty, please enter a valid value: ");
                input = Console.ReadLine();
            }
            return input.ToLower();
        }

        public static int GetIntFromUser(string prompt)
        {
            Console.Write(prompt);
            int input;
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Invalid input, please enter a valid number: ");
            }
            return input;
        }

    }
}
