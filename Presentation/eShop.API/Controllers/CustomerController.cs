namespace eShop.API.Controllers;

[ApiController, Authorize]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;


    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpPost("[Action]")]
    public async Task<IActionResult> Create([FromBody] CreateCustomerDto dto)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var request = new CreateCustomerCommandRequest(dto);
            var response = await _mediator.Send(request);

            return StatusCode((int)HttpStatusCode.Created);
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }

    [HttpGet("[Action]")]
    public async Task<IActionResult> Read([FromQuery] GetCustomersQueryRequest request)
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
    public async Task<IActionResult> Update([FromBody] UpdateCustomerDto dto)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var request = new UpdateCustomerCommandRequest(dto);
            var response = await _mediator.Send(request);

            return response is not null ? StatusCode((int)HttpStatusCode.OK) : StatusCode((int)HttpStatusCode.NoContent);
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }

    [HttpDelete("[Action]")]
    public async Task<IActionResult> Delete([FromQuery] DeleteCustomerCommandRequest request)
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
