using System;

namespace Ovning_Garage10.Utilities
{
    internal class UI
    {
        public static string Ask(string question)
        {
            Console.Write(question + " ");
            return Console.ReadLine();
        }

        public static int AskForInt(string question)
        {
            bool parsed;
            int retval;
            do
            {
                string answer;
                answer = UI.Ask(question);
                parsed = int.TryParse(answer, out retval);
                if (!parsed)
                {
                    Console.WriteLine($"Du får bara använda siffror i svaret. Du skrev: \"{answer}\".");
                }
            } while (!parsed);
            return retval;
        }
    }
}