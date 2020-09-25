using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace LuaDecisionTree.Helpers
{
    public static class Output
    {
        #region Methods

        private static ConsoleColor GetColor(string type)
        {
            var result = (from v in Enum.GetValues(typeof(ConsoleColor)).Cast<ConsoleColor>()
                          where v.ToString().ToLower() == type.ToLower()
                          select v).Single();
            return result;
        }

        internal static void Magenta(string message) => Write(message);

        internal static void Red(string message) => Write(message);

        public static void Cyan(string messqge) => Write(messqge);

        public static void DarkMagenta(string message) => Write(message);

        public static int ReadInt()
        {
            var result = Console.ReadLine();
            if (string.IsNullOrEmpty(result)) { return default; }
            else
            {
                return (int.TryParse(result, out int number))
                    ? number
                    : default;
            }
        }

        public static void Write(string message, [CallerMemberName] string caller = null)
        {
            Console.ForegroundColor = GetColor(caller);
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void Yellow(string message) => Write(message);

        #endregion Methods
    }
}