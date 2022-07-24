namespace RuleEngine.LoxSharp
{
    public static class RuleService
    {
        static bool _hadError = false;
        static bool _hadRuntimeError = false;
        static readonly IOutput _output = new ConsoleOutput();
        static readonly Interpreter _interpreter = new Interpreter();

        public static string ExecuteRule(string source, bool printExpressions = false)
        {
            Scanner scanner = new Scanner(source, _output);
            var tokens = scanner.ScanTokens();

            Parser parser = new Parser(tokens, _output);
            var expression = parser.Parse();

            // Stop if there was a syntax error.
            if (_hadError) return "Error";

            OperationLog log = _interpreter.Interpret(expression);
            return string.IsNullOrEmpty(log.error) ? log.info : log.error;
        }
        
        public static string EvaluateRuleSyntax(string source, bool printExpressions = false)
        {
            // Substitute in values?
            // Capture result
            // Check for errors
            // Return pass/fail message.
            return "EvaluateRuleSyntax";
        }
    }
}