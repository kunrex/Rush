using Rush.Interpreter.Caching;
using Rush.Interpreter.Nodes.Enums;

namespace Rush.Interpreter.Nodes.Functions;

internal sealed class Function : Node
{
    public override NodeType Type { get => NodeType.FunctionDefine; }
    
    private readonly string name;
    public string Name { get => name; }
    
    private readonly Node expression;
    
    private readonly string[] arguments;
    public int ArgLength { get => arguments.Length; }
    
    public string this[int index]
    {
        get => arguments[index];
    }
    
    public Function(string _name, Node _expression, string[] _arguments)
    {
        name = _name;
        expression = _expression;
        arguments = _arguments;
    }
    
    public override double? Value(Cache cache) => expression.Value(cache);
}