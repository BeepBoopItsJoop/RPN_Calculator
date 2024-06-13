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
                    case "q": break;
                    case "s":
                         for(int i = 0; i < _expressionEvaluators.Count; i++) {
                              Console.WriteLine($"{i+1} - {_expressionEvaluators[i].Description}");
                         }
                         Console.WriteLine("Enter the number of the evaluator to switch to: ");
                         Console.Write("> ");
                         string? evaluatorInput = Console.ReadLine();

                         if (int.TryParse(evaluatorInput, out int choice) 
                              && choice > 0 
                              && choice <= _expressionEvaluators.Count)
                         {
                              // Switch to the chosen evaluator
                              SwitchEvaluator(_expressionEvaluators[choice - 1]);
                         }
                         break;
                    case "h":
                         _menu.ShowHelp();
                         _menu.ShowMenu();
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
