using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using Vicarius.io.HomeAssignment.IServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Vicarius.io.HomeAssignment.Services
{
    public class GenericRestHttpClient : IGenericRestHttpClient
    {
        private const string JSON_MIME_TYPE = "application/json";
        private readonly IHttpClientFactory _clientFactory;
        private IOptions<AppSettings> _appSettings;
        private HttpClient _httpWebApiClient;

        public GenericRestHttpClient(IHttpClientFactory clientFactory, IOptions<AppSettings> appSettings)
        {
            _clientFactory = clientFactory;
            _appSettings = appSettings;
            _httpWebApiClient = BuildWebApiClient();
        }

        private HttpClient? BuildWebApiClient()
        {
            _httpWebApiClient = _clientFactory.CreateClient();
            _httpWebApiClient.BaseAddress = new Uri(_appSettings.Value.ServiceBaseAddress);
            _httpWebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JSON_MIME_TYPE));
            _httpWebApiClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            _httpWebApiClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
            _httpWebApiClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(new ProductHeaderValue("BaseWebApiClient", "0.1")));
            return _httpWebApiClient;
        }

        public async Task<HttpResponseMessage> ExecutePostFlow(string ElasticSearchIndex, ElasticDocument document)
        {
            string url = BuildUrl(ElasticSearchIndex);
            return await _httpWebApiClient.PostAsJsonAsync(url, document);
        }

        private string BuildUrl(string ElasticSearchIndex)
        {
            return string.Format("{0}/{1}/_doc/", _appSettings.Value.ServiceBaseAddress, ElasticSearchIndex);
        }

        public async Task<HttpResponseMessage> ExecutePutFlow(string ElasticSearchIndex)
        {
            string url = string.Format("{0}/{1}", _appSettings.Value.ServiceBaseAddress, ElasticSearchIndex);
            //var requestContent = new StringContent(ElasticSearchIndex, Encoding.UTF8, "application/json");
            return await _httpWebApiClient.PutAsync(url, null);
        }

        public async Task<HttpResponseMessage> ExecuteGetFlow(string ElasticSearchIndex, string id)
        {
            string? url = string.Format("{0}/{1}/_doc/{2}", _appSettings.Value.ServiceBaseAddress, ElasticSearchIndex, id);
            return await _httpWebApiClient.GetAsync(url);
        }
    }
}
