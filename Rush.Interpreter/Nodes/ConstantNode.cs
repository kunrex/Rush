using Rush.Interpreter.Caching;
using Rush.Interpreter.Nodes.Enums;

namespace Rush.Interpreter.Nodes;

internal sealed class ConstantNode : Node 
{
    public override NodeType Type { get => NodeType.Constant; }
    
    private readonly double value;
    
    public ConstantNode(double _value)
    {
        value = _value;
    }
    
    public override double? Value(Cache cache) => value;
}