namespace RulesEngine.LoxSharp
{
    public class RulesetEvaluation
    {
        ICollection<RuleEvaluation> rules;
    }

    public class RuleEvaluation
    {
        ICollection<ExpressionEvaluation> expressions;
    }

    public class ExpressionEvaluation
    {
        string expression;
        string result;
        ICollection<string> parameters;
    }
}

