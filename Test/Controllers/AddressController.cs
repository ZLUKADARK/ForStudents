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
                return Ok(await _services.GetAsync());
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
                return Ok(await _services.GetAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<AddressListDto>> Post([FromBody] AddressListDto value)
        {
            try
            {
                return Ok(await _services.CreateAsync(value));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AddressListDto>> Put(int id, [FromBody] AddressListDto value)
        {
            if(id != value.Id)
                return BadRequest();

            try
            {
                return Ok(await _services.UpdateAsync(value));
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
                return Ok(await _services.DeleteAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("AddTo")]
        public async Task<ActionResult<AddressDto>> AddTo(AddressToPerson value)
        {
            try
            {
                return Ok(await _services.AddToPersonAsync(value));
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
                return Ok(await _services.CreateWithPersonAsync(value));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("RemovePersons")]
        public async Task<ActionResult<AddressDto>> RemovePersons(AddressPersonsDto value)
        {
            try
            {
                return Ok(await _services.RemoveFromAddressAsync(value.AddressId, value.PersonsId));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("AddRangePersons")]
        public async Task<ActionResult<AddressDto>> AddRangePersons(AddressPersonsDto value)
        {
            try
            {
                return Ok(await _services.AddPersonsRangeAsync(value.AddressId, value.PersonsId));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
