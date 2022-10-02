using Kafka.Base.Producer;

using Microsoft.AspNetCore.Mvc;

using Models;

namespace Kafka.Producer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerRegisterController : ControllerBase
    {
        private readonly IMessageProducer _messageProducer;

        public CustomerRegisterController(IMessageProducer messageProducer)
        {
            _messageProducer = messageProducer;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCustomerAsync([FromBody] Customer customer, CancellationToken cancellationToken)
        {
            await _messageProducer.ProduceAsync(customer.Id.ToString(), customer, cancellationToken);
            return Ok(await Task.FromResult(true));
        }
    }
}