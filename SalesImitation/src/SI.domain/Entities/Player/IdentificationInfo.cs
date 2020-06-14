using System;
using System.Security.Cryptography;

namespace SI.Domain.Entities
{
    public class IdentificationInfo : BaseEntity
    {
        public IdentificationInfo(Guid id)
        {
            ID = id;
        }
        public string IDCardFrontUrl { get; set; }
        public string IDCardBackUrl { get; set; }
        public string SelfieUrl { get; set; }
        public string IDNumber { get; set; }
    }
}