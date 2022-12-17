namespace eShop.Application.Validators.Dtos;

public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
{
    public CreateProductDtoValidator()
    {
        RuleFor(dto => dto.Name).NotEmpty().WithMessage("Product name cannot be empty!");
        RuleFor(dto => dto.Name).MaximumLength(30).WithMessage("Product name length cannot be longer than 30 characters!");

        RuleFor(dto => dto.Stock).InclusiveBetween(1, int.MaxValue).WithMessage($"The count of product cannot be less than or equal to zero and greater than {int.MaxValue}");
        RuleFor(dto => dto.Price).InclusiveBetween(1, int.MaxValue).WithMessage($"The price of the product cannot be less than or equal to zero and greater than {int.MaxValue}");
    }
}

public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
{
    public UpdateProductDtoValidator()
    {
        RuleFor(dto => dto.Name).NotEmpty().WithMessage("Product name cannot be empty!");
        RuleFor(dto => dto.Name).MaximumLength(30).WithMessage("Product name length cannot be longer than 30 characters!");

        RuleFor(dto => dto.Stock).InclusiveBetween(1, int.MaxValue).WithMessage($"The count of product cannot be less than or equal to zero and greater than {int.MaxValue}");
        RuleFor(dto => dto.Price).InclusiveBetween(1, int.MaxValue).WithMessage($"The price of the product cannot be less than or equal to zero and greater than {int.MaxValue}");
    }
}
