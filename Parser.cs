namespace RpnCalculator;

public interface IParser
{
     List<string> Tokenize(string input);
     List<Token> Lex(List<string> input);
}

public class Parser : IParser {
     private readonly IList<string> _acceptedOperators;

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

     public Parser(IList<string> acceptedOperators) {
          _acceptedOperators = acceptedOperators;
     }
}
