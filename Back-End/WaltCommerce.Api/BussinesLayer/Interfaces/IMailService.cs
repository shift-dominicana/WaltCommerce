

using BussinesLayer.Models.Mails;
using System.Threading.Tasks;

namespace BussinesLayer.Interfaces
{
    public interface IMailService
    {
        Task SendEmailAsync(Mail mailRequest);
    }
}
