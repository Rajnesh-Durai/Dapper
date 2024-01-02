using MediatR;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Application.Features.OrderDetail.Command;
using SampleProject.Application.Features.OrderDetail.Queries;
using SampleProject.Application.ViewModels;

namespace SampleProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        public readonly ILogger<OrderItemsController> logger;
        private readonly IMediator mediator;
        public OrderItemsController(ILogger<OrderItemsController> logger, IMediator mediator)
        {

            this.logger = logger;
            this.mediator = mediator;
        }
        [HttpGet("GetAllOrderItems")]
        public async Task<ActionResult<List<OrderItemsResponse>>> GetAllOrderDetails()
        {
            var query = new GetAllOrderItemsQuery();
            var orders = await this.mediator.Send(query);
            return Ok(orders);
        }
        [HttpGet("GetOrderItemsById")]
        public async Task<ActionResult<OrderItemsResponse>> GetOrderDetailsById(int Id)
        {
            var query = new GetByIdOrderDetailsQuery(Id);
            var orders = await this.mediator.Send(query);
            return Ok(orders);
        }
        [HttpPost("AddOrderItems")]
        public async Task<ActionResult<string>> AddOrderDetails([FromBody] CheckoutOrderItemsCommand entity)
        {
            var orders = await this.mediator.Send(entity);
            return Ok(orders);
        }
        [HttpPut("UpdateOrderItems")]
        public async Task<ActionResult<string>> UpdateOrderDetails([FromBody] UpdateOrderItemsCommand entity)
        {
            var orders = await this.mediator.Send(entity);
            return Ok(orders);
        }
        [HttpDelete("DeleteOrderItem")]
        public async Task<ActionResult<string>> DeleteOrderDetails(int Id)
        {
            var deleteCommand = new DeleteOrderItemsCommand() { Id = Id };
            var orders = await this.mediator.Send(deleteCommand);
            return Ok(orders);
        }
    }
}
