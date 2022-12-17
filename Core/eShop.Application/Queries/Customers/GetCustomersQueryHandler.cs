namespace eShop.Application.Queries.Customers;

public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQueryRequest, GetCustomersQueryResponse>
{
    private readonly IMapper _mapper;
    private readonly ICustomerReadRepository _readRepository;


    public GetCustomersQueryHandler(IMapper mapper, ICustomerReadRepository readRepository)
    {
        _mapper = mapper;
        _readRepository = readRepository;
    }


    public async Task<GetCustomersQueryResponse> Handle(GetCustomersQueryRequest request, CancellationToken cancellationToken)
    {
        var dtos = new List<CustomerDto>();

        var dbCustomers = (await _readRepository.GetAllAsync(tracking: false)).OrderBy(customer => customer.CreatedDateTime);
        var totalCustomerCount = dbCustomers.Count();

        var customers = await dbCustomers.Skip(request.Page * request.Size).Take(request.Size).ToListAsync();
        customers.ForEach(customer => dtos.Add(_mapper.Map<CustomerDto>(customer)));

        return new(totalCustomerCount, dtos);
    }
}

public record GetCustomersQueryRequest(int Page = 0, ushort Size = 5) : IRequest<GetCustomersQueryResponse>;

public record GetCustomersQueryResponse(int TotalCount, object Customers);
