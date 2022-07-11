namespace RulesEngine.Controllers;

using Microsoft.AspNetCore.Mvc;
using LoxSharp;

[ApiController]
[Route("[controller]")]
public class EvaluateController : ControllerBase
{
    static bool _hadError = false;
    static bool _hadRuntimeError = false;
    static readonly IOutput _output = new ConsoleOutput();
    static readonly Interpreter _interpreter = new Interpreter(_output);

    [HttpGet("validate")]
    public IActionResult ValidateInputs(string line, string parameters)
    {
        //line = "1 + 1";
        if (!line.TrimEnd().EndsWith(";"))
            line = line + ";";

        String result = Run(line, printExpressions: true);
        return Ok(result);
    }

    [HttpPost("evaluate")]
    public IActionResult EvaluateRule(string rule_uuid, string parameters)
    {
        return Ok("Evaluate, Rule: {rule_uid} Parameters: {parameters}");
    }

    // static String Run(string source, bool printExpressions = false)
    // {
    //     Scanner scanner = new Scanner(source, _output);
    //     var tokens = scanner.ScanTokens();

    //     Parser parser = new Parser(tokens, _output);
    //     var statements = parser.Parse();

    //     // Stop if there was a syntax error.
    //     if (_hadError) return "Syntax Error.";

    //     if (printExpressions && statements.Count == 1 && statements[0] is Stmt.Expression exprStmt)
    //     {
    //         statements[0] = new Stmt.Print(exprStmt.Expr);
    //     }

    //     String result = _interpreter.Interpret(statements);
    //     return result;
    // }

    static string Run(string source, bool printExpressions = false)
    {
        Scanner scanner = new Scanner(source, _output);
        var tokens = scanner.ScanTokens();

        Parser parser = new Parser(tokens, _output);
        var expression = parser.Parse();

        // Stop if there was a syntax error.
        if (_hadError) return "Error";

        // if (printExpressions && statements.Count == 1 && statements[0] is Stmt.Expression exprStmt)
        // {
        //     statements[0] = new Stmt.Print(exprStmt.Expr);
        // }

        String result = _interpreter.Interpret(expression);
        return result;
    }
}