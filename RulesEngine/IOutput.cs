﻿using System;

namespace RuleEngine.LoxSharp
{
    public interface IOutput
    {
        void WriteLine(string text);
        void WriteError(string text);
    }

    public class VisitorOutput: IOutput
    {
        public void WriteError(string text)
        {
            Console.WriteLine(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }

    public class ConsoleOutput : IOutput
    {
        public void WriteError(string text)
        {
            Console.WriteLine(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
