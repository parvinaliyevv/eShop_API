namespace eShop.Application.Commands.Products;

public class AddProductCommandHandler : IRequestHandler<AddProductCommandRequest, AddProductCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IProductWriteRepository _productWriteRepository;


    public AddProductCommandHandler(IMapper mapper, IProductWriteRepository productWriteRepository)
    {
        _mapper = mapper;
        _productWriteRepository = productWriteRepository;
    }


    public async Task<AddProductCommandResponse> Handle(AddProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request.Dto);

        if (product.CategoryId == Guid.Empty) product.CategoryId = null;

        await _productWriteRepository.AddAsync(product);
        await _productWriteRepository.SaveChangesAsync();

        return new();
    }
}

public record AddProductCommandRequest(CreateProductDto Dto) : IRequest<AddProductCommandResponse>;

public record AddProductCommandResponse();
