using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Catalog.API.repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogRepository _repository;
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(ICatalogRepository repository, ILogger<CatalogController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CatalogModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CatalogModel>>> GetCatalogs()
        {
            var catalogs = await _repository.GetCatalogs();
            return Ok(catalogs);
        }

        [HttpGet("{id:length(24)}", Name = "GetCatlog")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(CatalogModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CatalogModel>> GetCatalogById(string id)
        {
            var catalog = await _repository.GetCatalog(id);

            if (catalog == null)
            {
                _logger.LogError($"Catalog with id: {id}, not found.");
                return NotFound();
            }

            return Ok(catalog);
        }


        [Route("[action]/{name}", Name = "GetCatalogByName")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<CatalogModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CatalogModel>>> GetCatalogByName(string name)
        {
            var items = await _repository.GetCatalogByName(name);
            if (items == null)
            {
                _logger.LogError($"Catalog with name: {name} not found.");
                return NotFound();
            }
            return Ok(items);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CatalogModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CatalogModel>> CreateCatalog([FromBody] CatalogModel catalog)
        {
            await _repository.CreateCatalog(catalog);

            return CreatedAtRoute("GetCatlog", new { id = catalog.Id }, catalog);
        }

        [HttpPut]
        [ProducesResponseType(typeof(CatalogModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateCatalog([FromBody] CatalogModel catalog)
        {
            return Ok(await _repository.UpdateCatalog(catalog));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteCatalog")]
        [ProducesResponseType(typeof(CatalogModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProductById(string id)
        {
            return Ok(await _repository.DeleteCatalog(id));
        }

    }
}
