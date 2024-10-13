namespace Rush.Interpreter.Tokens.Enums;

internal enum SyntaxKind
{
    Lambda = SeperatorKind.Lambda,
    
    OpenBracke = SeperatorKind.OpenBracket,
    CloseBracket = SeperatorKind.CloseBracket,
    
    BoxOpenBracket = SeperatorKind.BoxOpenBracket,
    BoxCloseBracket = SeperatorKind.BoxCloseBracket,
    
    Addition,
    Subtraction,
    Multiplication,
    Division,
    Remainder,
    
    GreaterThan,
    GreaterThanEquals,
    LesserThan,
    LesserThanEquals,
    
    Or,
    And,
    
    Equals,
    NotEquals,
    
    Assignment,
    
    If,
    While,
    Function,
    
    Constant,
    Identifier
}