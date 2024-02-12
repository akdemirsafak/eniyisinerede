using Location.Model.RequestModels.Country;
using Location.Model.ResponseModels.Country;
using MediatR;
using SharedLibrary.Dtos;

namespace Location.Service.Application.Commands.Countries.Create;

public record CreateCountryCommand(CreateCountryRequest Model) : IRequest<ApiResponse<CreatedCountryResponse>>;

