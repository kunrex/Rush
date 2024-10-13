namespace Rush.Interpreter.Tokens.Enums;

[Flags]
internal enum TokenType : byte
{
    Keyword = 1,
    Constant = 2,
    Identifier = 4,
    
    Operator = 8,
    Separator = 16
}