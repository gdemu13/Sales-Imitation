using System;
using System.Security.Cryptography;
using SI.Common.Models;
using SI.Domain.Exceptions;

namespace SI.Domain.Entities
{
    public class Player : BaseEntity
    {
        public Player(Guid id, string username, PlayerHashedPassword passwordHash, string mail, string firstname, string lastname, int level, PlayerAvatars avatar, string phone)
        {
            ID = id;
            Username = username;
            PasswordHash = passwordHash;
            Mail = mail;
            Firstname = firstname;
            Lastname = lastname;
            CurrentLevel = level;
            Avatar = avatar;
            Phone = phone;
        }

        public Player(Guid id, string username, string password, string mail, string firstname, string lastname, int level, PlayerAvatars avatar, string phone)
        {
            ID = id;
            Username = username;
            Mail = mail;
            Firstname = firstname;
            Lastname = lastname;
            PasswordHash = new PlayerHashedPassword(HashPassword(password));
            CurrentLevel = level;
            Avatar = avatar;
            Phone = phone;
        }
        public PlayerAvatars Avatar { get; set; }
        public string Phone { get; set; }
        public string Username { get; }
        public PlayerHashedPassword PasswordHash { get; private set; }
        public string Mail { get; set; }
        private string _firstName;
        public string Firstname
        {
            get { return _firstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new LocalizableException("username_couldnt_be_empty", "username_couldnt_be_empty");
                _firstName = value;
            }
        }

        private string _lastname;
        public string Lastname
        {
            get { return _lastname; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new LocalizableException("username_couldnt_be_empty", "username_couldnt_be_empty");
                _lastname = value;
            }
        }
        public string FacebookID { get; set; }

        private int _currentLevel;
        public int CurrentLevel
        {
            get
            {
                return _currentLevel;
            }
            set
            {
                if (value <= 0)
                    throw new LocalizableException("level_cant_be_less_than_1", "level_cant_be_less_than_1");
                _currentLevel = value;
            }
        }

        public IdentificationInfo IdentificationInfo { get; set; }

        //TODO
        public decimal Coins { get; private set; }

        public void SpendCoins(decimal coinsToSpend, string reason)
        {
            if (Coins - coinsToSpend < 0)
                throw new LocalizableException("not_enought_coins", "თქვენ არ გაქვ საკმარისი რაოდენობის მონეტები");

            Coins -= coinsToSpend;
        }

        public void AddCoins(decimal newCoins, string source)
        {
            Coins += newCoins;
        }

        public void LevelUp()
        {
            CurrentLevel++;
        }

        public Result ChangePassword(string oldPassword, string newPassword)
        {
            if (!IsPasswordValid(oldPassword))
                return new Result(false, "მიმდინარე პაროლი არასწორია");

            if (newPassword.Length < 7 || newPassword.Length > 20)
                return new Result(false, "პაროლი უნდა იყოს მინიმუმ 6 და მაქსიმუმ 7 სიმბოლოიანი");

            PasswordHash = new PlayerHashedPassword(HashPassword(newPassword));
            return Result.CreateSuccessReqest("პაროლი წარმატებით შეიცვალა");
        }

        #region Constants
        public const int SaltByteSize = 24;
        private const int HashByteSize = 20; // to match the size of the PBKDF2-HMAC-SHA-1 hash
        private const int Pbkdf2Iterations = 1000;
        private const int IterationIndex = 0;
        private const int SaltIndex = 1;
        private const int Pbkdf2Index = 2;
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