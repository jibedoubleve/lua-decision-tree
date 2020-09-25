using LuaDecisionTree.Interpreter;

namespace LuaDecisionTree.Decisions
{
    public class HasText : Node
    {
        #region Constructors

        public HasText(ILeaf onTrue, ILeaf onFalse) : base(onTrue, onFalse)
        {
        }

        #endregion Constructors

        #region Methods

        public override Result Interpret(Context context)
        {
            context.ResultMessage += " Check text.";
            return string.IsNullOrEmpty(context.Text)
                ? OnFalse.Interpret(context)
                : OnTrue.Interpret(context);
        }

        #endregion Methods
    }
}