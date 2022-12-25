namespace eShop.API.Controllers;

[ApiController, Authorize]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;


    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpPost("[Action]")]
    public async Task<IActionResult> Create([FromBody] CreateCategoryDto dto)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var request = new CreateCategoryCommandRequest(dto);
            var response = await _mediator.Send(request);

            return StatusCode((int)HttpStatusCode.Created);
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }

    [HttpGet("[Action]")]
    public async Task<IActionResult> Read([FromQuery] GetCategoriesQueryRequest request)
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
    public async Task<IActionResult> Update([FromBody] UpdateCategoryDto dto)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var request = new UpdateCategoryCommandRequest(dto);
            var response = await _mediator.Send(request);

            return response is not null ? StatusCode((int)HttpStatusCode.OK) : StatusCode((int)HttpStatusCode.NoContent);
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }

    [HttpDelete("[Action]")]
    public async Task<IActionResult> Delete([FromQuery] DeleteCategoryCommandRequest request)
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
