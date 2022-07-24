using System.Text;
using System.Text.Json;

namespace RuleService.Parameters
{
    public class Parameters
    {
        private Dictionary<string, object> _parameters;

        public void LoadParameters(string parametersJSON)
        {
            _parameters = JsonSerializer.Deserialize<Dictionary<string, object>>(parametersJSON);
        }

        public string FindParameterValue(string key)
        {
            return _parameters.ContainsKey(key) ? _parameters[key].ToString() : throw new Exception("Invalid parameter.");
        }

        public string ConvertToLoxStatements()
        {
            StringBuilder sb = new StringBuilder();
            Console.WriteLine(_parameters);
            if(_parameters != null && _parameters.Count > 0)
            {
                foreach(var p in _parameters)
                {
                    sb.Append("var ");
                    sb.Append(p.Key);
                    sb.Append(" = ");
                    sb.Append(p.Value.ToString());
                    sb.AppendLine(";");
                }
            }
            return sb.ToString();
        }

        public bool IsNullOrEmpty() {
           return (_parameters == null || _parameters.Count < 1);
        }
    }
}