using System.ComponentModel;

namespace RpnCalculator;

public class Calculator {
     private delegate double Operation(double a, double b);

     private double Add(double a, double b) {
          return a + b;
     }
     private double Subtract(double a, double b) {
          return a - b;
     }
     private double Multiply(double a, double b) {
          return a * b;
     }
     private double Divide(double a, double b) {
          return a / b;
     }
     private double SquareRoot(double a, double b) { // Dont use b, need it to fit the delegate
          return Math.Sqrt(a);
     }
     private double Explonent(double a, double b) {
          return Math.Pow(a, b);
     }

     private Dictionary<string, Operation> Operations { get; } = new();
     public List<string> AcceptedOperators { get; } = new();
     public Calculator() {
          Operations.Add("+", Add);
          Operations.Add("-", Subtract);
          Operations.Add("*", Multiply);
          Operations.Add("/", Divide);
          // Operations.Add("sqrt", SquareRoot);
          Operations.Add("^", Explonent);

          foreach(string key in Operations.Keys) {
               AcceptedOperators.Add(key);
          } 
               
     }

     private Stack<Token> stack = new();

     public double Calculate(List<Token> tokens) {
          tokens.ForEach(token => {
               if(token.IsOperand()) 
                    stack.Push(token);
               else {
                    // Pop two operands from stack
                    Token[] arr = [stack.Pop(), stack.Pop()];
                    // Perform operation
                         //  [0] is right operand,
                         //  [1] is left operand,
                         //  token is operator.
                    double result;
                    if(Operations.TryGetValue(token.GetValue(), out Operation operation)) {
                         result = operation(arr[1].GetNumericalValue(), arr[0].GetNumericalValue());
                    } else {
                         throw new InvalidEnumArgumentException($"Invalid operator {token.GetValue()} supplied as token");
                    }
                    // push result of operation to stack
                    stack.Push(new Token(TokenType.Operand, result.ToString()));
               }
          });
          // stack only has answer left
          return stack.Pop().GetNumericalValue();
     }
}
