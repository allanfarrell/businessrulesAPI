using System.Collections;

namespace RuleEngine.LoxSharp
{
    public interface ICallable
    {
        object Call(Interpreter interpreter, params object[] arguments);
        int Arity { get; }
    }
}