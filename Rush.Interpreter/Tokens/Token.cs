using Rush.Interpreter.Tokens.Enums;

namespace Rush.Interpreter.Tokens;

internal abstract class Token
{
    protected readonly string value;
    public string Value { get => value; }

    protected readonly SyntaxKind syntaxKind;
    public SyntaxKind SyntaxKind { get=> syntaxKind; }
    
    public abstract TokenType Type { get; }
    
    protected Token(string _value, SyntaxKind _kind)
    {
        value = _value;
        syntaxKind = _kind;
    }
}