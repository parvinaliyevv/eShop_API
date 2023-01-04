namespace eShop.Application.Queries.Products;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQueryRequest, GetProductsQueryResponse>
{
    private readonly IProductReadRepository _readRepository;

    private readonly IMapper _mapper;
    private readonly IStorageManager _storageManager;


    public GetProductsQueryHandler(IProductReadRepository readRepository, IMapper mapper, IStorageManager storageManager)
    {
        _readRepository = readRepository;

        _mapper = mapper;
        _storageManager = storageManager;
    }


    public async Task<GetProductsQueryResponse> Handle(GetProductsQueryRequest request, CancellationToken cancellationToken)
    {
        var dtos = new List<ProductDto>();

        var dbProducts = (await _readRepository.GetAllAsync(tracking: false)).Include("Category").OrderBy(product => product.CreatedDateTime);
        var totalProductCount = dbProducts.Count();
        
        var products = await dbProducts.Skip(request.Page * request.Size).Take(request.Size).ToListAsync();
        products.ForEach(product =>
        {
            var productDto = _mapper.Map<ProductDto>(product);
            productDto.ImageUrl = _storageManager.GetSignedUrl(product.Image);

            dtos.Add(productDto);
        });

        return new(totalProductCount, dtos);
    }
}

public record GetProductsQueryRequest(int Page = 0, ushort Size = 5) : IRequest<GetProductsQueryResponse>;

public record GetProductsQueryResponse(int TotalCount, object Products);
