namespace Vicarius.io.HomeAssignment.IServices
{
    public interface IElasticService
    {
        Task<HttpResponseMessage> CreateIndex(string indexName);
        Task<HttpResponseMessage> CreateDocument(string indexName, ElasticDocument document);
        Task<string> GetDocumentById(string indexName, string id);
    }
}
