using System;

namespace SI.Domain.Entities
{
    public class Withdraw : BaseEntity
    {
        public decimal Amount { get; set; }
        public WithdrawPlayer Player { get; set; }
        public WithdrawStatuses Status { get; set; }
        public DateTime FinishDate { get; set; }
        public DateTime RequestDate { get; set; }
    }
}