using MediatR;
using System.Collections.Generic;
using SI.Domain.Entities;
using SI.Domain.Abstractions.Repositories;

namespace SI.Application.Players
{
    public class GetLeaderboardResponse
    {
        public GetLeaderboardItem You { get; set; }
        public ICollection<GetLeaderboardItem> Others { get; set; }
    }

    public class GetLeaderboardItem
    {
        public decimal coins { get; set; }
        public int Avatar { get; set; }
        public string Name { get; set; }
        public int Place { get; set; }
    }
}