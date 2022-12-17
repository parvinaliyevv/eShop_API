namespace eShop.Application.Commands.Categories;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly ICategoryWriteRepository _writeRepository;


    public CreateCategoryCommandHandler(IMapper mapper, ICategoryWriteRepository writeRepository)
    {
        _mapper = mapper;
        _writeRepository = writeRepository;
    }


    public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Category>(request.Dto);

        await _writeRepository.AddAsync(category);
        await _writeRepository.SaveChangesAsync();

        return new();
    }
}

public record CreateCategoryCommandRequest(CreateCategoryDto Dto) : IRequest<CreateCategoryCommandResponse>;

public record CreateCategoryCommandResponse;
