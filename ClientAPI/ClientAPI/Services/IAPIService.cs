using System.Net.Http;

namespace ClientAPI.Services
{
    public interface IAPIService
    {
        public HttpClient Client { get; }
    }
}