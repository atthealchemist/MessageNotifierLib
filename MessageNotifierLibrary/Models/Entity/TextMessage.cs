namespace MessageNotifierLibrary.Models
{
    public class TextMessage
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public override string ToString()
        {
            if (Title.Length > 0)
                Title += " ";
            return Title + Content;
        }
    }
}
