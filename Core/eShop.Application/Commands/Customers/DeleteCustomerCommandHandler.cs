namespace eShop.Application.Commands.Customers;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommandRequest, DeleteCustomerCommandResponse>
{
    private readonly ICustomerWriteRepository _writeRepository;


    public DeleteCustomerCommandHandler(ICustomerWriteRepository writeRepository)
    {
        _writeRepository = writeRepository;
    }


    public async Task<DeleteCustomerCommandResponse> Handle(DeleteCustomerCommandRequest request, CancellationToken cancellationToken)
    {
        if (!_writeRepository.Exists(request.Id)) return null;

        await _writeRepository.RemoveAsync(request.Id);
        await _writeRepository.SaveChangesAsync();

        return new();
    }
}

public record DeleteCustomerCommandRequest(string Id) : IRequest<DeleteCustomerCommandResponse>;

public record DeleteCustomerCommandResponse;
