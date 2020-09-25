using LuaDecisionTree.Interpreter;

namespace LuaDecisionTree.Decisions
{
    public class BadResult : ILeaf
    {
        public Result Interpret(Context context)
        {
            context.ResultMessage += " That's BAD!";
            return new Result(context.ResultMessage, false);
        }
    }
}