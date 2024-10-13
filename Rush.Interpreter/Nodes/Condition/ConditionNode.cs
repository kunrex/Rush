using Rush.Interpreter.Caching;

namespace Rush.Interpreter.Nodes.Condition;

internal abstract class ConditionNode : Node
{
    protected readonly Node condition;
    protected readonly Node expression;
    
    protected ConditionNode(Node _condition, Node _expression)
    {
        condition = _condition;
        expression = _expression;
    }
    

}