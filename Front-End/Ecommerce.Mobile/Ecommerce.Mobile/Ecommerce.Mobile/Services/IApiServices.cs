using Ecommerce.Mobile.Models;
using System.Threading.Tasks;

namespace Ecommerce.Mobile.Services
{
    public interface IApiServices
    {

        Task<Response<object>> GetListAsync<T>(
           string urlBase,
           string servicePrefix,
           string controller,
           string tokenType,
           string accessToken);

        Task<Response<object>> PostAsync<T>(
            string urlBase,
            string servicePrefix,
            string controller,
            T model,
            string tokenType,
            string accessToken);

        Task<Response<object>> PutAsync<T>(
            string urlBase,
            string servicePrefix,
            string controller,
            int id,
            T model,
            string tokenType,
            string accessToken);

        Task<Response<object>> DeleteAsync(
            string urlBase,
            string servicePrefix,
            string controller,
            int id,
            string tokenType,
            string accessToken);

        Task<Response<object>> PostGenericAsync<T>(
            string urlBase,
            string servicePrefix,
            string controller,
            string parameters);
    }
}
