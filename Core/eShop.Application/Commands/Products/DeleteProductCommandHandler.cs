namespace eShop.Application.Commands.Products;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
{
    private readonly IProductWriteRepository _productWriteRepository;


    public DeleteProductCommandHandler(IProductWriteRepository productWriteRepository)
    {
        _productWriteRepository = productWriteRepository;
    }


    public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
    {
        if (!await _productWriteRepository.ExistsAsync(request.Id)) return null;

        await _productWriteRepository.RemoveAsync(request.Id);
        await _productWriteRepository.SaveChangesAsync();

        return new();
    }
}

public record DeleteProductCommandRequest(string Id) : IRequest<DeleteProductCommandResponse>;

public record DeleteProductCommandResponse;
