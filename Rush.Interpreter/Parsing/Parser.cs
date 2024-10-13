using Rush.Interpreter.Caching;
using Rush.Interpreter.Exceptions;
using Rush.Interpreter.Nodes;
using Rush.Interpreter.Nodes.Condition;
using Rush.Interpreter.Nodes.Enums;
using Rush.Interpreter.Nodes.Functions;
using Rush.Interpreter.Nodes.Operators;
using Rush.Interpreter.Tokens;
using Rush.Interpreter.Tokens.Enums;

namespace Rush.Interpreter.Parsing;

internal class Parser
{ 
    private int index;
    
    private readonly List<Token> tokens;
    
    public Parser(List<Token> _tokens)
    { 
        index = 0;
  
        tokens = _tokens;
    }

    public Node Parse()
    {
        if (tokens[0].Type == TokenType.Keyword)
        {
            var value = tokens[0].Value;

            if (value == Keyword.If.Value)
                return ParseIf();
            if (value == Keyword.While.Value)
                return ParseWhile();
            if (value == Keyword.Function.Value)
                return ParseFunction();
        }

        return ParseExpression();
    }
    
    private Node ParseExpression(SeperatorKind breakOutSep = 0)
    { 
        Stack<Node> output = new Stack<Node>();
        Stack<Token> stack = new Stack<Token>();

        bool breakOut = false;
        for(; index < tokens.Count; index++)
        {
            var current = tokens[index];
            switch(current.Type)
            { 
                case TokenType.Separator: 
                    if (breakOutSep == 0)
                    { 
                        if(current.Value == "(")
                            stack.Push(current);
                        else 
                        {
                            while(stack.Count > 0)
                            {
                                var top = stack.Pop();
                                if(top.Type == TokenType.Separator)
                                    break;
                              
                                output.Push(ParseExpression(top, output));
                            }
                        }
                    }
                    else
                    {
                        var kind = (SeperatorKind)current.SyntaxKind;
                        if ((kind & breakOutSep) == kind)
                        {
                            breakOut = true;
                            index--;
                        }
                    }
                    break;
                case TokenType.Identifier: 
                    var function = GlobalCache.Instance.GetFunction(current.Value);
                      
                    if(function != null)
                    {
                        stack.Push(current); 
                        output.Push(function);
                    }
                    else
                    {
                        output.Push(new IdentifierNode(current.Value));
                    }
                    break;
                case TokenType.Constant:
                    output.Push(new ConstantNode(double.Parse(current.Value)));
                    break;
                case TokenType.Operator: 
                    if(stack.Count > 0 && stack.Peek().Type == TokenType.Operator)
                    {
                        var cur = (Operator)current;
                        var top = (Operator)stack.Pop();

                        if (cur.Precedence < top.Precedence || (top.Precedence == cur.Precedence && !cur.LeftAssociative))
                            stack.Push(top);
                        else
                            output.Push(ParseExpression(top, output));
                    }
                      
                    stack.Push(current);
                    break;
            }
            
            if (breakOut)
                break;
        }

        if (!breakOut && breakOutSep != 0)
            throw new CompileException();
               
        while(stack.Count > 0)
            output.Push(ParseExpression(stack.Pop(), output));
          
        if(output.Count == 1)
            return output.Pop();
          
        return new Null();
    }

    private Node ParseExpression(Token top, Stack<Node> output)
    { 
        if(top.Type == TokenType.Identifier)
            return ParseFunctionCall(output);
            
        var rhs = output.Pop();
        var lhs = output.Pop();
        switch(top.SyntaxKind)
        {
            case SyntaxKind.Addition:
                return new Addition(lhs, rhs);
            case SyntaxKind.Subtraction:
                return new Subtraction(lhs, rhs);
            case SyntaxKind.Multiplication:
                return new Multiplication(lhs, rhs);
            case SyntaxKind.Division:
                return new Division(lhs, rhs);
            case SyntaxKind.Remainder:
                return new Remainder(lhs, rhs);
            case SyntaxKind.GreaterThan:
                return new GreaterThan(lhs, rhs);
            case SyntaxKind.LesserThan:
                return new LesserThan(lhs, rhs);
            case SyntaxKind.GreaterThanEquals:
                return new GreaterThanEquals(lhs, rhs);
            case SyntaxKind.LesserThanEquals:
                return new LesserThanEquals(lhs, rhs);
            case SyntaxKind.Or:
                return new Or(lhs, rhs);
            case SyntaxKind.And:
                return new And(lhs, rhs);
            case SyntaxKind.Equals:
                return new Equals(lhs, rhs);
            case SyntaxKind.NotEquals:
                return new NotEquals(lhs, rhs);
            case SyntaxKind.Assignment:
                if(lhs.Type == NodeType.Identifier)
                    return new Assignment((IdentifierNode)lhs, rhs);
                break;    
        }
            
        return new Null();  
    }
      
    private Node ParseFunctionCall(Stack<Node> output)
    {
        var arguments = new Stack<Node>();
        
        FunctionCall call = null;
        while(output.Count > 0)
        {
            var top = output.Pop();
            if(top.Type == NodeType.FunctionDefine)
            {
                var function = (Function)top;
                call = new FunctionCall(function);
                break;
            }
            
            arguments.Push(top);
        }

        for (int i = 0; i < call.FunctionArgLength; i++)
        {
            if (arguments.Count == 0) 
                return new Null();
              
            call.WithArgument(arguments.Pop());
        }
        
        while(arguments.Count > 0)
            output.Push(arguments.Pop());

        return call;
    }
    
    private Node ParseFunction()
    {
        index++;
          
        if (tokens[index].Type != TokenType.Identifier)
            return new Null();
          
        var name = tokens[index].Value;

        bool body = false;
        List<string> arguments = new List<string>();
        for(index++; index < tokens.Count; index++)
        {
            if(tokens[index].Value == Seperator.Lamda.Value)
            {
                body = true;
                break;
            }
          
            arguments.Add(tokens[index].Value);
        }
        
        index++;
         
        var expression = ParseExpression();
        if (!body || expression.Type == NodeType.Null)
            return new Null();
          
        return new Function(name, expression, arguments.ToArray());
    }

    private Node ParseIf()
    {
        index++;

        var condition = ParseExpression(SeperatorKind.Lambda);
        index++;

        var expression = ParseExpression();
        if (expression.Type == NodeType.Null)
            return new Null();
          
        return new IfNode(condition, expression);
    }
      
    private Node ParseWhile()
    {
        index++;

        var condition = ParseExpression(SeperatorKind.Lambda);
        index++;

        var expression = ParseExpression();
        if (expression.Type == NodeType.Null)
            return new Null();
          
        return new WhileNode(condition, expression);
    }
}