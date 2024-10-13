using Rush.Interpreter.Caching;

namespace Rush.Interpreter.Nodes.Operators;

internal sealed class Remainder : OperatorNode
{
    public Remainder(Node _op1, Node _op2) : base(_op1, _op2)
    { }
    
    public override double? Value(Cache cache) => operhand1.Value(cache) % operhand2.Value(cache);
}