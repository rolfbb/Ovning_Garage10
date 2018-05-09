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
                    WriteLine(MessageHandler.message("onlyNumbersIsAllowed"), answer);
                }
            } while (!parsed);
            return retval;
        }

        public static void Write(string message)
        {
            Console.Write(message);
        }

        public static void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public static void WriteLine(string compositeFormat, object arg0)
        {
            Console.WriteLine(compositeFormat, arg0);
        }

        public static void WriteLine(string compositeFormat, object arg0, object arg1)
        {
            Console.WriteLine(compositeFormat, arg0, arg1);
        }

        public static void WriteLine(string compositeFormat, object arg0, object arg1, object arg2)
        {
            Console.WriteLine(compositeFormat, arg0, arg1, arg2);
        }

        public static void WriteLine(string compositeFormat, object arg0, object arg1, object arg2, object arg3)
        {
            Console.WriteLine(compositeFormat, arg0, arg1, arg2, arg3);
        }

        //
        // Console.Error...
        //
        public static void Error(string message)
        {
            Console.Error.Write(message);
        }

        public static void ErrorLine(string message)
        {
            Console.Error.WriteLine(message);
        }

        public static void ErrorLine(string compositeFormat, object arg0)
        {
            Console.Error.WriteLine(compositeFormat, arg0);
        }

        public static void ErrorLine(string compositeFormat, object arg0, object arg1)
        {
            Console.Error.WriteLine(compositeFormat, arg0, arg1);
        }

        public static void ErrorLine(string compositeFormat, object arg0, object arg1, object arg2)
        {
            Console.Error.WriteLine(compositeFormat, arg0, arg1, arg2);
        }

        public static void ErrorLine(string compositeFormat, object arg0, object arg1, object arg2, object arg3)
        {
            Console.Error.WriteLine(compositeFormat, arg0, arg1, arg2, arg3);
        }

        public static void TraceCallerInfo(string message,
        [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
        [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
        [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            Console.WriteLine("\t=== TraceCallerInfo ===");
            Console.WriteLine("\t\tmessage: " + message);
            Console.WriteLine("\t\tmember name: " + memberName);
            Console.WriteLine("\t\tsource file path: " + sourceFilePath);
            Console.WriteLine("\t\tsource line number: " + sourceLineNumber);
            Console.WriteLine("\t=== End TraceCallerInfo ===");
        }
    }
}