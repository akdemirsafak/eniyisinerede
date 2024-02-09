using Location.Model.RequestModels.City;
using Location.Service.Application.Commands.Cities.Create;
using Location.Service.Application.Commands.Cities.Delete;
using Location.Service.Application.Commands.Cities.Update;
using Location.Service.Application.Queries.Cities.Get;
using Location.Service.Application.Queries.Cities.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Controllers;

namespace Location.API.Controllers;

public class CityController : CustomBaseController
{
    private readonly IMediator _mediator;

    public CityController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return CreateActionResult(await _mediator.Send(new GetCitiesQuery()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return CreateActionResult(await _mediator.Send(new GetCityByIdQuery(id)));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCityRequest request)
    {
        return CreateActionResult(await _mediator.Send(new CreateCityCommand(request)));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCityRequest request)
    {
        return CreateActionResult(await _mediator.Send(new UpdateCityCommand(id,request)));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return CreateActionResult(await _mediator.Send(new DeleteCityCommand(id)));
    }
}
