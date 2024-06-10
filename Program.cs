// See https://aka.ms/new-console-template for more information

using RpnCalculator;

Calculator calculator = new();
calculator.Add(new Addition());
calculator.Add(new Subtraction());
calculator.Add(new Division());
calculator.Add(new Multiplication());
calculator.Add(new SquareRoot());
calculator.Add(new Logarithm());
calculator.Add(new Constant("Pi", "pi", "The constant pi", Math.PI));
calculator.Add(new Constant("e", "e", "The constant e", Math.E));


Parser parser = new(calculator.AcceptedOperators.ToList());
TextMenu menu = new(calculator.OperationsHelpText.ToList());

Controller controller = new(calculator, parser, menu);

controller.Run();

