using Location.Model.RequestModels.District;
using Location.Model.ResponseModels.District;
using MediatR;
using SharedLibrary.Dtos;

namespace Location.Service.Application.Commands.Districts.Create
{
    public record CreateDistrictCommand(CreateDistrictRequest Model) : IRequest<ApiResponse<CreatedDistrictResponse>>;
}
