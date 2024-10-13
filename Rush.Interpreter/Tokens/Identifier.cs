using Rush.Interpreter.Tokens.Enums;

namespace Rush.Interpreter.Tokens;

internal sealed class Identifer : Token
{
    public override TokenType Type { get => TokenType.Identifier; }
    
    public Identifer(string _value) : base(_value, SyntaxKind.Identifier)
    {}
}