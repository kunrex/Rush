using Rush.Interpreter.Caching;
using Rush.Interpreter.Nodes.Enums;

namespace Rush.Interpreter.Nodes;

internal abstract class Node
{
    public abstract NodeType Type { get; }
   
    public abstract double? Value(Cache cache);
}