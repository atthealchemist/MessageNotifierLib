using MessageNotifierLibrary.Models;
using System.Collections.Generic;

namespace MessageNotifierLibrary.Interface
{
    public interface ISender
    {
        bool Send(User recepient, TextMessage message, Credentials senderCredentials);
        bool Send(List<User> receipents, TextMessage message, Credentials senderCredentials);
    }
}
