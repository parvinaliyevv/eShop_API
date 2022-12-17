namespace eShop.Application.Commands.Orders;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommandRequest, UpdateOrderCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IOrderWriteRepository _writeRepository;


    public UpdateOrderCommandHandler(IMapper mapper, IOrderWriteRepository writeRepository)
    {
        _mapper = mapper;
        _writeRepository = writeRepository;
    }


    public async Task<UpdateOrderCommandResponse> Handle(UpdateOrderCommandRequest request, CancellationToken cancellationToken)
    {
        if (!_writeRepository.Exists(request.Dto.Id)) return null;

        var order = _mapper.Map<Order>(request.Dto);

        if (order.CustomerId == Guid.Empty) order.CustomerId = null;

        await _writeRepository.RemoveAsync(request.Dto.Id);
        await _writeRepository.SaveChangesAsync();

        await _writeRepository.AddAsync(order);
        await _writeRepository.SaveChangesAsync();

        return new();
    }
}

public record UpdateOrderCommandRequest(UpdateOrderDto Dto) : IRequest<UpdateOrderCommandResponse>;

public record UpdateOrderCommandResponse;
