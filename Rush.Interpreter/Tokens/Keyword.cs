using Rush.Interpreter.Tokens.Enums;

namespace Rush.Interpreter.Tokens;

internal sealed class Keyword : Token
{
    public override TokenType Type { get => TokenType.Keyword; }
    
    public static Keyword If = new Keyword("if", Enums.SyntaxKind.If);
    public static Keyword While = new Keyword("while", Enums.SyntaxKind.While);
    public static Keyword Function = new Keyword("fn", Enums.SyntaxKind.Function);
    
    private Keyword(string _value, SyntaxKind _kind) : base(_value, _kind)
    {}
    
    public Token Clone() => new Keyword(value, syntaxKind);
}