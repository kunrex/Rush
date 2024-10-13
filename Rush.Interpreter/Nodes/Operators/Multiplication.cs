using Rush.Interpreter.Caching;
using Rush.Interpreter.Nodes.Enums;

namespace Rush.Interpreter.Nodes.Operators;

internal sealed class Multiplication : OperatorNode
{
    public Multiplication(Node _op1, Node _op2) : base(_op1, _op2)
    { }
    
    public override double? Value(Cache cache) => operhand1.Value(cache) * operhand2.Value(cache);
}