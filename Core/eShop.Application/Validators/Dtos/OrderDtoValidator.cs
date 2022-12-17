namespace eShop.Application.Validators.Dtos;

public class CreateOrderDtoValidator : AbstractValidator<CreateOrderDto>
{
	public CreateOrderDtoValidator()
	{
        RuleFor(dto => dto.Address).NotEmpty().WithMessage("Order address cannot be empty!");
    }
}

public class UpdateOrderDtoValidator : AbstractValidator<UpdateOrderDto>
{
    public UpdateOrderDtoValidator()
    {
        RuleFor(dto => dto.Address).NotEmpty().WithMessage("Order address cannot be empty!");
    }
}
