namespace LuaDecisionTree.Interpreter
{
    public interface INode : ILeaf
    {
        #region Properties

        ILeaf OnFalse { get; }
        ILeaf OnTrue { get; }

        #endregion Properties
    }
}