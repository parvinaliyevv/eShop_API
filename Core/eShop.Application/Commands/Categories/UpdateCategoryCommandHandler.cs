namespace eShop.Application.Commands.Categories;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly ICategoryWriteRepository _writeRepository;


    public UpdateCategoryCommandHandler(IMapper mapper, ICategoryWriteRepository writeRepository)
    {
        _mapper = mapper;
        _writeRepository = writeRepository;
    }


    public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        if (!_writeRepository.Exists(request.Dto.Id)) return null;

        var category = _mapper.Map<Category>(request.Dto);

        await _writeRepository.RemoveAsync(request.Dto.Id);
        await _writeRepository.SaveChangesAsync();

        await _writeRepository.AddAsync(category);
        await _writeRepository.SaveChangesAsync();

        return new();
    }
}

public record UpdateCategoryCommandRequest(UpdateCategoryDto Dto) : IRequest<UpdateCategoryCommandResponse>;

public record UpdateCategoryCommandResponse;
