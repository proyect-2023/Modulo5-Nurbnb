

using Restaurant.SharedKernel.Core;
using Restaurant.SharedKernel.Rules;

namespace Restaurant.SharedKernel.ValueObjects;

public record PersonNameValue : ValueObject
{
    public string Name { get; }

    public PersonNameValue(string name)
    {
        CheckRule(new StringNotNullOrEmptyRule(name));
        if(name.Length < 2)
        {
            throw new BussinessRuleValidationException("PersonName no puede ser menos de  2 characters");
        }
        Name = name;
    }

    public static implicit operator string(PersonNameValue value)
    {
        return value.Name;
    }

    public static implicit operator PersonNameValue(string name)
    {
        return new PersonNameValue(name);
    }
}
