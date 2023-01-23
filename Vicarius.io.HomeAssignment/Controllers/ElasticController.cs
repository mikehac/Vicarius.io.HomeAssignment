using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vicarius.io.HomeAssignment.IServices;

namespace Vicarius.io.HomeAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElasticController : ControllerBase
    {
        private readonly IElasticService _elasticService;

        public ElasticController(IElasticService elasticService)
        {
            _elasticService = elasticService;
        }

        [HttpGet]
        public async Task<IActionResult> CreateIndex(string indexName)
        {
            var result = await _elasticService.CreateIndex(indexName);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddDocumentToIndex(string indexName, ElasticDocument document)
        {
            var result = await _elasticService.CreateDocument(indexName, document);
            return Ok(result);
        }

        [HttpGet("DocumentById")]
        public async Task<ActionResult<string>> GetDocumentById(string indexName, string id)
        {
            return Ok(await _elasticService.GetDocumentById(indexName, id));
        }
    }
}
