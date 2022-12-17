namespace eShop.Application.Validators.Dtos;

public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
{
	public CreateCategoryDtoValidator()
	{
        RuleFor(dto => dto.Name).NotEmpty().WithMessage("Category name cannot be empty!");
        RuleFor(dto => dto.Name).MaximumLength(50).WithMessage("Category name length cannot be longer than 50 characters!");
    }
}

public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
{
    public UpdateCategoryDtoValidator()
    {
        RuleFor(dto => dto.Name).NotEmpty().WithMessage("Category name cannot be empty!");
        RuleFor(dto => dto.Name).MaximumLength(50).WithMessage("Category name length cannot be longer than 50 characters!");
    }
}
