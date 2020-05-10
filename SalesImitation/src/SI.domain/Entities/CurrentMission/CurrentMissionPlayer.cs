using System;

namespace SI.Domain.Entities
{
    public class CurrentMissionPlayer : BaseEntity
    {
        public CurrentMissionPlayer(Guid id, string fullname, int level)
        {
            ID = id;
            Fullname = fullname;
            Level = level;
        }

        public string Fullname { get; }
        public int Level { get; }
    }
}