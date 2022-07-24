namespace RuleEngine.LoxSharp
{
    public class OperationLog
    {
        string _info;
        string _error;

        public string info { get { return _info; } private set {} }
        public string error { get { return _info; } private set {} }

        public OperationLog()
        {
            _info = "";
            _error = "";
        }

        public void WriteLine(string contents)
        {
            _info += contents;
            _info += "\n";
        }

        public void WriteError(string error)
        {
            _error += error;
            _error += "\n";
        }
    }
}