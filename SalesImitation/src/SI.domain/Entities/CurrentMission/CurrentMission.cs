using System;
using SI.Domain.Exceptions;

namespace SI.Domain.Entities
{
    public class CurrentMission : BaseEntity
    {
        public CurrentMission(Guid id, string name, string description, int level, CurrentMissionProduct product1, CurrentMissionProduct product2,
                                            CurrentMissionCategory category, DateTime startDate, int durationHours, string promoCode)
        {
            ID = id;
            Name = name;
            Description = description;
            Level = level;
            Product1 = product1;
            Product2 = product2;
            Category = category;
            StartDate = startDate;
            DurationHours = durationHours;
            PromoCode = promoCode;
            CategoryUpdated = 0;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }

        public DateTime DeadlineDate
        {
            get
            {
                return StartDate.AddHours(DurationHours);
            }
        }

        public CurrentMissionStatuses Status
        {
            get
            {
                return DateTime.Now >= DeadlineDate ? CurrentMissionStatuses.Finished : Status;
            }
            set
            {
                if (Status != CurrentMissionStatuses.Finished)
                {
                    Status = value;
                }
            }
        }

        public CurrentMissionProduct Product1 { get; private set; }
        public CurrentMissionProduct Product2 { get; private set; }
        public CurrentMissionCategory Category { get; private set; }
        public DateTime StartDate { get; }
        public DateTime? FinishDate { get; private set; }
        public int DurationHours { get; }
        public string PromoCode { get; }
        public int AddedHours { get; private set; }

        public int EarnedCoints { get; private set; }

        public int CategoryUpdated { get; private set; }

        public void Complete(bool success, int coins, DateTime finishDate)
        {
            Status = CurrentMissionStatuses.Finished;
            EarnedCoints = coins;
            FinishDate = finishDate;
        }

        public void AddExtraHours(int hours)
        {
            AddedHours += hours;
        }

        public void UpdateCategoryAndProducts(CurrentMissionProduct product1, CurrentMissionProduct product2,
                                            CurrentMissionCategory category)
        {
            if (CategoryUpdated >= 2)
            {
                throw new LocalizableException("you_have_updated_category_twice_already", "კაეგორიის განახლება ორზე მეტჯერ არ შეიძლება");
            }
            CategoryUpdated++;
            Product1 = product1;
            Product2 = product2;
        }
    }
}