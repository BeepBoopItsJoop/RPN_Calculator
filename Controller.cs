using RpnCalculator;

public class Controller
{
     private ICalculator Calculator;
     private IParser Parser;
     private IMenu Menu;

     public Controller(ICalculator Calculator, IParser Parser, IMenu Menu)
     {
          this.Calculator = Calculator;
          this.Parser = Parser;
          this.Menu = Menu;
     }

     public void Run()
     {
          Menu.ShowMenu();

          var input = string.Empty;
          do
          {
               Console.Write("> ");
               input = Console.ReadLine() ?? "quit";
               switch (input)
               {
                    case "q": break;
                    case "h":
                         Menu.ShowHelp();
                         break;
                    case "o":
                         Menu.ShowOperations();
                         break;
                    default:
                         // an RPN expression is expected here 
                         try
                         {
                              var split = Parser.Tokenize(input);
                              if (split.Count != 0)
                              {
                                   var tokens = Parser.Lex(split);
                                   var result = Calculator.Calculate(tokens);
                                   Console.WriteLine($"\n {result}\n");
                              }
                         } // if the input is not valid, an exception is thrown by calculator or parser 
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
