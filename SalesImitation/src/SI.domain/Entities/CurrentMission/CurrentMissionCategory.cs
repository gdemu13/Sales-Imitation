using System;

namespace SI.Domain.Entities
{
    public class CurrentMissionCategory : BaseEntity
    {
        public CurrentMissionCategory(Guid id, string name)
        {
            ID = id;
            Name = name;
        }
        public string Name {get; set;}
    }
}