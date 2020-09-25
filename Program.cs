using LuaDecisionTree.Decisions;
using LuaDecisionTree.Helpers;
using LuaDecisionTree.Interpreter;
using NLua;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.WebSockets;

namespace LuaDecisionTree
{
    internal class Program
    {
        #region Methods

        private static void FromLua(Context context, string scriptPath = null)
        {

            var state = new Lua();
            state.LoadCLRPackage();
            var path = new ScriptPath(scriptPath);

            var script = File.ReadAllText(path.Value);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("THE SCRIPT");
            Console.WriteLine("---------------------");
            Console.WriteLine(script);
            Console.ResetColor();


            state.DoString("import ('LuaDecisionTree', 'LuaDecisionTree.Decisions')");
            var result = state.DoString(script);

            var item = result[0];
            if (item is ILeaf algo)
            {
                var res = algo.Interpret(context);
                Console.WriteLine($"Result is: {(res.IsGood ? "Good" : "Bad")} - {res.Message}");
            }
            else
            {
                Console.WriteLine($"Result is of type: {(item == null ? "NULL" : result[0].GetType().Name)}");
            }
        }

        private static void Main(string[] args)
        {
            Console.Write("Enter script path    : ");
            var file = Console.ReadLine();

            Console.Write("Enter a numeric value:");
            var text = int.Parse(Console.ReadLine());

            Console.Write("Enter a text         : ");
            var value = Console.ReadLine();

            FromLua(new Context(value, text), file);
        }

        #endregion Methods
    }
}