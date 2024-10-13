using System.Text;
using Rush.Interpreter.Caching;
using Rush.Interpreter.Lexing;

using Rush.Interpreter.Parsing;

using Rush.Interpreter.Nodes.Enums;
using Rush.Interpreter.Nodes.Condition;
using Rush.Interpreter.Nodes.Functions;

namespace Rush.Interpreter;

public sealed class Interpreter
{
    const int maxLoop = 225;
    
    public Interpreter()
    {
        Lexer.Initialise();
        GlobalCache.Initalise();
    }
    
    public Result Input(string input)
    {  
        if(string.IsNullOrEmpty(input))
            return  Result.NewNoOutput();

        try
        {
            var result = new Parser(Lexer.Instance.Lex(input)).Parse();

            switch(result.Type)
            {
                case NodeType.Null:
                    return Result.NewInvalidResult();
                case NodeType.Constant:
                case NodeType.Operator:
                case NodeType.Identifier:
                case NodeType.Assignment:
                case NodeType.FunctionCall:
                    var value = result.Value(GlobalCache.Instance);
                    if(value == null)
                        return Result.NewInvalidResult();
                    
                    return new Result(value);
                case NodeType.If:
                    var check = result.Value(GlobalCache.Instance);
                    if (check == null)
                        return Result.NewNoOutput();

                    return new Result(check);
                case NodeType.While:
                    StringBuilder s = new StringBuilder();
                    var node = (WhileNode)result;

                    int i = 0;
                    while (node.ValueCondition(GlobalCache.Instance) == 0 && i < maxLoop)
                    {
                        s.Append($"{node.Value(GlobalCache.Instance)}\n");
                        i++;
                    }

                    if (i == maxLoop)
                        s.Append("----EXECUTION TIMEOUT----");

                    if (s.Length == 0)
                        return Result.NewNoOutput();

                    return new Result(s.ToString().Trim());
                default:
                    GlobalCache.Instance.SetFunction((Function)result);
                    return Result.NewNoOutput();
            }
        }
        catch (Exception e)
        {
            return new Result(e.Message);
        }
    }
}
