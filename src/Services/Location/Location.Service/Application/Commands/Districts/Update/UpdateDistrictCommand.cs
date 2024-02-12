using Location.Model.RequestModels.District;
using Location.Model.ResponseModels.District;
using MediatR;
using SharedLibrary.Dtos;

namespace Location.Service.Application.Commands.Districts.Update;

public record UpdateDistrictCommand(int id, UpdateDistrictRequest Model) : IRequest<ApiResponse<UpdatedDistrictResponse>>;