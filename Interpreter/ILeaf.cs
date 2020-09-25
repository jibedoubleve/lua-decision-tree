namespace LuaDecisionTree.Interpreter
{
    public interface ILeaf
    {
        #region Methods

        Result Interpret(Context context);

        #endregion Methods
    }
}