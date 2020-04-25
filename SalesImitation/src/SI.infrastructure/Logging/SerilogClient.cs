using SI.Common.Abstractions;
using SI.Domin.Abstractions.Authentication;
using System;
using Serilog;

namespace SI.Infrastructure.Logging
{
    public class SerilogClient : SI.Common.Abstractions.ILogger
    {
        private readonly ICurrentUser currentUser;

        public SerilogClient(ICurrentUser currentUser)
        {
            this.currentUser = currentUser;
        }

        public void Error(string message, Exception ex)
        {
            if (currentUser.IsAuthenticated)
                Log.Error(ex, "User: {UserID}, DisplayName: {DisplayName}, Message: " + message, currentUser.ID, currentUser.DisplayName);
            else
                Log.Error(ex, message);
        }
    }
}