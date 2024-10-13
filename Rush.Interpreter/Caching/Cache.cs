using Rush.Interpreter.Nodes.Functions;

namespace Rush.Interpreter.Caching;

internal abstract class Cache
{
    public abstract void SetVariable(string name, double? value);
    public abstract double? GetVariable(string name);
    
    public abstract void SetFunction(Function function);
    public abstract Function GetFunction(string name);
}