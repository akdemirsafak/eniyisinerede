using Location.Model.RequestModels.District;
using Location.Service.Application.Commands.Districts.Create;
using Location.Service.Application.Commands.Districts.Delete;
using Location.Service.Application.Commands.Districts.Update;
using Location.Service.Application.Queries.Districts.Get;
using Location.Service.Application.Queries.Districts.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Controllers;

namespace Location.API.Controllers;


public class DistrictController : CustomBaseController
{
    private readonly IMediator _mediatr;

    public DistrictController(IMediator mediatr)
    {
        _mediatr = mediatr;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return CreateActionResult(await _mediatr.Send(new GetDistrictsQuery()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return CreateActionResult(await _mediatr.Send(new GetDistrictByIdQuery(id)));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDistrictRequest request)
    {
        return CreateActionResult(await _mediatr.Send(new CreateDistrictCommand(request)));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateDistrictRequest request)
    {
        return CreateActionResult(await _mediatr.Send(new UpdateDistrictCommand(id,request)));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return CreateActionResult(await _mediatr.Send(new DeleteDistrictCommand(id)));
    }
}
