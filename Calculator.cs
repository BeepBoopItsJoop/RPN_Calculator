namespace RpnCalculator;

public class Calculator() {
     private List<string> AcceptedOperators { get; } = ["+", "-", "*", "/"];

     private Stack<Token> stack = new();

     /// Receives tokens in order (e.g. 4 6 + 3 *)
     /// Pushes them onto the stack starting from front (e.g. * 3 + 6 4)
     // private void FillStack(List<Token> tokens) {
     //      if(tokens.Count == 0) 
     //           throw new ArgumentException("No tokens provided", tokens.ToString());
     //      tokens.Reverse(); // Mutates list
     //      tokens.ForEach(token => stack.Push(token));
     // }

     public double Calculate(List<Token> tokens) {
          // put tokens into stack and calculate
          tokens.ForEach(token => {
               if(token.IsOperand()) 
                    stack.Push(token);
               else {
                    // Pop two operands from stack
                    Token[] arr = [stack.Pop(), stack.Pop()];
                    // Perform operation
                         //  [0] is right operand,
                         //  [1] is left operand,
                         //  operator is this token 
                    // token.GetValue()
               }

          });
     }
}
