using System.Diagnostics.Tracing;
using System.Security.Cryptography.X509Certificates;

namespace RpnCalculator;

public class Controller
{
     private IList<IExpressionEvaluator> _expressionEvaluators;
     private IExpressionEvaluator _currentEvaluator;
     private IMenu _menu;

     public Controller(IList<IExpressionEvaluator> evaluators, IMenu menu)
     {
          _expressionEvaluators = evaluators;
          _currentEvaluator = _expressionEvaluators.First();
          _menu = menu;
          _menu.MenuHelp = _currentEvaluator.Help;
     }

     private void SwitchEvaluator(IExpressionEvaluator evaluator) {
          if (!_expressionEvaluators.Contains(evaluator)) throw new ArgumentException("Evaluator doesn't exist");

          _currentEvaluator = evaluator;
          _menu.MenuHelp = evaluator.Help; 
     }

     public void Run()
     {
          _menu.ShowMenu();

          var input = string.Empty;
          do
          {
               Console.Write("> ");
               input = Console.ReadLine() ?? "quit";
               switch (input)
               {
                    // TODO: add switching evaluator
                    case "q": break;
                    case "h":
                         _menu.ShowHelp();
                         break;
                    default:
                         // an expression is expected here 
                         try
                         {
                              Console.WriteLine($"Result is {_currentEvaluator.Evaluate(input)}");
                         } // if the input is not valid, an exception is thrown by calculator or parser 
                         // TODO: refactor exceptions 
                         catch (FormatException e)
                         {
                              Console.WriteLine(e.Message);
                         }
                         break;
               }
          } while (!input.ToLower().Equals("q")); 
          Console.WriteLine("\n Calculator is quitting. Bye!");

     }
}
