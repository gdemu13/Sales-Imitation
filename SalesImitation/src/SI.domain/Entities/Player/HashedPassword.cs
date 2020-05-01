using System;
using System.Security.Cryptography;

namespace SI.Domain.Entities
{
    public class PlayerHashedPassword
    {
        public PlayerHashedPassword(string value)
        {
            Value = value;
        }
        public string Value { get; private set; }


    }
}