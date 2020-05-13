using System;
using SI.Domain.Exceptions;

namespace SI.Domain.Entities
{
    public class CurrentMission : BaseEntity
    {
        private CurrentMission()
        {

        }

        public CurrentMission(Guid id, CurrentMissionPlayer player, string name, string description, int level, CurrentMissionProduct product1, CurrentMissionProduct product2,
                                            CurrentMissionCategory category, int durationHours)
        {
            ID = id;
            Player = player;
            Name = name;
            Description = description;
            Level = level;
            Product1 = product1;
            Product2 = product2;
            Category = category;
            DurationHours = durationHours;
            CategoryUpdated = 0;
        }

        public CurrentMissionPlayer Player { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }

        public DateTime? DeadlineDate
        {
            get
            {
                return StartedDate?
                .AddHours(DurationHours)
                .AddHours(AddedHours);
            }
        }

        private CurrentMissionStatuses _status;
        public CurrentMissionStatuses Status
        {
            get
            {
                return DateTime.Now >= DeadlineDate ? CurrentMissionStatuses.Finished : _status;
            }
            set
            {
                if (_status != CurrentMissionStatuses.Finished)
                {
                    _status = value;
                }
            }
        }

        public CurrentMissionProduct Product1 { get; private set; }
        public CurrentMissionProduct Product2 { get; private set; }
        public CurrentMissionCategory Category { get; private set; }

        public DateTime? StartedDate { get; private set; }
        public DateTime? FinishedDate { get; private set; }
        public int DurationHours { get; private set; }
        public string PromoCode { get; private set; }
        public int AddedHours { get; private set; }

        public decimal EarnedCoints { get; private set; }

        public int CategoryUpdated { get; private set; }

        public void Start(DateTime startDate)
        {
            if (Status != CurrentMissionStatuses.Pending || string.IsNullOrEmpty(PromoCode))
                throw new LocalizableException("cant_start_mission", "cant_start_mission");

            StartedDate = startDate;
            Status = CurrentMissionStatuses.Active;
        }

        public void SellProduct(string code, Guid productID, DateTime saleDate)
        {
            if (code == PromoCode && (productID == Product1.ID || productID == Product2.ID))
            {
                if (Status == CurrentMissionStatuses.Active)
                {
                    Status = CurrentMissionStatuses.Finished;
                    FinishedDate = saleDate;
                    EarnedCoints += productID == Product1.ID ? Product1.ExpectedCoin : Product2.ExpectedCoin;
                    //TODO: throw event to increase level
                }
                else
                {
                    EarnedCoints += productID == Product1.ID ? Product1.ExpectedCoin : Product2.ExpectedCoin;
                }
            }
            else
                throw new LocalizableException("promo_is_incorrect", "promo_is_incorrect");
        }

        public void AddExtraHours(int hours)
        {
            if (Status == CurrentMissionStatuses.Active || (Status == CurrentMissionStatuses.Finished && DeadlineDate > DateTime.Now))
                AddedHours += hours;
            else
                throw new LocalizableException("cant_add_extratime", "cant_add_extratime");
        }

        public void GenerateNewpromoCode()
        {
            if (!string.IsNullOrEmpty(PromoCode))
                throw new LocalizableException("Promo_is_already_generated", "Promo_is_already_generated");
            var randomGenerator = new Random();
            PromoCode = randomGenerator.Next(10000, 99999).ToString();
        }

        public void SetPromoCode(string code)
        {
            if (Status != CurrentMissionStatuses.Pending)
                throw new LocalizableException("cant_change_promo", "cant_change_promo");

            PromoCode = code;
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