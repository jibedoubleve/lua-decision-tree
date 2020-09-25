namespace LuaDecisionTree.Interpreter
{
    public abstract class Node : INode
    {
        #region Constructors

        public Node(ILeaf onTrue, ILeaf onFalse)
        {
            OnTrue = onTrue;
            OnFalse = onFalse;
        }

        #endregion Constructors

        #region Properties

        public ILeaf OnFalse { get; }
        public ILeaf OnTrue { get; }

        #endregion Properties

        #region Methods

        public abstract Result Interpret(Context context);

        #endregion Methods
    }
}