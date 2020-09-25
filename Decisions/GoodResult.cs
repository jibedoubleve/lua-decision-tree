using LuaDecisionTree.Interpreter;

namespace LuaDecisionTree.Decisions
{
    public class GoodResult : ILeaf
    {
        public Result Interpret(Context context)
        {
            context.ResultMessage += " That's OK!";
            return new Result(context.ResultMessage, true);
        }
    }
}