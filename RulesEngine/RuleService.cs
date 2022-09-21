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

        public static string RuntimeError(RuntimeException ex)
        {
            _hadRuntimeError = true;
            return $"{ex.Message}\n[line {ex.Token.Line:N0}]";
        }

        public static string Error(int line, string message)
        {
            return Report(line, "", message);
        }

        static string Report(int line, string where, string message)
        {
            _hadError = true;
            return $"[Line {line:N0}] Error{where}: {message}";
        }

        public static string Error(Token token, string message)
        {
            if (token.Type == TokenType.EOF)
                return Report(token.Line, " at end", message);
            else
                return Report(token.Line, $" at '{token.Lexeme}'", message);
        }
    }
}