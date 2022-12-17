namespace eShop.Application.Validators.Queries.Categories;

public class GetCategoriesQueryRequestValidator : AbstractValidator<GetCategoriesQueryRequest>
{
	public GetCategoriesQueryRequestValidator()
	{
        RuleFor(request => request.Page).InclusiveBetween(0, int.MaxValue).WithMessage($"the number of page cannot be less than zero and more than {int.MaxValue}");
        RuleFor(request => request.Size).InclusiveBetween((ushort)1, ushort.MaxValue).WithMessage($"The count of category cannot be less than or equal to zero and greater than {ushort.MaxValue}");
    }
}
