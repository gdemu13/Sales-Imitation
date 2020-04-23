using System;

namespace SI.Domain.Entities {

    public class Money {

        public Money(decimal amount) {
            Amount = amount;
        }

        public decimal Amount {get; }
    }
}