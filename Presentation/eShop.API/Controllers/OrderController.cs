namespace eShop.API.Controllers;

[ApiController, Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IMapper _mapper;

    private readonly IOrderReadRepository _orderReadRepository;
    private readonly IOrderWriteRepository _orderWriteRepository;


    public OrderController(IMapper mapper, IOrderReadRepository orderReadRepository, IOrderWriteRepository orderWriteRepository)
    {
        _mapper = mapper;

        _orderReadRepository = orderReadRepository;
        _orderWriteRepository = orderWriteRepository;
    }


    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateOrderViewModel viewModel)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var order = _mapper.Map<Order>(viewModel);

            if (order.CustomerId == Guid.Empty) order.CustomerId = null;

            await _orderWriteRepository.AddAsync(order);
            await _orderWriteRepository.SaveChangesAsync();

            return StatusCode((int)HttpStatusCode.Created);
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }

    [HttpGet("Read")]
    public async Task<IActionResult> Read([FromQuery] Pagination pagination)
    {
        try
        {
            var viewModels = new List<OrderViewModel>();

            var dbOrders = (await _orderReadRepository.GetAllAsync(tracking: false)).OrderBy(order => order.CreatedDateTime);
            var totalOrderCount = dbOrders.Count();
            var orders = await dbOrders.Skip(pagination.Page * pagination.Size).Take(pagination.Size).ToListAsync();

            orders.ForEach(order => viewModels.Add(_mapper.Map<OrderViewModel>(order)));

            return Ok(new { totalOrderCount, viewModels });
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateOrderViewModel viewModel)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!await _orderWriteRepository.ExistsAsync(viewModel.Id))
                return StatusCode((int)HttpStatusCode.NoContent);

            var order = _mapper.Map<Order>(viewModel);

            if (order.CustomerId == Guid.Empty) order.CustomerId = null;

            await _orderWriteRepository.RemoveAsync(viewModel.Id);
            await _orderWriteRepository.SaveChangesAsync();

            await _orderWriteRepository.AddAsync(order);
            await _orderWriteRepository.SaveChangesAsync();

            return StatusCode((int)HttpStatusCode.OK);
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete([FromQuery] string id)
    {
        try
        {
            if (!await _orderWriteRepository.ExistsAsync(id))
                return StatusCode((int)HttpStatusCode.NoContent);

            await _orderWriteRepository.RemoveAsync(id);
            await _orderWriteRepository.SaveChangesAsync();

            return StatusCode((int)HttpStatusCode.OK);
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }
}
