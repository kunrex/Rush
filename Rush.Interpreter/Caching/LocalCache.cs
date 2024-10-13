using Rush.Interpreter.Nodes.Functions;

namespace Rush.Interpreter.Caching;

internal sealed class LocalCache : Cache
{
    private readonly GlobalCache globalCache;
    private readonly Dictionary<string, double?> variableCache;    
    
    public LocalCache(GlobalCache _global)
    {
        globalCache = _global;
        variableCache = new Dictionary<string, double?>();
    }
    
    public override double? GetVariable(string name) 
    {
        if(variableCache.ContainsKey(name))
            return variableCache[name];
        else
            return globalCache.GetVariable(name);
    }
    
    public override void SetVariable(string name, double? value)
    {
        if(variableCache.ContainsKey(name))
            variableCache[name] = value;
        else
            variableCache.Add(name, value);  
    }
    
    public override Function GetFunction(string name)  => globalCache.GetFunction(name);
    
    public override void SetFunction(Function function) => globalCache.SetFunction(function);
}