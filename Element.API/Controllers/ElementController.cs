using ElementWords.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ElementAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ElementController(IElementService elementService) : ControllerBase
    {
        IElementService _elementService = elementService;

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string word)
        {
            var elements = await _elementService.elementalForms(word);

            return Ok(elements);
        }
    }
}
