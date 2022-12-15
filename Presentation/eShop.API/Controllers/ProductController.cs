namespace eShop.API.Controllers;

[ApiController, Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IMapper _mapper;

    private readonly IProductReadRepository _productReadRepository;
    private readonly IProductWriteRepository _productWriteRepository;


    public ProductController(IMapper mapper, IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
    {
        _mapper = mapper;

        _productReadRepository = productReadRepository;
        _productWriteRepository = productWriteRepository;
    }


    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateProductViewModel viewModel)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var product = _mapper.Map<Product>(viewModel);

            if (product.CategoryId == Guid.Empty) product.CategoryId = null;

            await _productWriteRepository.AddAsync(product);
            await _productWriteRepository.SaveChangesAsync();

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
            var viewModels = new List<ProductViewModel>();

            var dbProducts = (await _productReadRepository.GetAllAsync(tracking: false)).Include("Category").OrderBy(product => product.CreatedDateTime);
            var totalProductCount = dbProducts.Count();
            var products = await dbProducts.Skip(pagination.Page * pagination.Size).Take(pagination.Size).ToListAsync();

            products.ForEach(product => viewModels.Add(_mapper.Map<ProductViewModel>(product)));

            return Ok(new { totalProductCount, viewModels });
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateProductViewModel viewModel)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!await _productWriteRepository.ExistsAsync(viewModel.Id))
                return StatusCode((int)HttpStatusCode.NoContent);

            var product = _mapper.Map<Product>(viewModel);

            if (product.CategoryId == Guid.Empty) product.CategoryId = null;

            await _productWriteRepository.RemoveAsync(viewModel.Id);
            await _productWriteRepository.SaveChangesAsync();

            await _productWriteRepository.AddAsync(product);
            await _productWriteRepository.SaveChangesAsync();

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
            if (! await _productWriteRepository.ExistsAsync(id)) 
                return StatusCode((int)HttpStatusCode.NoContent);

            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveChangesAsync();

            return StatusCode((int)HttpStatusCode.OK);
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }
}
