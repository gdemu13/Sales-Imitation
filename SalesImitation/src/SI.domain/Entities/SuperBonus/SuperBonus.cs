using System;
using System.Collections.Generic;
using System.Linq;

namespace SI.Domain.Entities {

    public class SuperBonus : BaseEntity {

        public SuperBonus(Guid id, decimal amount, SuperBonusStatuses status) {
            BaseAmount = amount;
            Status = status;
            ID = id;
        }

        public Guid ID {get; private set;}

        public decimal BaseAmount { get; set; }
        public decimal CurrentAmount {
            get {
                return BaseAmount + _increases.Sum (i => i.Amount);
            }
        }

        public SuperBonusStatuses Status { get; set; }

        public void Increase (Guid id, decimal amount, string source) {
            _increases.Add (new SuperBonusIncrease {
                ID = id,
                    Amount = amount,
                    Source = source
            });
        }

        private List<SuperBonusIncrease> _increases = new List<SuperBonusIncrease> ();

        public IReadOnlyList<SuperBonusIncrease> Increases {
            get {
                return _increases;
            }
        }
    }
}