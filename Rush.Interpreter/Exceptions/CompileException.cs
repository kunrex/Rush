namespace Rush.Interpreter.Exceptions;

internal sealed class CompileException : Exception
{
    public CompileException() : base("invalid input")
    { }
}