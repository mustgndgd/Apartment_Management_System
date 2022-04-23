using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB_CRUD.Models;
using MongoDB_CRUD.Services;

namespace MongoDB_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _customerService;
        public PaymentController(IPaymentService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _customerService.GetAllAsync().ConfigureAwait(false));
        }
        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> Get(string id)
        {
            var customer = await _customerService.GetByIdAsync(id).ConfigureAwait(false);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        [HttpPost]
        public async Task<IActionResult> Create(PaymentRecord record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _customerService.CreateAsync(record).ConfigureAwait(false);
            return Ok(record.Id);
        }
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, PaymentRecord recordIn)
        {
            var customer = await _customerService.GetByIdAsync(id).ConfigureAwait(false);
            if (customer == null)
            {
                return NotFound();
            }
            await _customerService.UpdateAsync(id, recordIn).ConfigureAwait(false);
            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var customer = await _customerService.GetByIdAsync(id).ConfigureAwait(false);
            if (customer == null)
            {
                return NotFound();
            }
            await _customerService.DeleteAsync(customer.Id).ConfigureAwait(false);
            return NoContent();
        }
    }
}
