using Ecommerce.Mobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Ecommerce.Mobile.Services
{
    public class ApiServices : IApiServices
    {
        private readonly string _tokenType = "bearer";

        public async Task<Response<object>> GetListAsync<T>(
        string urlBase,
        string servicePrefix,
        string controller,
        string tokenType,
        string accessToken)
        {
            try
            {

                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                // Pass the handler to httpclient(from you are calling api)
                var client = new HttpClient(clientHandler)
                {
                    BaseAddress = new Uri(urlBase)
                };

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue (
                    tokenType.Equals("") ? _tokenType:tokenType, 
                    accessToken);

                var url = $"{urlBase}{servicePrefix}{controller}";
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response<object>
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                var list = JsonConvert.DeserializeObject<List<T>>(result);
                return new Response<object>
                {
                    IsSuccess = true,
                    Result = list
                };
            }
            catch (Exception ex)
            {
                return new Response<object>
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response<object>> PostAsync<T>(
        string urlBase,
        string servicePrefix,
        string controller,
        T model, 
        string tokenType,
        string accessToken)
        {
            try
            {
                var request = JsonConvert.SerializeObject(model);
                var content = new StringContent(request, Encoding.UTF8, "application/json");

                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                // Pass the handler to httpclient(from you are calling api)
                var client = new HttpClient(clientHandler)
                {
                    BaseAddress = new Uri(urlBase)
                };

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    tokenType.Equals("") ? _tokenType : tokenType,
                    accessToken);


                var url = $"{urlBase}{servicePrefix}{controller}";
                var response = await client.PostAsync(url, content);
                var answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new Response<object>
                    {
                        IsSuccess = false,
                        Message = answer,
                    };
                }

                return new Response<object>
                {
                    IsSuccess = true,
                };
            }
            catch (Exception ex)
            {
                return new Response<object>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<Response<object>> PutAsync<T>(
        string urlBase,
        string servicePrefix,
        string controller,
        int id,
        T model,
        string tokenType,
        string accessToken)
        {
            try
            {
                var request = JsonConvert.SerializeObject(model);
                var content = new StringContent(request, Encoding.UTF8, "application/json");

                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                // Pass the handler to httpclient(from you are calling api)
                var client = new HttpClient(clientHandler)
                {
                    BaseAddress = new Uri(urlBase)
                };

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    tokenType.Equals("") ? _tokenType : tokenType,
                    accessToken);

                var url = $"{urlBase}{servicePrefix}{controller}/{id}";
                var response = await client.PutAsync(url, content);
                var answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new Response<object>
                    {
                        IsSuccess = false,
                        Message = answer,
                    };
                }

                return new Response<object>
                {
                    IsSuccess = true,
                };
            }
            catch (Exception ex)
            {
                return new Response<object>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<Response<object>> DeleteAsync(
        string urlBase,
        string servicePrefix,
        string controller,
        int id,
        string tokenType,
        string accessToken)
        {
            try
            {

                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                // Pass the handler to httpclient(from you are calling api)
                var client = new HttpClient(clientHandler)
                {
                    BaseAddress = new Uri(urlBase)
                };

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    tokenType.Equals("") ? _tokenType : tokenType,
                    accessToken);

                var url = $"{urlBase}{servicePrefix}{controller}/{id}";
                var response = await client.DeleteAsync(url);
                var answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new Response<object>
                    {
                        IsSuccess = false,
                        Message = answer,
                    };
                }

                return new Response<object>
                {
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new Response<object>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<Response<object>> PostGenericAsync<T>(
        string urlBase,
        string servicePrefix,
        string controller,
        string request)
        {
            try
            {
                var content = new StringContent(request, Encoding.UTF8, "application/json");

                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                // Pass the handler to httpclient(from you are calling api)
                var client = new HttpClient(clientHandler)
                {
                    BaseAddress = new Uri(urlBase)
                };


                var url = $"{urlBase}{servicePrefix}{controller}";
                var response = await client.PostAsync(url, content);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response<object>
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }
                
                var obj = JsonConvert.DeserializeObject<T>(result);                
                return new Response<object>
                {
                    IsSuccess = true,
                    Result = obj
                };
            }
            catch (Exception ex)
            {
                return new Response<object>
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
