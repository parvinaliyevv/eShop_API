namespace eShop.Application.Validators.Commands.Categories;

public class DeleteCategoryCommandRequestValidator : AbstractValidator<DeleteCategoryCommandRequest>
{
    public DeleteCategoryCommandRequestValidator()
    {
        RuleFor(request => request.Id).NotEmpty().WithMessage("Category id cannot be empty!");
    }
}
