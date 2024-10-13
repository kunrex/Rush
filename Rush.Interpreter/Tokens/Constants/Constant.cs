using Rush.Interpreter.Tokens.Enums;

namespace Rush.Interpreter.Tokens.Constants;

internal abstract class Constant : Token
{
    public override TokenType Type { get => TokenType.Constant; }
    
    public abstract ConstantType ConstantType { get; }

    protected Constant(string _value) : base(_value, Enums.SyntaxKind.Constant)
    {}
}