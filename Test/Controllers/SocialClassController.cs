using Microsoft.AspNetCore.Mvc;
using Test.BLL.Interfaces;
using Test.Domain.DataTransferObject;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialClassController : ControllerBase
    {
        private readonly ISocialClassServices _services;

        public SocialClassController(ISocialClassServices services) 
        { 
            _services = services;
        }

        [HttpGet]
        public async Task<IEnumerable<SocialClassListDto>> Get()
        {
            return await _services.Get();
        }

        [HttpGet("{id}")]
        public async Task<SocialClassDto> Get(int id)
        {
            return await _services.Get(id);
        }

        [HttpPost]
        public async Task<SocialClassDto> Post([FromBody] SocialClassDto value)
        {
            return await _services.Create(value);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SocialClassDto>> Put(int id, [FromBody] SocialClassDto value)
        {
            if (value == null & value.Id != id)
                return BadRequest();
            return await _services.Update(value);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SocialClassDto>> Delete(int id)
        {
            return await _services.Delete(id);
        }
    }
}
