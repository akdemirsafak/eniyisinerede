using Location.Model.RequestModels.Country;
using Location.Model.ResponseModels.Country;
using MediatR;
using SharedLibrary.Dtos;

namespace Location.Service.Application.Commands.Countries.Update;

public record UpdateCountryCommand(int id, UpdateCountryRequest Model) : IRequest<ApiResponse<UpdatedCountryResponse>>;
