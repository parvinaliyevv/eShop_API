namespace eShop.Application.Commands.Customers;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommandRequest, CreateCustomerCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly ICustomerWriteRepository _writeRepository;


    public CreateCustomerCommandHandler(IMapper mapper, ICustomerWriteRepository writeRepository)
    {
        _mapper = mapper;
        _writeRepository = writeRepository;
    }


    public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommandRequest request, CancellationToken cancellationToken)
    {
        var customer = _mapper.Map<Customer>(request.Dto);

        await _writeRepository.AddAsync(customer);
        await _writeRepository.SaveChangesAsync();

        return new();
    }
}

public record CreateCustomerCommandRequest(CreateCustomerDto Dto) : IRequest<CreateCustomerCommandResponse>;

public record CreateCustomerCommandResponse;
