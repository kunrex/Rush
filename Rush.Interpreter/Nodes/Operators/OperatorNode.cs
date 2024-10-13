using Rush.Interpreter.Nodes;
using Rush.Interpreter.Nodes.Enums;

internal abstract class OperatorNode : Node 
{
    public override NodeType Type { get => NodeType.Operator; }

    protected readonly Node operhand1;
    protected readonly Node operhand2;
    
    protected OperatorNode(Node _op1, Node _op2)
    {
        operhand1 = _op1;
        operhand2 = _op2;
    }
}