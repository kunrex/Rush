namespace Rush.Interpreter.Tokens.Enums;

[Flags]
internal enum SeperatorKind
{
    Lambda = 1,
    
    OpenBracket = 2,
    CloseBracket = 4,
    
    BoxOpenBracket = 8,
    BoxCloseBracket = 16,
}