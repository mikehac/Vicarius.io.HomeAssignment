using System.Text;
using Vicarius.io.HomeAssignment.IServices;
using Vicarius.io.HomeAssignment.ResponseDtos;

namespace Vicarius.io.HomeAssignment.Services
{
    public class ElasticService : IElasticService
    {
        IGenericRestHttpClient _genericRestHttpClient;

        public ElasticService(IGenericRestHttpClient genericRestHttpClient)
        {
            _genericRestHttpClient = genericRestHttpClient;
        }
        public async Task<HttpResponseMessage> CreateDocument(string indexName, ElasticDocument document)
        {
            return await _genericRestHttpClient.ExecutePostFlow(indexName, document);
        }

        public async Task<HttpResponseMessage> CreateIndex(string indexName)
        {
            return await _genericRestHttpClient.ExecutePutFlow(indexName);
        }

        public async Task<string> GetDocumentById(string indexName, string id)
        {
            var result = await _genericRestHttpClient.ExecuteGetFlow(indexName, id);
            Stream receiveStream = await result.Content.ReadAsStreamAsync();
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
            return readStream.ReadToEnd();
        }
    }
}
