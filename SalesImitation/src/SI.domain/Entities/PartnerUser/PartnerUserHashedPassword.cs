namespace SI.Domain.Entities
{
    public class PartnerUserHashedPassword
    {
         public PartnerUserHashedPassword(string value)
        {
            Value = value;
        }
        public string Value { get; private set; }
    }
}