namespace eShop.Application.Validators.Queries.Customers;

public class GetCustomersQueryRequestValidator : AbstractValidator<GetCustomersQueryRequest>
{
	public GetCustomersQueryRequestValidator()
	{
        RuleFor(request => request.Page).InclusiveBetween(0, int.MaxValue).WithMessage($"the number of page cannot be less than zero and more than {int.MaxValue}");
        RuleFor(request => request.Size).InclusiveBetween((ushort)1, ushort.MaxValue).WithMessage($"The count of customer cannot be less than or equal to zero and greater than {ushort.MaxValue}");
    }
}
