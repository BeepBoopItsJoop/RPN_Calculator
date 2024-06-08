using RpnCalculator;

public interface IParser {
     List<string> Tokenize(string input);
     List<Token> Lex(List<string> input);
}

public interface ICalculator {
     List<string> AcceptedOperators { get; }
     double Calculate(List<Token> tokens);
}

public interface IMenu {
     List<string> OperationsHelp { get; }
     void ShowMenu();
     void ShowHelp();
     void ShowOperations();
}
