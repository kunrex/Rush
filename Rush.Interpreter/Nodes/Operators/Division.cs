using Rush.Interpreter.Caching;
using Rush.Interpreter.Exceptions;
using Rush.Interpreter.Nodes.Enums;

namespace Rush.Interpreter.Nodes.Operators;

internal sealed class Division : OperatorNode
{
    public Division(Node _op1, Node _op2) : base(_op1, _op2)
    { }
    
    public override double? Value(Cache cache)
    {
        var val1 = operhand1.Value(cache);
        var val2 = operhand2.Value(cache);

        if (val2 == 0)
            throw new DivideByZeroException();
        
        return val1 / val2;
    } 
}