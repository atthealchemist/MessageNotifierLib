using MessageNotifierLibrary.Interface;
using System.Collections.Generic;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace MessageNotifierLibrary.Models
{
    public class TelegramSender : ISender
    {

        private static readonly TelegramBotClient botClient;

        private static async void OnMessageSend(object sender, MessageEventArgs e)
        {

            if (e.Message.Text != null)
            {
                await botClient.SendTextMessageAsync(
                  chatId: e.Message.Chat,
                  text: e.Message.Text
                );
            }
        }


        public async System.Threading.Tasks.Task<bool> SendAsync(User recepient, TextMessage message, Credentials senderCredentials)
        {
            bool success = false;

            var botClient = new TelegramBotClient(senderCredentials.Telegram.Token);
            var updates = await botClient.GetUpdatesAsync();

            botClient.StartReceiving();
            Thread.Sleep(int.MaxValue);

           /* 
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
            }*/
            
            return success;
        }

        public bool Send(List<User> receipents, TextMessage message, Credentials senderCredentials)
        {
            //telegram bot sends messages according "first in - first out" way
            return true;
        }
    }
}
