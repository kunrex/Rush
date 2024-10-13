using Rush.Interpreter.Caching;
using Rush.Interpreter.Nodes.Enums;

namespace Rush.Interpreter.Nodes.Operators;

internal sealed class Assignment : OperatorNode
{
    public override NodeType Type { get => NodeType.Assignment; }
    
    private readonly IdentifierNode identifier;
  
    public Assignment(IdentifierNode _op1, Node _op2) : base(_op1, _op2)
    { 
        identifier = _op1;
    }
    
    public override double? Value(Cache cache) 
    {
        cache.SetVariable(identifier.Name, operhand2.Value(cache));
      
        return cache.GetVariable(identifier.Name);
    } 
}