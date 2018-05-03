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

        public static void TraceMessage(string message,
        [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
        [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
        [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            Console.WriteLine("\t=== TraceMessage ===");
            Console.WriteLine("\t\tmessage: " + message);
            Console.WriteLine("\t\tmember name: " + memberName);
            Console.WriteLine("\t\tsource file path: " + sourceFilePath);
            Console.WriteLine("\t\tsource line number: " + sourceLineNumber);
            Console.WriteLine("\t=== End TraceMessage ===");
        }
    }
}