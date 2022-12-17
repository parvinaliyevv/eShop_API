namespace eShop.Application.Validators.Commands.Products;

public class DeleteProductCommandRequestValidator: AbstractValidator<DeleteProductCommandRequest>
{
	public DeleteProductCommandRequestValidator()
	{
        RuleFor(request => request.Id).NotEmpty().WithMessage("Product id cannot be empty!");
    }
}
