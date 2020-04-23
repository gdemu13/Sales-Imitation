namespace SI.Domain.Entities {
    public class MissionMoneyRange {
        public MissionMoneyRange (decimal from, decimal to) {
            From = from;
            To = to;
        }
        public decimal From { get; set; }
        public decimal To { get; set; }
    }
}