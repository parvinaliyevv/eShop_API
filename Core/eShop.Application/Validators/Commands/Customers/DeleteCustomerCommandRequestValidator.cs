namespace eShop.Application.Validators.Commands.Customers;

public class DeleteCustomerCommandRequestValidator : AbstractValidator<DeleteCustomerCommandRequest>
{
    public DeleteCustomerCommandRequestValidator()
    {
        RuleFor(request => request.Id).NotEmpty().WithMessage("Customer id cannot be empty!");
    }
}
