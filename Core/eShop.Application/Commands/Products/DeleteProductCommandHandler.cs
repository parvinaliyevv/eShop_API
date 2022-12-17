namespace eShop.Application.Commands.Products;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
{
    private readonly IProductWriteRepository _writeRepository;


    public DeleteProductCommandHandler(IProductWriteRepository writeRepository)
    {
        _writeRepository = writeRepository;
    }


    public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
    {
        if (!_writeRepository.Exists(request.Id)) return null;

        await _writeRepository.RemoveAsync(request.Id);
        await _writeRepository.SaveChangesAsync();

        return new();
    }
}

public record DeleteProductCommandRequest(string Id) : IRequest<DeleteProductCommandResponse>;

public record DeleteProductCommandResponse;
