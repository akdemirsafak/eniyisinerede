using Location.Model.ResponseModels.District;
using MediatR;
using SharedLibrary.Dtos;

namespace Location.Service.Application.Queries.Districts.Get;

public record GetDistrictsQuery() : IRequest<ApiResponse<List<DistrictResponse>>>;