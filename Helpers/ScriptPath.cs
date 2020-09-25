using System;
using System.IO;

namespace LuaDecisionTree.Helpers
{
    public class ScriptPath
    {
        #region Fields

        private readonly string _path;

        #endregion Fields

        #region Constructors

        public ScriptPath(string path)
        {
            _path = path;
        }

        #endregion Constructors

        #region Properties

        private string DefaultPath => Environment.ExpandEnvironmentVariables(@"%userprofile%\Desktop\Script.lua");

        public string Value
        {
            get
            {
                if (string.IsNullOrEmpty(_path))
                {
                    if (File.Exists(DefaultPath) == false)
                    {
                        using (var file = File.Create(DefaultPath))
                        using (var writer = new StreamWriter(file))
                        {
                            writer.Write(@"
    return HasText(
        BadResult(),
        IsZero(
            GoodResult(),
            IsAboveTen(
                GoodResult(),
                BadResult()
            )
        )
    )
                        ");
                            writer.Flush();
                        } 
                        Output.Yellow($"Empty script created at {DefaultPath}");
                    }
                    return DefaultPath;
                }
                else if (File.Exists(_path)) { return _path; }
                else { throw new ArgumentException($"Specified path of the script '{_path}' is not valid or the file doesn not exist"); }
            }
        }

        #endregion Properties
    }
}