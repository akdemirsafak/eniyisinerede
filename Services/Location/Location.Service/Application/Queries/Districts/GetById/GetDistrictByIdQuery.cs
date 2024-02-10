using Location.Model.ResponseModels.District;
using MediatR;
using SharedLibrary.Dtos;

namespace Location.Service.Application.Queries.Districts.GetById;

public record GetDistrictByIdQuery(int id) : IRequest<ApiResponse<DistrictResponse>>;