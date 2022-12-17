namespace eShop.Application.Commands.Products;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IProductWriteRepository _writeRepository;


    public UpdateProductCommandHandler(IMapper mapper, IProductWriteRepository writeRepository)
    {
        _mapper = mapper;
        _writeRepository = writeRepository;
    }


    public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        if (!_writeRepository.Exists(request.Dto.Id)) return null;

        var product = _mapper.Map<Product>(request.Dto);

        if (product.CategoryId == Guid.Empty) product.CategoryId = null;

        await _writeRepository.RemoveAsync(request.Dto.Id);
        await _writeRepository.SaveChangesAsync();

        await _writeRepository.AddAsync(product);
        await _writeRepository.SaveChangesAsync();

        return new();
    }
}

public record UpdateProductCommandRequest(UpdateProductDto Dto) : IRequest<UpdateProductCommandResponse>;

public record UpdateProductCommandResponse;
