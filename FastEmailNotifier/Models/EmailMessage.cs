using System;
using System.Collections.Generic;
using System.Text;

namespace FastEmailNotifier.Models
{
    public class EmailMessage
    {
        public string To { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public bool IsHtml { get; set; } = true;
        public List<string> Cc { get; set; } = new List<string>(); // CC recipients
        public List<string> Bcc { get; set; } = new List<string>();// BCC recipients
        public List<string> AlternateRecipients { get; set; } = new List<string>();// Alternate recipients for "To" field
    }
}
