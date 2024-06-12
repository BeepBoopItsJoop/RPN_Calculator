using RpnCalculator;

public interface IExpressionEvaluator {
     double Evaluate(string expression);

     IList<string> Help { get; }
     string Description { get; }
}

public class RPNEvaluator : IExpressionEvaluator {
     public RPNCalculator Calculator { get; set; }
     public RPNParser Parser { get; set; }


     public RPNEvaluator(RPNCalculator calculator, RPNParser parser) {
          Parser = parser;
          Calculator = calculator;
          Parser.AddOperator(calculator.AcceptedOperators);
     }

     public double Evaluate(string expression) {
          var parsed = Parser.Tokenize(expression);
          if (parsed.Count == 0) return 0;
          var tokens = Parser.Lex(parsed);
          return Calculator.Calculate(tokens);
     }

     public IList<string> Help { 
          get {
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

// public class MathJSEvaluator: IExpressionEvaluator {
//      public bool HasAcceptedOperations { get; } = false;
// 
//      public double Evaluate(string expression) {
//           // HttpClient is a private property of MathJSEvaluator 
//           var response = HttpClient.GetAsync(request).Result;
//           var text = task.Content.ReadAsStringAsync().Result;
//           // TODO: check the response status code and try parsing the text into a double 
//           // throw an exception with `text` as the message in case of a failure 
//           // otherwise return the parsed double
//      }

//      public IList<string> Help { 
//           get {
//                var help = new List<string> {
//                     "Enter an expression in standard notation using brackets",
//                     "e.g. \"(6 + (3-3)) * 2\"",
//                     "Enter 'o' to see available operations."
//                };
//                return help;
//           } 
//      }
//      public string Description => "Standard syntax Calculator";
// }
