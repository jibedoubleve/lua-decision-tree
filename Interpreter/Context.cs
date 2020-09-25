namespace LuaDecisionTree.Interpreter
{
    public class Context
    {
        #region Constructors

        public Context(string text, int value)
        {
            Text = text;
            Value = value;
        }

        #endregion Constructors

        #region Properties

        public string ResultMessage { get; set; }
        public string Text { get; set; }
        public int Value { get; set; }

        #endregion Properties
    }
}