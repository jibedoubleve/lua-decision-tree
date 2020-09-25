using System;
using System.IO;

namespace LuaDecisionTree.Helpers
{
    public class ScriptPath
    {
        #region Fields

        private const string defaultPath = @"C:\Users\jibedoubleve\Desktop\Script.lua";
        private readonly string _path;

        #endregion Fields

        #region Constructors

        public ScriptPath(string path)
        {
            _path = path;
        }

        public string Value
        {
            get
            {
                if (string.IsNullOrEmpty(_path))
                {
                    var defautExists = File.Exists(defaultPath);
                    if (defautExists) { return defaultPath; }
                    else { throw new ArgumentException($"The script does not exist at '{defaultPath}'"); }
                }
                else if (File.Exists(_path)) { return _path; }
                else { throw new ArgumentException($"Specified path of the script '{_path}' is not valid or the file doesn not exist"); }
            }
        }
        #endregion Constructors
    }
}