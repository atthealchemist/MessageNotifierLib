using MessageNotifierLibrary.Interface;
using MessageNotifierLibrary.Utils;
using System.Collections.Generic;

namespace MessageNotifierLibrary.Models
{
    public class EmailSenderTelnet : ISender
    {
        public bool Send(User recepient, TextMessage message, Credentials senderCredentials)
        {
            return Send(new List<User> { recepient }, message, senderCredentials);
        }

        public bool Send(List<User> receipents, TextMessage message, Credentials senderCredentials)
        {
            var credentials = senderCredentials.Mail;
            if (credentials == null)
            {
                return false;
            }

            bool success = false;

            foreach (var recepient in receipents)
            {
                if (recepient.Contacts != null)
                {
                    foreach (var contact in recepient.Contacts)
                    {
                        if (contact.ContactInfo?.Type == ContactType.EMAIL)
                        {
                            using (var client = new TelnetSmtpClient(credentials.Server, credentials.Port))
                            {
                                if (client.Connected)
                                {
                                    client.Login(credentials.Username, credentials.Password);
                                    if (client.LoggedIn)
                                    {
                                        success = client.SendMail(credentials.Address, new string[1] { contact.Value }, message.Title, message.Content);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return success;
        }
    }
}