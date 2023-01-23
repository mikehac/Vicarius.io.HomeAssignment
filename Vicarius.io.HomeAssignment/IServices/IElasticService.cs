namespace Vicarius.io.HomeAssignment.IServices
{
    public interface IElasticService
    {
        HttpResponseMessage CreateIndex(string indexName);
        HttpResponseMessage CreateDocument(string indexName, ElasticDocument document);
    }
}
