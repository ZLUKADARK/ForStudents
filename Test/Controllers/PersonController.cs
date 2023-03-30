using Microsoft.AspNetCore.Mvc;
using Test.BLL.Interfaces;
using Test.Domain.DataTransferObject;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonServices _personServices;

        public PersonController(IPersonServices personServices) 
        {
            _personServices = personServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonDtoList>>> Get()
        {
            try
            {
                return Ok(await _personServices.GetAsync());
            }
            catch (Exception ex) 
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDto>> Get(int id)
        {
            try
            {
                return Ok(await _personServices.GetAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<PersonDto>> Post([FromBody] PersonDtoList value)
        {
            try
            {
                return Ok(await _personServices.CreateAsync(value));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PersonDto>> Put(int id, [FromBody] PersonDtoList value)
        {
            if(id != value.Id)
                return BadRequest();

            try
            {
                return Ok(await _personServices.UpdateAsync(value));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PersonDto>> DeleteAsync(int id)
        {
            try
            {
                return Ok(await _personServices.DeleteAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("AddTo")]
        public async Task<ActionResult<PersonDto>> AddTo(AddressToPerson value)
        {
            try
            {
                return Ok(await _personServices.AddToAddressAsync(value));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
