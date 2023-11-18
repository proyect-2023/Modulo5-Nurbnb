using Restaurant.SharedKernel.Core;

namespace Restaurant.SharedKernel.Rules;

public class NotNullRule : IBussinessRule
{
    private readonly object _value;

    public NotNullRule(object value)
    {
        _value = value;
    }

    public string Message => "Object cannot be null";

    public bool IsValid()
    {
        return _value != null;
    }
}
