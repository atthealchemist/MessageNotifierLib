using MessageNotifierLibrary.Interface;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Net;

namespace MessageNotifierLibrary.Models
{
    public class SmsSender : ISender
    {
        public bool Send(User recepient, TextMessage message, Credentials senderCredentials)
        {
            var credentials = senderCredentials.Sms;
            if (credentials == null)
            {
                return false;
            }

            bool success = false;

            foreach (var contact in recepient.Contacts)
            {
                if (contact.ContactInfo != null && contact.ContactInfo.Type == ContactType.SMS)
                {
                    string phone = contact.Value;

                    using (WebClient client = new WebClient())
                    {
                        NameValueCollection data = new NameValueCollection()
                        {
                            { "phone", phone },
                            { "message", message.ToString() },
                            { "key", credentials.Token },
                        };

                        byte[] response = client.UploadValues("http://textbelt.com/text", data);
                        string responseString = System.Text.Encoding.UTF8.GetString(response);

                        dynamic responseDefinition = new
                        {
                            success = false,
                            quotaRemaining = "",
                            textId = "",
                            error = ""
                        };

                        dynamic result = JsonConvert.DeserializeAnonymousType(responseString, responseDefinition);
                        if (result.success)
                        {
                            success = result.success;
                        }
                    }
                }
            }
            return success;
        }
    }
}