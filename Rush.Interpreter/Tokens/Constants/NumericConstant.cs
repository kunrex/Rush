using Rush.Interpreter.Tokens.Enums;

namespace Rush.Interpreter.Tokens.Constants;

internal sealed class NumericConstant : Constant
{
    public override ConstantType ConstantType { get => ConstantType.Numeric; }
    
    public NumericConstant(string _value) : base(_value)
    { }
}