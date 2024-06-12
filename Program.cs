// See https://aka.ms/new-console-template for more information

using RpnCalculator;

RPNCalculator calculator = new();
calculator.Add(new Addition());
calculator.Add(new Subtraction());
calculator.Add(new Division());
calculator.Add(new Multiplication());
calculator.Add(new SquareRoot());
calculator.Add(new Logarithm());
calculator.Add(new Constant("Pi", "pi", "The constant pi", Math.PI));
calculator.Add(new Constant("e", "e", "The constant e", Math.E));

RPNParser parser = new();
TextMenu menu = new();

RPNEvaluator evaluator = new(calculator, parser);
var evaluators = new List<IExpressionEvaluator>();
evaluators.Add(evaluator);
evaluators.Add(evaluator);

Controller controller = new(evaluators, menu);

controller.Run();

