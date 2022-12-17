namespace eShop.Application.Commands.Orders;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IOrderWriteRepository _writeRepository;


    public CreateOrderCommandHandler(IMapper mapper, IOrderWriteRepository writeRepository)
    {
        _mapper = mapper;
        _writeRepository = writeRepository;
    }


    public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
    {
        var order = _mapper.Map<Order>(request.Dto);

        if (order.CustomerId == Guid.Empty) order.CustomerId = null;

        await _writeRepository.AddAsync(order);
        await _writeRepository.SaveChangesAsync();

        return new();
    }
}

public record CreateOrderCommandRequest(CreateOrderDto Dto) : IRequest<CreateOrderCommandResponse>;

public record CreateOrderCommandResponse;
