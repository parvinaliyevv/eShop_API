namespace eShop.Application.Commands.Orders;

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommandRequest, DeleteOrderCommandResponse>
{
    private readonly IOrderWriteRepository _writeRepository;


    public DeleteOrderCommandHandler(IOrderWriteRepository writeRepository)
    {
        _writeRepository = writeRepository;
    }


    public async Task<DeleteOrderCommandResponse> Handle(DeleteOrderCommandRequest request, CancellationToken cancellationToken)
    {
        if (!_writeRepository.Exists(request.Id)) return null;

        await _writeRepository.RemoveAsync(request.Id);
        await _writeRepository.SaveChangesAsync();

        return new();
    }
}

public record DeleteOrderCommandRequest(string Id) : IRequest<DeleteOrderCommandResponse>;

public record DeleteOrderCommandResponse;
