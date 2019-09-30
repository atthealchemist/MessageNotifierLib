using MessageNotifierLibrary.Models;
using System.Collections.Generic;

namespace MessageNotifierLibrary.Interface
{
    public interface ISender
    {
        bool Send(User recepient, TextMessage message, Credentials senderCredentials);
    }
}
