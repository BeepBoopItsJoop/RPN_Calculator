namespace RpnCalculator;

public class Token(TokenType type, string value)
{

     private TokenType Type { get; } = type;
     private string Value { get; } = value;

     public bool IsOperator() => Type is TokenType.Operator;
     public bool IsOperand() => Type is TokenType.Operand;

     public TokenType GetTokenType() => Type;
     public string GetValue() => Value;
     public double GetNumericalValue() {
          if(IsOperator()) 
               throw new InvalidOperationException("Cannot get numerical value from an operator token.");
          else
               return double.Parse(Value);
     }
}

public enum TokenType {
     Operator,
     Operand
}
