namespace eShop.Application.Commands.Products;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IProductWriteRepository _productWriteRepository;


    public UpdateProductCommandHandler(IMapper mapper, IProductWriteRepository productWriteRepository)
    {
        _mapper = mapper;
        _productWriteRepository = productWriteRepository;
    }


    public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        if (!await _productWriteRepository.ExistsAsync(request.Dto.Id)) return null;

        var product = _mapper.Map<Product>(request.Dto);

        if (product.CategoryId == Guid.Empty) product.CategoryId = null;

        await _productWriteRepository.RemoveAsync(request.Dto.Id);
        await _productWriteRepository.SaveChangesAsync();

        await _productWriteRepository.AddAsync(product);
        await _productWriteRepository.SaveChangesAsync();

        return new();
    }
}

public record UpdateProductCommandRequest(UpdateProductDto Dto) : IRequest<UpdateProductCommandResponse>;

public record UpdateProductCommandResponse;
