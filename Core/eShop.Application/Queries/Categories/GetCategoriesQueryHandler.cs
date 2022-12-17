namespace eShop.Application.Queries.Categories;

public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQueryRequest, GetCategoriesQueryResponse>
{
    private readonly IMapper _mapper;
    private readonly ICategoryReadRepository _readRepository;


    public GetCategoriesQueryHandler(IMapper mapper, ICategoryReadRepository readRepository)
    {
        _mapper = mapper;
        _readRepository = readRepository;
    }


    public async Task<GetCategoriesQueryResponse> Handle(GetCategoriesQueryRequest request, CancellationToken cancellationToken)
    {
        var dtos = new List<CategoryDto>();

        var dbCategories = (await _readRepository.GetAllAsync(tracking: false)).OrderBy(category => category.CreatedDateTime);
        var totalCategoryCount = dbCategories.Count();

        var categories = await dbCategories.Skip(request.Page * request.Size).Take(request.Size).ToListAsync();
        categories.ForEach(category => dtos.Add(_mapper.Map<CategoryDto>(category)));

        return new(totalCategoryCount, dtos);
    }
}

public record GetCategoriesQueryRequest(int Page = 0, ushort Size = 5) : IRequest<GetCategoriesQueryResponse>;

public record GetCategoriesQueryResponse(int TotalCount, object Categories);
