namespace eShop.Application.Dtos;

public abstract record BaseCustomerDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
}

public record CustomerDto: BaseCustomerDto;

public record CreateCustomerDto: BaseCustomerDto;

public record UpdateCustomerDto(string Id): BaseCustomerDto;
