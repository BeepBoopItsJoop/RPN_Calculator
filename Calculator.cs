namespace RpnCalculator;

public class Calculator(List<string> acceptedOperators) {
     private List<string> AcceptedOperators { get; } = acceptedOperators;

     private Stack<Token> stack = new();

     /// Receives tokens in order (e.g. 4 6 + 3 *)
     /// Pops them onto the stack starting from front (e.g. * 3 + 6 4)
     private void FillStack(List<Token> tokens) {
          tokens.ForEach(token => stack.Push(token));
     }

     public double Calculate(List<Token> tokens) {
          // put tokens into stack and calculate
          while(stack.Count > 1)
          return new double();
     }
}
