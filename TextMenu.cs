namespace RpnCalculator;

public interface IMenu
{
     // List<string> OperationsHelp { get; }
     IList<string> MenuHelp { get; set; }
     void ShowMenu();
     void ShowHelp();
}

public class TextMenu : IMenu {
     public IList<string> MenuHelp { get; set; }

     public TextMenu() {
          MenuHelp = new List<string>();
     }
     public TextMenu(IList<string> menuHelp) {
          MenuHelp = menuHelp;
     }

     /// <summary>
     /// Prints the main menu to the user
     /// </summary>
     public void ShowMenu() {;
          Console.WriteLine("Enter 'h' for help.");
          Console.WriteLine("Enter 's' to select a different calculator.");
          Console.WriteLine("Enter 'q' to quit.");
     }
     /// <summary>
     /// Prints the extended help for the calculator that explains the syntax
     /// </summary>
     public void ShowHelp() {
          foreach(string line in MenuHelp) {
               Console.WriteLine(line);
          }
     }
}
