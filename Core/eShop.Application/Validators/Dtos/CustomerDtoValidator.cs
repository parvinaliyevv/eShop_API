namespace eShop.Application.Validators.Dtos;

public class CreateCustomerDtoValidator : AbstractValidator<CreateCustomerDto>
{
    public CreateCustomerDtoValidator()
    {
        RuleFor(dto => dto.Name).NotEmpty().WithMessage("Customer name cannot be empty!");
        RuleFor(dto => dto.Name).MaximumLength(30).WithMessage("Customer name length cannot be longer than 30 characters!");

        RuleFor(dto => dto.Surname).NotEmpty().WithMessage("Customer surname cannot be empty!");
        RuleFor(dto => dto.Surname).MaximumLength(30).WithMessage("Customer surname length cannot be longer than 30 characters!");
    }
}

public class UpdateCustomerDtoValidator : AbstractValidator<UpdateCustomerDto>
{
    public UpdateCustomerDtoValidator()
    {
        RuleFor(dto => dto.Name).NotEmpty().WithMessage("Customer name cannot be empty!");
        RuleFor(dto => dto.Name).MaximumLength(30).WithMessage("Customer name length cannot be longer than 30 characters!");

        RuleFor(dto => dto.Surname).NotEmpty().WithMessage("Customer surname cannot be empty!");
        RuleFor(dto => dto.Surname).MaximumLength(30).WithMessage("Customer surname length cannot be longer than 30 characters!");
    }
}
