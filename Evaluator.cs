using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using RpnCalculator;

public interface IExpressionEvaluator
{
     double Evaluate(string expression);

     IList<string> Help { get; }
     string Description { get; }
}

public class RPNEvaluator : IExpressionEvaluator
{
     public RPNCalculator Calculator { get; set; }
     public RPNParser Parser { get; set; }


     public RPNEvaluator(RPNCalculator calculator, RPNParser parser)
     {
          Parser = parser;
          Calculator = calculator;
          Parser.AddOperator(calculator.AcceptedOperators);
     }

     public double Evaluate(string expression)
     {
          var parsed = Parser.Tokenize(expression);
          if (parsed.Count == 0) return 0;
          var tokens = Parser.Lex(parsed);
          return Calculator.Calculate(tokens);
     }

     public IList<string> Help
     {
          get
          {
               var help = new List<string> {
                    "Enter an expression in Reverse Polish notation (RPN)",
                    "e.g. 6 3 3 - + 2 * is RPN for \"(6 + (3-3)) * 2\"",
                    "Available operations:"
               };
               help.AddRange(Calculator.OperationsHelpText);
               return help;
          }
     }

     public string Description => "Reverse Polish Notation (RPN) Calculator";
}

public class MathJSEvaluator : IExpressionEvaluator
{
     public double Evaluate(string expression)
     {
          var httpClient = new HttpClient();
          var requestUrl = $"http://api.mathjs.org/v4/?expr={Uri.EscapeDataString(expression)}";

          var response = httpClient.GetAsync(requestUrl).Result;

          if (!response.IsSuccessStatusCode)
          {
               var errorText = response.Content.ReadAsStringAsync().Result;
               throw new Exception($"API request failed: {errorText}");
          }

          // Read and parse the response content
          var text = response.Content.ReadAsStringAsync().Result;
          if (double.TryParse(text, out double result))
          {
               return result;
          }
          else
          {
               throw new Exception($"Failed to parse response: {text}");
          }
     }

     public IList<string> Help
     {
          get
          {
               var help = new List<string> {
                    "Enter an expression in standard notation using brackets",
                    "e.g. \"(6 + (3-3)) * 2\"",
               };
               return help;
          }
     }
     public string Description => "Standard syntax Calculator";
}
