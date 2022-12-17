namespace eShop.Application.Commands.Customers;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommandRequest, UpdateCustomerCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly ICustomerWriteRepository _writeRepository;


    public UpdateCustomerCommandHandler(IMapper mapper, ICustomerWriteRepository writeRepository)
    {
        _mapper = mapper;
        _writeRepository = writeRepository;
    }


    public async Task<UpdateCustomerCommandResponse> Handle(UpdateCustomerCommandRequest request, CancellationToken cancellationToken)
    {
        if (!_writeRepository.Exists(request.Dto.Id)) return null;

        var customer = _mapper.Map<Customer>(request.Dto);

        await _writeRepository.RemoveAsync(request.Dto.Id);
        await _writeRepository.SaveChangesAsync();

        await _writeRepository.AddAsync(customer);
        await _writeRepository.SaveChangesAsync();

        return new();
    }
}

public record UpdateCustomerCommandRequest(UpdateCustomerDto Dto) : IRequest<UpdateCustomerCommandResponse>;

public record UpdateCustomerCommandResponse;
