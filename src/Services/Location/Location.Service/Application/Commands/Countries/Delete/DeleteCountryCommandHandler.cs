using Location.Core.Repositories;
using MediatR;
using SharedLibrary.Dtos;

namespace Location.Service.Application.Commands.Countries.Delete;

public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, ApiResponse<NoContent>>
{
    private readonly ICountryRepository _countryRepository;

    public DeleteCountryCommandHandler(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<ApiResponse<NoContent>> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
    {
        var result = await _countryRepository.DeleteAsync(request.id);
        if (result == 0)
            throw new Exception("Country not found");

        return ApiResponse<NoContent>.Success(204);
    }
}
