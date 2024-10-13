using Rush.Interpreter.Caching;
using Rush.Interpreter.Nodes.Enums;

namespace Rush.Interpreter.Nodes.Condition;

internal sealed class IfNode : ConditionNode
{
    public override NodeType Type { get => NodeType.If; }

    public IfNode(Node _condition, Node _expression) : base(_condition, _expression)
    { }
    
    public override double? Value(Cache cache)
    {
        var value = condition.Value(cache);
        if (value == 0)
            return expression.Value(cache);
       
        return null;
    }
}