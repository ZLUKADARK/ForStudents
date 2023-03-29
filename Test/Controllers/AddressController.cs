using Microsoft.AspNetCore.Mvc;
using Test.BLL.Interfaces;
using Test.Domain.DataTransferObject;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressServices _services;

        public AddressController(IAddressServices services) 
        {
            _services = services;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressListDto>>> Get()
        {
            try
            {
                return Ok(await _services.Get());
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AddressDto>> Get(int id)
        {
            try
            {
                return Ok(await _services.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<AddressDto>> Post([FromBody] AddressDto value)
        {
            try
            {
                return Ok(await _services.Create(value));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AddressDto>> Put(int id, [FromBody] AddressDto value)
        {
            if(id != value.Id)
                return BadRequest();

            try
            {
                return Ok(await _services.Update(value));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AddressDto>> Delete(int id)
        {
            try
            {
                return Ok(await _services.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("AddTo")]
        public async Task<ActionResult<AddressDto>> AddTo(AddressAddToPerson value)
        {
            try
            {
                return Ok(await _services.AddToPerson(value));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("CreateWithPersons")]
        public async Task<ActionResult<AddressDto>> CreateWithPersons(AddressDto value)
        {
            try
            {
                return Ok(await _services.CreateWithPerson(value));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
