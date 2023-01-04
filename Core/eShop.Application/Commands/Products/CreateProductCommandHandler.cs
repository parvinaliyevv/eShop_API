namespace eShop.Application.Commands.Products;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
{
    private readonly IProductWriteRepository _writeRepository;

    private readonly IMapper _mapper;
    private readonly IStorageManager _storageManager;


    public CreateProductCommandHandler(IProductWriteRepository writeRepository, IMapper mapper, IStorageManager storageManager)
    {
        _writeRepository = writeRepository;

        _mapper = mapper;
        _storageManager = storageManager;
    }


    public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request.Dto);

        if (product.CategoryId == Guid.Empty) product.CategoryId = null;

        await _storageManager.UploadFileAsync(request.Dto.Image, product.Image);

        await _writeRepository.AddAsync(product);
        await _writeRepository.SaveChangesAsync();

        return new();
    }
}

public record CreateProductCommandRequest(CreateProductDto Dto) : IRequest<CreateProductCommandResponse>;

public record CreateProductCommandResponse;
