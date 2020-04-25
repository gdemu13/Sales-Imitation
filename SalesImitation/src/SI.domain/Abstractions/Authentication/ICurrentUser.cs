using System;
using System.Threading.Tasks;

namespace SI.Domin.Abstractions.Authentication
{
    public interface ICurrentUser
    {
        bool IsAuthenticated { get; }
        Guid? ID { get; }
        string DisplayName { get; }
        Task SignIn(Guid id, string displayName);
        Task SignOut();
    }
}