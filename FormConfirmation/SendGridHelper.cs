using System;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace FormConfirmation
{
    /// <summary>
    /// Send email via SendGrid email api
    /// </summary>
    public class SendGridHelper
    {
        #region Fields
        private readonly string _apiKey;
        private readonly string _defaultToEmail;
        private readonly string _defaultTo;

        #endregion

        #region Constructor /init 

        public SendGridHelper(string apiKey, string defaultToEmail, string defaultTo)
        {
            _apiKey = apiKey;
            _defaultTo = defaultTo;
            _defaultToEmail = defaultToEmail;
        }
        #endregion


        #region Public Methods

        /// <summary>
        /// Send email using EmailRequest
        /// </summary>
        /// <param name="email"></param>
        public void Send(EmailRequest email)
        {
            Send(email.FromEmail, email.From, email.ToEmail, email.To, email.Subject, email.Text, email.Html);
        }

        /// <summary>
        /// Send email to the default email address 
        /// </summary>
        /// <param name="fromEmail"></param>
        /// <param name="from"></param>
        /// <param name="subject"></param>
        /// <param name="text"></param>
        /// <param name="attachmentName"></param>
        /// <param name="attachmentContent"></param>
        public void Send(string fromEmail,
                         string from,
                         string subject,
                         string text,
                         string attachmentName = null,
                         byte[] attachmentContent = null)
        {
            Send(fromEmail, from, _defaultToEmail, _defaultTo, subject, text, attachmentName: attachmentName, attachmentContent: attachmentContent);
        }

        /// <summary>
        /// Send email
        /// </summary>
        /// <param name="fromEmail"></param>
        /// <param name="from"></param>
        /// <param name="toEmail"></param>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="text"></param>
        /// <param name="html"></param>
        /// <param name="attachmentName"></param>
        /// <param name="attachmentContent"></param>
        public async void Send(string fromEmail,
                               string from,
                               string toEmail,
                               string to,
                               string subject,
                               string text,
                               string html = null,
                               string attachmentName = null,
                               byte[] attachmentContent = null)
        {
            try
            {
                var client = new SendGridClient(_apiKey);
                var fromEmailAddress = new EmailAddress(fromEmail, from);
                var toEmailAddress = new EmailAddress(toEmail, to);
                var plainTextContent = text;
                var htmlContent = html;
                var msg = MailHelper.CreateSingleEmail(fromEmailAddress, toEmailAddress, subject, plainTextContent, htmlContent);

                //add attachment
                if (attachmentContent != null)
                {
                    var file = Convert.ToBase64String(attachmentContent);
                    msg.AddAttachment(attachmentName, file);
                }

                var response = await client.SendEmailAsync(msg);
            }
            catch (Exception ex)
            {
            }
        }

        #endregion

    }

}
