using System.ComponentModel;

namespace RpnCalculator;

// Validator
// Parser
public class Parser {
     List<string> AcceptedOperators = new();

     /// <summary>
     /// Breaks the input string into tokens
     /// </summary>
     public List<Token> Tokenize(string input) {

          List<string> tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                                   .ToList();
          return Lex(tokens);
     }
     /// <summary>
     /// Converts tokens into their appropriate types and validates them
     /// </summary>
     private List<Token> Lex(List<string> input) {
          List<Token> tokens = new();

          input.ForEach(token => {
               if(double.TryParse(token, out double result)) {
                    tokens.Add(new Token(TokenType.Operand, token));
               } else if(AcceptedOperators.Contains(token)) {
                    tokens.Add(new Token(TokenType.Operator, token));
               } else {
                    throw new ArgumentException($"{token} is an invalid operator");
               }
          });

          return tokens;
     }

     public Parser(List<string> AcceptedOperators) {
          this.AcceptedOperators = AcceptedOperators;
     }
}
