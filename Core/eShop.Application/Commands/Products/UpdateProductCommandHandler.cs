namespace eShop.Application.Commands.Products;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
{
    private readonly IProductWriteRepository _writeRepository;

    private readonly IMapper _mapper;
    private readonly IStorageManager _storageManager;


    public UpdateProductCommandHandler(IProductWriteRepository writeRepository, IMapper mapper, IStorageManager storageManager)
    {
        _writeRepository = writeRepository;

        _mapper = mapper;
        _storageManager = storageManager;
    }


    public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        if (!_writeRepository.Exists(request.Dto.Id)) return null;

        var product = _mapper.Map<Product>(request.Dto);

        if (product.CategoryId == Guid.Empty) product.CategoryId = null;

        await _writeRepository.RemoveAsync(request.Dto.Id);
        await _writeRepository.SaveChangesAsync();

        await _storageManager.UploadFileAsync(request.Dto.Image, product.Image);

        await _writeRepository.AddAsync(product);
        await _writeRepository.SaveChangesAsync();

        return new();
    }
}

public record UpdateProductCommandRequest(UpdateProductDto Dto) : IRequest<UpdateProductCommandResponse>;

public record UpdateProductCommandResponse;
