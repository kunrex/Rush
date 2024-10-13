using Rush.Interpreter.Caching;
using Rush.Interpreter.Nodes.Enums;

namespace Rush.Interpreter.Nodes.Condition;

internal sealed class WhileNode : ConditionNode
{
    public override NodeType Type { get => NodeType.While; }
    
    public WhileNode(Node _condition, Node _expression) : base(_condition, _expression)
    { }

    public double? ValueCondition(Cache cache) => condition.Value(cache);
    public override double? Value(Cache cache) => expression.Value(cache);
}