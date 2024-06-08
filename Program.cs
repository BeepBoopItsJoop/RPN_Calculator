// See https://aka.ms/new-console-template for more information

using RpnCalculator;

List<string> AcceptedOperators = new List<string> {"+", "-", "/", "*", "^"};
Calculator calculator = new();
Parser parser= new(AcceptedOperators);

var bleep = parser.Tokenize("6 2 + 5 * 8 4 / - 36 - 2 ^");
var bloop = calculator.Calculate(bleep);
Console.WriteLine(bloop);
