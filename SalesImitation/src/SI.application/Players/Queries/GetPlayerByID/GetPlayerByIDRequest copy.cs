using System;
using MediatR;
using SI.Domain.Entities;

namespace SI.Application.Categories
{
    public class GetPlayerByIDResponse
    {
        public string Username { get; set; }
        public string Mail { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int CurrentLevel { get; set; }
        public decimal Coins { get; set; }
    }
}