

using BussinesLayer.Models.Mails;
using System.Threading.Tasks;

namespace BussinesLayer.Interfaces.Mails
{
    public interface IMailService
    {
        Task SendEmailAsync(Mail mailRequest);
    }
}
