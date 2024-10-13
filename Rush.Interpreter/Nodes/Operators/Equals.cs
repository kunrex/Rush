using Rush.Interpreter.Caching;

namespace Rush.Interpreter.Nodes.Operators;

internal sealed class Equals : OperatorNode
{
    public Equals(Node _op1, Node _op2) : base(_op1, _op2)
    { }
    
    public override double? Value(Cache cache)
    {
        var val1 = operhand1.Value(cache);
        var val2 = operhand2.Value(cache);

        if (val1 == null)
            return null;
        
        if (val2 == null)
            return null;
        
        return Math.Round((double)val1, 3, MidpointRounding.ToEven) == Math.Round((double)val2, 3, MidpointRounding.ToEven) ? 0 : 1;
    } 
}