namespace eShop.API.Controllers;

[ApiController, Authorize]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;


    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpPost("[Action]")]
    public async Task<IActionResult> Create([FromBody] CreateOrderDto dto)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var request = new CreateOrderCommandRequest(dto);
            var response = await _mediator.Send(request);

            return StatusCode((int)HttpStatusCode.Created);
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }

    [HttpGet("[Action]")]
    public async Task<IActionResult> Read([FromQuery] GetOrdersQueryRequest request)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var response = await _mediator.Send(request);

            return Ok(response);
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }

    [HttpPut("[Action]")]
    public async Task<IActionResult> Update([FromBody] UpdateOrderDto dto)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var request = new UpdateOrderCommandRequest(dto);
            var response = await _mediator.Send(request);

            return response is not null ? StatusCode((int)HttpStatusCode.OK) : StatusCode((int)HttpStatusCode.NoContent);
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }

    [HttpDelete("[Action]")]
    public async Task<IActionResult> Delete([FromQuery] DeleteOrderCommandRequest request)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var response = await _mediator.Send(request);

            return response is not null ? StatusCode((int)HttpStatusCode.OK) : StatusCode((int)HttpStatusCode.NoContent);
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }
}
