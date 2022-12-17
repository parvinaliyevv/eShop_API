namespace eShop.Application.Commands.Products;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IProductWriteRepository _writeRepository;


    public CreateProductCommandHandler(IMapper mapper, IProductWriteRepository writeRepository)
    {
        _mapper = mapper;
        _writeRepository = writeRepository;
    }


    public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request.Dto);

        if (product.CategoryId == Guid.Empty) product.CategoryId = null;

        await _writeRepository.AddAsync(product);
        await _writeRepository.SaveChangesAsync();

        return new();
    }
}

public record CreateProductCommandRequest(CreateProductDto Dto) : IRequest<CreateProductCommandResponse>;

public record CreateProductCommandResponse;
