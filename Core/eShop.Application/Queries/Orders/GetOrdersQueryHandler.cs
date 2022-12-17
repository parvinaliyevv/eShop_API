namespace eShop.Application.Queries.Orders;

public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQueryRequest, GetOrdersQueryResponse>
{
    private readonly IMapper _mapper;
    private readonly IOrderReadRepository _readRepository;


    public GetOrdersQueryHandler(IMapper mapper, IOrderReadRepository readRepository)
    {
        _mapper = mapper;
        _readRepository = readRepository;
    }


    public async Task<GetOrdersQueryResponse> Handle(GetOrdersQueryRequest request, CancellationToken cancellationToken)
    {
        var dtos = new List<OrderDto>();

        var dbOrders = (await _readRepository.GetAllAsync(tracking: false)).Include("Customer").Include(o => o.ProductOrders).ThenInclude(po => po.Product).ThenInclude(p => p.Category).OrderBy(order => order.CreatedDateTime);
        var totalOrderCount = dbOrders.Count();

        var orders = await dbOrders.Skip(request.Page * request.Size).Take(request.Size).ToListAsync();
        orders.ForEach(order =>
        {
            var orderDto = _mapper.Map<OrderDto>(order);

            foreach (var productOrder in order.ProductOrders) 
                orderDto.Products.Add(_mapper.Map<ProductDto>(productOrder.Product));

            dtos.Add(orderDto);
        });

        return new(totalOrderCount, dtos);
    }
}

public record GetOrdersQueryRequest(int Page = 0, ushort Size = 5) : IRequest<GetOrdersQueryResponse>;

public record GetOrdersQueryResponse(int TotalCount, object Orders);
