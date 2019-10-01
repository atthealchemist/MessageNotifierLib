using System.Net;

namespace MessageNotifierLibrary.Models
{
    /// <summary>
    /// Sender credentials
    /// </summary>
    public class Credentials
    {
        /// <summary>
        /// E-mail credentials
        /// </summary>
        public Mail Mail { get; set; }

        /// <summary>
        /// Telegram credentials
        /// </summary>
        public Telegram Telegram { get; set; }

        /// <summary>
        /// Sms gateway credentials
        /// </summary>
        public Sms Sms { get; set; }
    }

    public class Mail
    {
        public string Address { get; set; }
        /// <summary>
        /// SMTP server of E-mail provider, e.g. smtp.google.com
        /// </summary>
        public string Server { get; set; }

        /// <summary>
        /// SMTP server port in digit, e.g. 465
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// E-Mail inbox login. E.g. login@server.com
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// E-mail inbox password
        /// </summary>
        public string Password { get; set; }
    }

    public class Telegram
    {
        /// <summary>
        /// Bot token got from @BotFather
        /// </summary>
        public string Token { get; set; }

        public WebProxy Proxy { get; set; }
    }

    public class Sms
    {
        /// <summary>
        /// API Sms gateway server string, e.g. api.smsgateway.com/v1/sendSms?text=
        /// </summary>
        public string Server { get; set; }
        /// <summary>
        /// API Sms gateway token
        /// </summary>
        public string Token { get; set; }
    }
}
