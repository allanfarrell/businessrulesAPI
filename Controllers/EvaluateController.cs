namespace RulesEngine.Controllers;

using Microsoft.AspNetCore.Mvc;
using RuleEngine.LoxSharp;
using RuleService.Parameters;
using Newtonsoft.Json;
using System.Text;

[ApiController]
[Route("[controller]")]
public class EvaluateController : ControllerBase
{
    [HttpGet("validate")]
    public IActionResult ValidateInputs(string line, string parameters)
    {
        Parameters param = new Parameters();
        if(ValidateKeyValuePair(parameters)) {
            param.LoadParameters(parameters);
        }
        else {
            return Ok("Invalid parameters.");
        }

        if(!line.TrimEnd().EndsWith(";"))
            line = line + ";";

        StringBuilder sb = new StringBuilder();
        sb.Append(param.ConvertToLoxStatements());
        sb.Append(line);
        
        String result = RuleService.ExecuteRule(sb.ToString(), printExpressions: true);
        
        return Ok(result);
    }

    [HttpPost("evaluate")]
    public IActionResult EvaluateRule(string rule_uuid, string parameters)
    {
        return Ok("Evaluate, Rule: {rule_uid} Parameters: {parameters}");
    }

    private Boolean ValidateKeyValuePair(string JSON)
    {
        try
        {
            Dictionary<string, object> tmpObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(JSON);
            return true;
        }
        catch (FormatException fex)
        {
            return false;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}