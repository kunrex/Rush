using Rush.Interpreter.Nodes.Functions;

namespace Rush.Interpreter.Caching;

internal sealed class GlobalCache : Cache
{
    private static GlobalCache instance;
    public static GlobalCache Instance { get => instance ; }

    public static void Initalise()
    {
        instance = new GlobalCache();
    }
    
    private readonly Dictionary<string, double?> variableCache;    
    private readonly Dictionary<string, Function> functionCache;
    
    public GlobalCache()
    {
        variableCache = new Dictionary<string, double?>();
        functionCache = new Dictionary<string, Function>();
    }
    
    public override double? GetVariable(string name) 
    {
        if(variableCache.ContainsKey(name))
            return variableCache[name];
        else
            return null;
    }
    
    public override void SetVariable(string name, double? value)
    {
        if(variableCache.ContainsKey(name))
            variableCache[name] = value;
        else if(!functionCache.ContainsKey(name))
            variableCache.Add(name, value);        
    }

    public override Function GetFunction(string name) 
    {
        if(functionCache.ContainsKey(name))
            return functionCache[name];
        else
            return null;
    }

    public override void SetFunction(Function function)
    {
        if(functionCache.ContainsKey(function.Name))
            functionCache[function.Name] = function;
        else if(!variableCache.ContainsKey(function.Name))
            functionCache.Add(function.Name, function);
    }
}