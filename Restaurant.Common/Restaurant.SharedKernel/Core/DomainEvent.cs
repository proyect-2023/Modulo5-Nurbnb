using System;

namespace Restaurant.SharedKernel.Core;

public abstract record DomainEvent 
{
    public DateTime OccuredOn { get; }
    public Guid Id { get; }

    public bool Consumed { get; set; }

    protected DomainEvent(DateTime occuredOn)
    {
        OccuredOn = occuredOn;
        Id = Guid.NewGuid();
        Consumed = false;
    }
    public void MarkAsConsumed()
    {
        Consumed = true;
    }
}
