namespace eShop.Application.Queries.Products;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQueryRequest, GetProductsQueryResponse>
{
    private readonly IMapper _mapper;

    private readonly IProductReadRepository _productReadRepository;


    public GetProductsQueryHandler(IMapper mapper, IProductReadRepository productReadRepository)
    {
        _mapper = mapper;
        _productReadRepository = productReadRepository;
    }


    public async Task<GetProductsQueryResponse> Handle(GetProductsQueryRequest request, CancellationToken cancellationToken)
    {
        var viewModels = new List<ProductDto>();

        var dbProducts = (await _productReadRepository.GetAllAsync(tracking: false)).Include("Category").OrderBy(product => product.CreatedDateTime);
        var totalProductCount = dbProducts.Count();
        var products = await dbProducts.Skip(request.Page * request.Size).Take(request.Size).ToListAsync();

        products.ForEach(product => viewModels.Add(_mapper.Map<ProductDto>(product)));

        return new GetProductsQueryResponse(totalProductCount, products);
    }
}

public record GetProductsQueryRequest(int Page, byte Size) : IRequest<GetProductsQueryResponse>;

public record GetProductsQueryResponse(int TotalCount, object Products);
