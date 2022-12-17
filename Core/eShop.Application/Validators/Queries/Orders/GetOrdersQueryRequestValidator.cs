namespace eShop.Application.Validators.Queries.Orders;

public class GetOrdersQueryRequestValidator : AbstractValidator<GetOrdersQueryRequest>
{
	public GetOrdersQueryRequestValidator()
	{
        RuleFor(request => request.Page).InclusiveBetween(0, int.MaxValue).WithMessage($"the number of page cannot be less than zero and more than {int.MaxValue}");
        RuleFor(request => request.Size).InclusiveBetween((ushort)1, ushort.MaxValue).WithMessage($"The count of order cannot be less than or equal to zero and greater than {ushort.MaxValue}");
    }
}
