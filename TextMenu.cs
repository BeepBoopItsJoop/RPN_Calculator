using RpnCalculator;

namespace RPN_Calculator;

// Menu
public class TextMenu : IMenu {
     public List<string> OperationsHelp { get; } = new() {
          "\'+\' - addition",
          "\'-\' - subtraction",
          "\'*\' - multiplication",
          "\'/\' - division",
          // "\'sqrt\'",
          "\'^\' - exponentiation", 
     };

     /// <summary>
     /// Prints the main menu to the user
     /// </summary>
     public void ShowMenu() {
          Console.WriteLine("Enter an RPN expression to evaluate.");
          Console.WriteLine("Enter 'h' for help.");
          Console.WriteLine("Enter 'o' for available operations.");
          Console.WriteLine("Enter 'q' to quit.");
     }
     /// <summary>
     /// Prints the extended help for the calculator that explains the RPN syntax
     /// </summary>
     public void ShowHelp() {
          Console.WriteLine("Enter an expression in Reverse Polish notation (RPN)");
          Console.WriteLine("e.g. 6 3 3 - + 2 *");
          Console.WriteLine("is RPN for \"(6 + (3-3)) * 2\"");
          Console.WriteLine("Enter \'o\' to see avaiable operations.");
     }
     /// <summary>
     /// Prints the help for all the operations obtained from the calculator
     /// </summary>
     public void ShowOperations() {
          
     }

     public TextMenu() {

     }
}
