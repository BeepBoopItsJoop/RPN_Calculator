namespace RpnCalculator;

public class Controller
{
     // TODO: Replace calc and parser
     private ICalculator _calculator;
     private IParser _parser;
     private IMenu _menu;

     // TODO: Add list of evaluators 
     // TODO: currentEvaluator

     public Controller(ICalculator calculator, IParser parser, IMenu menu)
     {
     // TODO: Replace calc and parser
          _calculator = calculator;
          _parser = parser;
     // TODO: Add list of evaluators 
     // TODO: Defualt Evaluator 
          _menu = menu;
     }

     // TODO: Add switching calculators
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
                    case "o":
                         _menu.ShowOperations();
                         break;
                    default:
                         // an RPN expression is expected here 
                         // TODO: Remove hard coded rpn here
                         try
                         {
                              var split = _parser.Tokenize(input);
                              if (split.Count != 0)
                              {
                                   var tokens = _parser.Lex(split);
                                   var result = _calculator.Calculate(tokens);
                                   Console.WriteLine($"\n {result}\n");
                              }
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
