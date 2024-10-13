using Rush.Interpreter.Caching;
using Rush.Interpreter.Nodes.Enums;

namespace Rush.Interpreter.Nodes;

internal sealed class Null : Node
{
    public override NodeType Type { get => NodeType.Null; }
      
    public Null() 
    { }
      
    public override double? Value(Cache cache) => null;
}