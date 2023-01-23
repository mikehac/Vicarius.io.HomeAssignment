namespace Vicarius.io.HomeAssignment.IServices
{
    public interface IGenericRestHttpClient
    {
        Task<HttpResponseMessage> ExecutePostFlow(string ElasticSearchIndex, ElasticDocument document);
        Task<HttpResponseMessage> ExecutePutFlow(string ElasticSearchIndex);
        Task<HttpResponseMessage> ExecuteGetFlow(string ElasticSearchIndex, string id);
    }
}
