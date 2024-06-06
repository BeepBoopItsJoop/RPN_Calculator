// See https://aka.ms/new-console-template for more information

using RpnCalculator;

Calculator calculator = new();
var ExampleTokens = new List<Token> {
     new Token(TokenType.Operand, "4"),
     new Token(TokenType.Operand, "2"),
     new Token(TokenType.Operand, "3"),
     new Token(TokenType.Operand, "5"),
     new Token(TokenType.Operand, "1"),
     new Token(TokenType.Operator, "-"),
     new Token(TokenType.Operator, "+"),
     new Token(TokenType.Operator, "*"),
     new Token(TokenType.Operator, "+"),
};
var bleep = calculator.Calculate(ExampleTokens);
;
