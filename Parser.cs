namespace RpnCalculator;

public interface IParser
{
     List<string> Tokenize(string input);
     List<Token> Lex(List<string> input);
}

public class RPNParser : IParser {
     private readonly IList<string> _acceptedOperators;

     public RPNParser() {
          _acceptedOperators = new List<string>();
     }
     public RPNParser(IList<string> acceptedOperators) {
          _acceptedOperators = acceptedOperators;
     }

     public void AddOperator(string operatorSymbol) {
          if(!_acceptedOperators.Contains(operatorSymbol)) {
               _acceptedOperators.Add(operatorSymbol);
          }
     }
     public void AddOperator(ICollection<string> operatorSymbols) {
          // TODO: fix
          foreach(string operatorSymbol in operatorSymbols) {
               AddOperator(operatorSymbol);
          }
     }

     /// <summary>
     /// Breaks the input string into tokens
     /// </summary>
     public List<string> Tokenize(string input) {

          List<string> tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                                   .ToList();
          return tokens;
     }
     /// <summary>
     /// Converts tokens into their appropriate types and validates them
     /// </summary>
     public List<Token> Lex(List<string> input) {
          List<Token> tokens = new();

          input.ForEach(token => {
               if(double.TryParse(token, out double result)) {
                    tokens.Add(new Token(TokenType.Operand, token));
               } else if(_acceptedOperators.Contains(token)) {
                    tokens.Add(new Token(TokenType.Operator, token));
               } else {
                    throw new ArgumentException($"{token} is an invalid operator");
               }
          });

          return tokens;
     }
}
