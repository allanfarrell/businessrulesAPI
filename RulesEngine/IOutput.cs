using System;
using System.Text;

namespace LoxSharp
{
    public interface IOutput
    {
        void WriteLine(string text);
        void WriteError(string text);
        string GetOutput();
        void ClearOutput();
    }

    public class ConsoleOutput : IOutput
    {
        StringBuilder _string = new StringBuilder();

        public void WriteError(string text)
        {
            _string.Append(text);
            _string.Append("\0");
            //Console.WriteLine(text);
        }

        public void WriteLine(string text)
        {
            _string.Append(text);
            _string.Append("\0");
            //Console.WriteLine(text);
        }

        public string GetOutput()
        {
            String output = _string.ToString();
            _string = new StringBuilder();
            return output;
        }

        public void ClearOutput()
        {
            _string = new StringBuilder();
        }
    }
}
