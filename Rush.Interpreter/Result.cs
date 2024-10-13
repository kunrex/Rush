namespace Rush.Interpreter;

public struct Result
{
    private readonly double? value;
    private readonly string message;
    
    public Result(double? _value)
    {
        value = _value;
        message = null;
    }
    
    public Result(string _message)
    {
        value = null;
        message = _message;
    }

    public static Result NewNoOutput() => new Result("no output");
    public static Result NewInvalidResult() => new Result("invalid input");

    public override string ToString() => value == null ? message : value.ToString();
}