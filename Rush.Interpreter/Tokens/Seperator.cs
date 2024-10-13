using Rush.Interpreter.Tokens.Enums;

namespace Rush.Interpreter.Tokens;

internal sealed class Seperator : Token
{
    private readonly SeperatorKind seperatorKind;
    public SeperatorKind SeperatorKind { get => seperatorKind; } 
    
    public override TokenType Type { get => TokenType.Separator; }
    
    public static Seperator Lamda = new Seperator("=>", SeperatorKind.Lambda);
    
    public static Seperator OpenBracket = new Seperator("(", SeperatorKind.OpenBracket);
    public static Seperator CloseBracket = new Seperator(")", SeperatorKind.CloseBracket);
    
    public static Seperator BoxOpenBracket = new Seperator("[", SeperatorKind.BoxOpenBracket);
    public static Seperator BoxCloseBracket = new Seperator("]", SeperatorKind.BoxCloseBracket);

    private Seperator(string _value, SeperatorKind _kind) : base(_value, (SyntaxKind)_kind)
    {
        seperatorKind = _kind;
    }
    
    public Token Clone() => new Seperator(value, seperatorKind);
}