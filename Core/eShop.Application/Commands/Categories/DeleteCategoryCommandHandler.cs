namespace eShop.Application.Commands.Categories;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, DeleteCategoryCommandResponse>
{
    private readonly ICategoryWriteRepository _writeRepository;


    public DeleteCategoryCommandHandler(ICategoryWriteRepository writeRepository)
    {
        _writeRepository = writeRepository;
    }


    public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        if (!_writeRepository.Exists(request.Id)) return null;

        await _writeRepository.RemoveAsync(request.Id);
        await _writeRepository.SaveChangesAsync();

        return new();
    }
}

public record DeleteCategoryCommandRequest(string Id) : IRequest<DeleteCategoryCommandResponse>;

public record DeleteCategoryCommandResponse;
