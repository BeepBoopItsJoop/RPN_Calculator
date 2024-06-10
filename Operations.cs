namespace RpnCalculator;

public interface IOperation {
     string Name { get; }    
     string Operator { get; }    
     string Description { get; }    
}
public interface IBinaryOperation : IOperation {
    double Calculate(double lhs, double rhs);
}
public interface IUnaryOperation : IOperation {
    double Calculate(double num);
}
public interface INullaryOperation : IOperation {
    public double Value { get; }
}

public class Operation : IOperation {
     public string Name { get; }    
     public string Operator { get; }    
     public string Description { get; }  

     public Operation(string Name, string Operator, string Description) {
          this.Name = Name;
          this.Operator = Operator;
          this.Description = Description;
     }
}

public class Constant : Operation, INullaryOperation {
     public double Value { get; }
          public Constant(string name, string operatorSymbol, string description, double value) :
          base(name, operatorSymbol, description)
          {
               Value = value;
          } 
}

public class SquareRoot : Operation, IUnaryOperation {
     public SquareRoot() :
          base("Square Root", "sqrt", "Calculates the square root of a number") 
          {} 
     public double Calculate(double num) {
          return Math.Sqrt(num);
     }
}
public class Logarithm : Operation, IUnaryOperation {
     public Logarithm() :
          base("Logarithm", "ln", "Calculates the natural logarith mof a number") 
          {} 
     public double Calculate(double num) {
          return Math.Log(num);
     }
}

public class Addition : Operation, IBinaryOperation {
     public Addition() :
          base("Addition", "+", "Adds two numbers together")
          {}
     public double Calculate(double lhf, double rhs) {
          return lhf + rhs;
     }
}
public class Subtraction : Operation, IBinaryOperation {
     public Subtraction() :
          base("Subtraction", "-", "Subtracts right hand side from the left hand side")
          {}
     public double Calculate(double lhf, double rhs) {
          return lhf - rhs;
     }
}
public class Multiplication : Operation, IBinaryOperation {
     public Multiplication() :
          base("Multiplication", "*", "Multiplies two numers")
          {}
     public double Calculate(double lhf, double rhs) {
          return lhf * rhs;
     }
}
public class Division : Operation, IBinaryOperation {
     public Division() :
          base("Division", "/", "Divides left hand side by the right hand side")
          {}
     public double Calculate(double lhf, double rhs) {
          return lhf / rhs;
     }
}
