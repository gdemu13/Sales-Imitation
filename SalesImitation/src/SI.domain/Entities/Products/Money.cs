using System;

namespace SI.Domain.Entities {

    public class Money : BaseEntity {

        public Money(decimal amount) {
            Amount = amount;
        }

        public decimal Amount {get; }
    }
}