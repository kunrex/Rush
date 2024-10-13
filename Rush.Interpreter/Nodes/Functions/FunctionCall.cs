using Rush.Interpreter.Caching;
using Rush.Interpreter.Nodes.Enums;

namespace Rush.Interpreter.Nodes.Functions;

internal sealed class FunctionCall : Node
{
    public override NodeType Type { get => NodeType.FunctionCall; }
    
    private readonly Function function;
    public int FunctionArgLength { get => function.ArgLength; }
    
    private readonly List<Node> arguments;
    public Node this[int index]
    {
        get => arguments[index];
    }
    
    public FunctionCall(Function _function)
    {
        function = _function;
        arguments = new List<Node>();
    }
    
    public void WithArgument(Node arg)
    {
        arguments.Add(arg);
    }
    
    public override double? Value(Cache cache)
    {
        if(arguments.Count != function.ArgLength)
            return null;
        
        var localCache = new LocalCache(GlobalCache.Instance);
        for(int i = 0; i < arguments.Count; i++)
            localCache.SetVariable(function[i], arguments[i].Value(cache));

        return function.Value(localCache);
    }
}