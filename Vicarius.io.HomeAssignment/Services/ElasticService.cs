using Vicarius.io.HomeAssignment.IServices;

namespace Vicarius.io.HomeAssignment.Services
{
    public class ElasticService : IElasticService
    {
        IGenericRestHttpClient _genericRestHttpClient;

        public ElasticService(IGenericRestHttpClient genericRestHttpClient)
        {
            _genericRestHttpClient = genericRestHttpClient;
        }
        public HttpResponseMessage CreateDocument(string indexName, ElasticDocument document)
        {
            var r= _genericRestHttpClient.ExecutePostFlow(indexName, document);
            var result = r.Result;
            return result;
        }

        public HttpResponseMessage CreateIndex(string indexName)
        {
            var r = _genericRestHttpClient.ExecutePutFlow(indexName);
            var result = r.Result;
            return result;
        }
    }
}
