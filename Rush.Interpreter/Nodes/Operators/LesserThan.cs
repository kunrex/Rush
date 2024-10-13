using Rush.Interpreter.Caching;

namespace Rush.Interpreter.Nodes.Operators;

internal sealed class LesserThan : OperatorNode
{
    public LesserThan(Node _op1, Node _op2) : base(_op1, _op2)
    { }
    
    public override double? Value(Cache cache) => operhand1.Value(cache) < operhand2.Value(cache) ? 0 : 1;
}