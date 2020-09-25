using LuaDecisionTree.Helpers;
using LuaDecisionTree.Interpreter;
using NLua;
using System;
using System.IO;

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

            Output.DarkMagenta("THE SCRIPT");
            Output.DarkMagenta("---------------------");
            Output.Cyan(script);

            state.DoString("import ('LuaDecisionTree', 'LuaDecisionTree.Decisions')");
            var result = state.DoString(script);

            var item = result != null ? result[0] : null;
            if (item is ILeaf algo)
            {
                var res = algo.Interpret(context);
                Output.Magenta($"Result is: {(res.IsGood ? "Good" : "Bad")} - {res.Message}");
            }
            else
            {
                Output.Magenta($"Result is of type: {(item == null ? "NULL" : result[0].GetType().Name)}");
            }
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Enter script path  (nothing for default)   : ");
            Console.Write("> ");
            var file = Console.ReadLine();

            Console.Write("Enter a numeric value: ");
            var text = Output.ReadInt();

            Console.Write("Enter a text         : ");
            var value = Console.ReadLine();

            FromLua(new Context(value, text), file);
        }

        #endregion Methods
    }
}