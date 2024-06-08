// See https://aka.ms/new-console-template for more information

using RpnCalculator;

List<string> AcceptedOperators = new List<string> {"+", "-", "/", "*", "^"};
Calculator calculator = new();
Parser parser= new(AcceptedOperators);

var split = parser.Tokenize("6 2 + 5 * 8 4 / - 36 - 2 ^");
var tokens = parser.Lex(split);
var result = calculator.Calculate(tokens);
Console.WriteLine(result);
