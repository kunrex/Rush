namespace Rush.Interpreter.Nodes.Enums;

internal enum NodeType : byte
{
    Constant,
    Identifier,
    
    Operator,
    
    FunctionCall,
    FunctionDefine,
    
    Null,
    Assignment,
    
    If,
    While
}