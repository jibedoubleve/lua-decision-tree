using LuaDecisionTree.Interpreter;

namespace LuaDecisionTree.Decisions
{
    public class IsZero : Node
    {
        #region Constructors

        public IsZero(ILeaf onTrue, ILeaf onFalse) : base(onTrue, onFalse)
        {
        }

        #endregion Constructors

        #region Methods

        public override Result Interpret(Context context)
        {
            context.ResultMessage += " Check if zero.";
            return (context.Value == 0)
                ? OnTrue.Interpret(context)
                : OnFalse.Interpret(context);
        }

        #endregion Methods
    }
}