namespace LuaDecisionTree.Interpreter
{
    public class Result
    {
        #region Constructors

        public Result(string message, bool isGood)
        {
            Message = message;
            IsGood = isGood;
        }

        #endregion Constructors

        #region Properties

        public bool IsGood { get; }
        public string Message { get; }

        #endregion Properties
    }
}