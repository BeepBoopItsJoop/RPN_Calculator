namespace RpnCalculator;

public interface ICalculator
{
     public IList<string> AcceptedOperators { get; }
     public IList<string> OperationsHelpText { get; }
     double Calculate(List<Token> tokens);
}

public class RPNCalculator : ICalculator
     {
     // "+" -> Addition
     private Dictionary<string, IOperation> _operations;

     public IList<string> AcceptedOperators { 
          get {
               return _operations.Keys.ToList();
          }
     }
     public IList<string> OperationsHelpText { 
          get {
               return _operations.Select(op => $"{op.Key}: {op.Value.Description}").ToList();
          }
     }
     public RPNCalculator() {
          _operations = [];
     }

     public void Add(IOperation operation) {
          _operations.Add(operation.Operator, operation);
     }

     private Stack<Token> stack = new();

     public double Calculate(List<Token> tokens) {
          tokens.ForEach(token => {
               if(token.IsOperand()) 
                    stack.Push(token);
               else {
                    if(_operations.TryGetValue(token.GetValue(), out IOperation? operation)) {
                         double result;

                         if(operation is IBinaryOperation binaryOperation) {
                              // For binary operation, pop two operands from the stack
                              double rhs = stack.Pop().GetNumericalValue();
                              double lhs = stack.Pop().GetNumericalValue();

                              result = binaryOperation.Calculate(lhs, rhs);
                         }
                         else if (operation is IUnaryOperation unaryOperation) {
                              // For unary operation, pop one operand from the stack
                              double num = stack.Pop().GetNumericalValue();

                              result = unaryOperation.Calculate(num);
                         }
                         else if (operation is INullaryOperation nullaryOperation) {
                              // For constants, push the value onto the stack
                              result = nullaryOperation.Value;
                         } else
                         {
                              throw new InvalidOperationException($"Invalid operation type for operator {token.GetValue()}");
                         }

                         stack.Push(new Token(TokenType.Operand, result.ToString()));
                    } else {
                         throw new ArgumentException($"Invalid operator {token.GetValue()} supplied as token");
                    }
               }
          });
          // stack only has answer left
          return stack.Pop().GetNumericalValue();
     }
}
