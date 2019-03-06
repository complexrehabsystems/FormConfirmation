namespace FormConfirmation
{
    public class EmailRequest
    {
        public string FromEmail { get; set; }
        public string From { get; set; }
        public string ToEmail { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public string Html { get; set; }
    }
}
