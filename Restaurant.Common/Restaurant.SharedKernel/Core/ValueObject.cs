using System;

namespace Restaurant.SharedKernel.Core;

public abstract record ValueObject
{
    protected static void CheckRule(IBussinessRule rule)
    {
        if (rule is null)
        {
            throw new ArgumentException("Rule cannot be null");
        }
        if (!rule.IsValid())
        {
            throw new BussinessRuleValidationException(rule);
        }
    }

}
