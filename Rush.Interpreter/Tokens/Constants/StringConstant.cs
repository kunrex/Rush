using Rush.Interpreter.Tokens.Enums;

namespace Rush.Interpreter.Tokens.Constants;

internal sealed class StringConstant : Constant
{
    public override ConstantType ConstantType { get => ConstantType.Numeric; }
    
    public StringConstant(string _value) : base(_value)
    { }
}