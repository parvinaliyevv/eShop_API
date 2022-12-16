namespace eShop.API.Controllers;

[ApiController, Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly IMapper _mapper;

    private readonly ICustomerReadRepository _customerReadRepository;
    private readonly ICustomerWriteRepository _customerWriteRepository;


    public CustomerController(IMapper mapper, ICustomerReadRepository customerReadRepository, ICustomerWriteRepository customerWriteRepository)
    {
        _mapper = mapper;

        _customerReadRepository = customerReadRepository;
        _customerWriteRepository = customerWriteRepository;
    }


    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateCustomerDto viewModel)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var customer = _mapper.Map<Customer>(viewModel);

            await _customerWriteRepository.AddAsync(customer);
            await _customerWriteRepository.SaveChangesAsync();

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
            var viewModels = new List<CustomerDto>();

            var dbCustomers = (await _customerReadRepository.GetAllAsync(tracking: false)).OrderBy(customer => customer.CreatedDateTime);
            var totalCustomerCount = dbCustomers.Count();
            var customers = await dbCustomers.Skip(pagination.Page * pagination.Size).Take(pagination.Size).ToListAsync();

            customers.ForEach(customer => viewModels.Add(_mapper.Map<CustomerDto>(customer)));

            return Ok(new { totalCustomerCount, viewModels });
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateCustomerDto viewModel)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!await _customerWriteRepository.ExistsAsync(viewModel.Id))
                return StatusCode((int)HttpStatusCode.NoContent);

            var customer = _mapper.Map<Customer>(viewModel);

            await _customerWriteRepository.RemoveAsync(viewModel.Id);
            await _customerWriteRepository.SaveChangesAsync();

            await _customerWriteRepository.AddAsync(customer);
            await _customerWriteRepository.SaveChangesAsync();

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
            if (!await _customerWriteRepository.ExistsAsync(id))
                return StatusCode((int)HttpStatusCode.NoContent);

            await _customerWriteRepository.RemoveAsync(id);
            await _customerWriteRepository.SaveChangesAsync();

            return StatusCode((int)HttpStatusCode.OK);
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }
}
