using Rush.Interpreter.Caching;
using Rush.Interpreter.Nodes.Enums;

namespace Rush.Interpreter.Nodes;

internal sealed class IdentifierNode : Node 
{
    public override NodeType Type { get => NodeType.Identifier; }
    
    private readonly string name;
    public string Name { get => name; }
    
    public IdentifierNode(string _name)
    {
        name = _name;
    }
    
    public override double? Value(Cache cache)
    {
        return cache.GetVariable(name);
    }
}