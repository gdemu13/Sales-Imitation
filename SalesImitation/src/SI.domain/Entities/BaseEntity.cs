using System;
using System.Collections.Generic;
using SI.Domain.Abstractions.DomainEvents;

namespace SI.Domain.Entities {

    public abstract class BaseEntity {
        public BaseEntity()
        {
            Events = new List<IDomainEvent>();
        }
        public Guid ID { get; set; }

        public List<IDomainEvent> Events { get; }
    }
}