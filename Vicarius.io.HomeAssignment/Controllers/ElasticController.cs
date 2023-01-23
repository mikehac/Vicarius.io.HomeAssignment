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
        public IActionResult CreateIndex(string indexName)
        {
            var result = _elasticService.CreateIndex(indexName);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddDocumentToIndex(string indexName, ElasticDocument document)
        {
            var result = _elasticService.CreateDocument(indexName, document);
            return Ok(result);
        }
    }
}
