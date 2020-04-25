using System;
using System.Security.Cryptography;

namespace SI.Domain.Entities
{
    public class HashedPassword
    {
        public HashedPassword(string value)
        {
            Value = value;
        }
        public string Value { get; private set; }


    }
}