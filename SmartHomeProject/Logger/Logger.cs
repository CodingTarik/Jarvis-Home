using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SmartHomeProject.Logger
{
    public class Logger
    {
        private const int STACK_TRACE_LINE_COUNT = 0;
        public const bool VERBOSE_LOG = true;

        public static void logInfo(string category, string message, [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string caller = null, [CallerFilePath] string path = null)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(category + " (INFO): " + message + " /// caller: " + caller + " /// line: " + lineNumber +
                              " in " + path.Split("\\").Last());
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void logError(string category, string message, Exception ex,
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string caller = null, [CallerFilePath] string path = null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(category + " (ERROR): " + message + " /// caller: " + caller + " /// line: " +
                              lineNumber + " in " + path.Split("\\").Last());
            if (VERBOSE_LOG)
                if (ex != null)
                    foreach (var stackLine in ex.StackTrace.Split("\r\n").Take(STACK_TRACE_LINE_COUNT))
                        Console.WriteLine("/// STACKTRACE : " + stackLine);

            Console.ForegroundColor = ConsoleColor.White;
        }

        public static class Category
        {
            public const string NETWORK = "NETWORK";
            public const string DEVICE_FUNCTION = "DEVICE_FUNCTION";
            public const string DEVICE_CONTROLLER = "DEVICE_CONTROLLER";
            public const string DATABASE = "DATABASE";
            public const string PYTHON = "PYTHON";
        }
    }
}