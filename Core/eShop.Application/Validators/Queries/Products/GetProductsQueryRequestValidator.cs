namespace eShop.Application.Validators.Queries.Products;

public class GetProductsQueryRequestValidator : AbstractValidator<GetProductsQueryRequest>
{
	public GetProductsQueryRequestValidator()
	{
		RuleFor(request => request.Page).InclusiveBetween(0, int.MaxValue).WithMessage($"the number of page cannot be less than zero and more than {int.MaxValue}");
		RuleFor(request => request.Size).InclusiveBetween((ushort)1, ushort.MaxValue).WithMessage($"The count of product cannot be less than or equal to zero and greater than {ushort.MaxValue}");
	}
}
