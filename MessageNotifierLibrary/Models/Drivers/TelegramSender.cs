using MessageNotifierLibrary.Interface;
using Newtonsoft.Json;
using System.Net;

namespace MessageNotifierLibrary.Models
{
    public class TelegramSender : ISender
    {
        public bool Send(User recepient, TextMessage message, Credentials senderCredentials)
        {
            bool success = false;

            var credentials = senderCredentials.Telegram;
            if (credentials == null)
            {
                return false;
            }

            using (var client = new WebClient())
            {
                client.Proxy = credentials.Proxy;

                var updatesResponse = client.DownloadString($"https://api.telegram.org/bot{credentials.Token}/getUpdates");

                dynamic responseDefinition = new
                {
                    ok = false,
                    result = new
                    {
                        message_id = 0,
                        from = new
                        {
                            id = 0,
                            is_bot = false,
                            first_name = "",
                            username = ""
                        },
                        chat = new
                        {
                            id = 0,
                            first_name = "",
                            last_name = "",
                            username = "",
                            type = ""
                        },
                        date = 0,
                        text = ""
                    },

                };

                dynamic updateResult = JsonConvert.DeserializeAnonymousType(updatesResponse, responseDefinition);

                if (updateResult.ok)
                {
                    int chat_id = updateResult.chat.id;

                    var sendResponse = client.DownloadString($"https://api.telegram.org/bot{credentials.Token}/sendMessage?chat_id={chat_id}&message={message}");
                    var sendResult = JsonConvert.DeserializeAnonymousType(sendResponse, responseDefinition);

                    success = sendResult.ok;
                }

            }
            return success;
        }
    }
}
