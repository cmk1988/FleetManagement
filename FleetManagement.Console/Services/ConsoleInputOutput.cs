using System;

namespace FleetManagementConsole.Services
{
    public class ConsoleInputOutput : IConsoleInputOutput
    {
        public void WriteLine(string str)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void WriteError(string str)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void WriteInfo(string str)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void WriteSelected(string str)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(str);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Write(string str)
        {
            Console.Write(str);
        }

        public string ReadLine()
        {
            Console.ForegroundColor = ConsoleColor.White;
            return Console.ReadLine();
        }
    }
}
