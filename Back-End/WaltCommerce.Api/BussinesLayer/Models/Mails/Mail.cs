using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace BussinesLayer.Models.Mails
{
    public class Mail
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<IFormFile> Attachments { get; set; }
    }
}
