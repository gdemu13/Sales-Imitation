using System;
using SI.Domain.Exceptions;

namespace SI.Domain.Entities
{
    public class Mission : BaseEntity
    {
        private int durationInHours;

        public Mission(Guid id, string name, string description, int level, int durationInHours, MissionMoneyRange range)
        {
            ID = id;
            Id = id;
            Name = name;
            Description = description;
            PriceRange = range;
            Level = level;
            DurationInHours = durationInHours;
        }

        public Mission(Guid id, string name, string description, int level, int durationInHours, decimal priceFrom, decimal priceTo)
        {
            ID = id;
            Name = name;
            Description = description;
            PriceRange = new MissionMoneyRange(priceFrom, priceTo);
            Level = level;
            DurationInHours = durationInHours;
        }

        public Guid Id { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public MissionMoneyRange PriceRange { get; set; }
        public int Level { get; set; }
        public int DurationInHours
        {
            get
            {
                return durationInHours;
            }
            set
            {
                if (value <= 0)
                    throw new LocalizableException("missions_duration_cant_be_zero_or_negative", "მისია ხანგრძლივობა საათებში არ შეიძლება იყოს 0 ან 0-ზე ნაკლები");
                durationInHours = value;
            }
        }
    }
}