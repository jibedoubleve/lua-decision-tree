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

            var en = Environment.NewLine;
            var script = $"function user_script()\n{File.ReadAllText(path.Value)}\nend";

            Output.DarkMagenta("THE SCRIPT");
            Output.DarkMagenta("---------------------");
            Output.Cyan(script);

            state.DoString("import ('LuaDecisionTree', 'LuaDecisionTree.Decisions')");
            state.DoString(script);
            var result = state.DoString(@"
               status, res = pcall(user_script)
               return res
            ");

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