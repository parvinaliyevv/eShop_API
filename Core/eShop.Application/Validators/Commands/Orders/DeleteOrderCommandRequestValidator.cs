namespace eShop.Application.Validators.Commands.Orders;

public class DeleteOrderCommandRequestValidator : AbstractValidator<DeleteOrderCommandRequest>
{
    public DeleteOrderCommandRequestValidator()
    {
        RuleFor(request => request.Id).NotEmpty().WithMessage("Order id cannot be empty!");
    }
}
