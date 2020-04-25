using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace SI.Domain.Entities
{
    public class User : BaseEntity
    {
        public User(Guid id, string userName, string password, DateTime lastUpdateDate)
        {
            ID = id;
            UserName = userName;
            PasswordHash = new HashedPassword(HashPassword(password));
            LastUpdateDate = lastUpdateDate;
        }
        public User(Guid id, string userName, HashedPassword passwordHash, DateTime lastUpdateDate)
        {
            ID = id;
            UserName = userName;
            PasswordHash = passwordHash;
            LastUpdateDate = lastUpdateDate;
        }

        public string UserName { get; set; }
        public HashedPassword PasswordHash { get; set; }

        public DateTime LastUpdateDate { get; set; }

         #region Constants
        public const int SaltByteSize = 24;
        private const int HashByteSize = 20; // to match the size of the PBKDF2-HMAC-SHA-1 hash
        private const int Pbkdf2Iterations = 1000;
        private const int IterationIndex = 0;
        private const int SaltIndex = 1;
        private const int Pbkdf2Index = 2;
        #endregion

        #region Public Methods
        private string HashPassword(string password)
        {
            var cryptoProvider = new RNGCryptoServiceProvider();
            byte[] salt = new byte[SaltByteSize];
            cryptoProvider.GetBytes(salt);

            var hash = GetPbkdf2Bytes(password, salt, Pbkdf2Iterations, HashByteSize);
            return Pbkdf2Iterations + ":" +
                   Convert.ToBase64String(salt) + ":" +
                   Convert.ToBase64String(hash);
        }

        public bool IsPasswordValid(string password)
        {
            char[] delimiter = { ':' };
            var split = PasswordHash.Value.Split(delimiter);
            var iterations = int.Parse(split[IterationIndex]);
            var salt = Convert.FromBase64String(split[SaltIndex]);
            var hash = Convert.FromBase64String(split[Pbkdf2Index]);

            var testHash = GetPbkdf2Bytes(password, salt, iterations, hash.Length);
            return SlowEquals(hash, testHash);
        }
        #endregion

        #region Private Methods
        private bool SlowEquals(byte[] a, byte[] b)
        {
            var diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
            {
                diff |= (uint)(a[i] ^ b[i]);
            }
            return diff == 0;
        }

        private byte[] GetPbkdf2Bytes(string password, byte[] salt, int iterations, int outputBytes)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterations;
            return pbkdf2.GetBytes(outputBytes);
        }
        #endregion
    }
}