using LuaDecisionTree.Interpreter;

namespace LuaDecisionTree.Decisions
{
    public class IsAboveTen : Node
    {
        #region Constructors

        public IsAboveTen(ILeaf onTrue, ILeaf onFalse) : base(onTrue, onFalse)
        {
        }

        #endregion Constructors

        #region Methods

        public override Result Interpret(Context context)
        {
            context.ResultMessage += " Check above ten.";
            return context.Value > 10
                ? OnTrue.Interpret(context)
                : OnFalse.Interpret(context);
        }

        #endregion Methods
    }
}