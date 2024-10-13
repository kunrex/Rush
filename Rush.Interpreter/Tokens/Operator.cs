using Rush.Interpreter.Tokens.Enums;

namespace Rush.Interpreter.Tokens;

internal sealed class Operator : Token
{
    public override TokenType Type { get => TokenType.Operator; }
  
    private readonly int precedence;
    public int Precedence { get => precedence; }
    
    private readonly bool leftAssociative;
    public bool LeftAssociative { get => leftAssociative; }
    
    public static Operator Addition = new Operator("+", 2, true, Enums.SyntaxKind.Addition);
    public static Operator Subtraction = new Operator("-", 2, true, Enums.SyntaxKind.Subtraction);
    
    public static Operator Multiplication = new Operator("*", 1, true, Enums.SyntaxKind.Multiplication);
    public static Operator Division = new Operator("/", 1, true, Enums.SyntaxKind.Division);
    public static Operator Remainder = new Operator("%", 1, true, Enums.SyntaxKind.Remainder);
    
    public static Operator GreaterThan = new Operator(">", 3, true, Enums.SyntaxKind.GreaterThan);
    public static Operator GreaterThanEquals = new Operator(">=", 3, true, Enums.SyntaxKind.GreaterThanEquals);
    public static Operator LesserThan = new Operator("<", 3, true, Enums.SyntaxKind.LesserThan);
    public static Operator LessThanEquals = new Operator("<=", 3, true, Enums.SyntaxKind.LesserThanEquals);
    
    public static Operator Or = new Operator("||", 4, true, Enums.SyntaxKind.Or);
    public static Operator And = new Operator("&&", 5, true, Enums.SyntaxKind.And);
    
    public static Operator Equal = new Operator("==", 4, true, Enums.SyntaxKind.Equals);
    public static Operator NotEqual = new Operator("!=", 4, true, Enums.SyntaxKind.NotEquals);
    
    public static Operator Assignment = new Operator("=", 6, false, Enums.SyntaxKind.Assignment);
    
    private Operator(string _value, int _precedence, bool _leftAssociative, SyntaxKind _kind) : base(_value, _kind)
    {
        precedence = _precedence;
        leftAssociative = _leftAssociative;
    }
    
    public Token Clone() => new Operator(value, precedence, leftAssociative, syntaxKind);
}