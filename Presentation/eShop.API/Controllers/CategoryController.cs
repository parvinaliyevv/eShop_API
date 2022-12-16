namespace eShop.API.Controllers;

[ApiController, Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IMapper _mapper;

    private readonly ICategoryReadRepository _categoryReadRepository;
    private readonly ICategoryWriteRepository _categoryWriteRepository;


    public CategoryController(IMapper mapper, ICategoryReadRepository categoryReadRepository, ICategoryWriteRepository categoryWriteRepository)
    {
        _mapper = mapper;

        _categoryReadRepository = categoryReadRepository;
        _categoryWriteRepository = categoryWriteRepository;
    }


    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateCategoryDto viewModel)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var category = _mapper.Map<Category>(viewModel);

            await _categoryWriteRepository.AddAsync(category);
            await _categoryWriteRepository.SaveChangesAsync();

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
            var viewModels = new List<CategoryDto>();

            var dbCategories = (await _categoryReadRepository.GetAllAsync(tracking: false)).OrderBy(category => category.CreatedDateTime);
            var totalCategoryCount = dbCategories.Count();
            var categories = await dbCategories.Skip(pagination.Page * pagination.Size).Take(pagination.Size).ToListAsync();

            categories.ForEach(category => viewModels.Add(_mapper.Map<CategoryDto>(category)));

            return Ok(new { totalCategoryCount, viewModels });
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateCategoryDto viewModel)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!await _categoryWriteRepository.ExistsAsync(viewModel.Id))
                return StatusCode((int)HttpStatusCode.NoContent);

            var category = _mapper.Map<Category>(viewModel);

            await _categoryWriteRepository.RemoveAsync(viewModel.Id);
            await _categoryWriteRepository.SaveChangesAsync();

            await _categoryWriteRepository.AddAsync(category);
            await _categoryWriteRepository.SaveChangesAsync();

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
            if (!await _categoryWriteRepository.ExistsAsync(id))
                return StatusCode((int)HttpStatusCode.NoContent);

            await _categoryWriteRepository.RemoveAsync(id);
            await _categoryWriteRepository.SaveChangesAsync();

            return StatusCode((int)HttpStatusCode.OK);
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }
}
