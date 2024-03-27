using Location.Model.RequestModels.Country;
using Location.Service.Application.Commands.Countries.Create;
using Location.Service.Application.Commands.Countries.Delete;
using Location.Service.Application.Commands.Countries.Update;
using Location.Service.Application.Queries.Countries.Get;
using Location.Service.Application.Queries.Countries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Controllers;

namespace Location.API.Controllers;

public class CountryController : CustomBaseController
{
    private readonly IMediator _mediatr;

    public CountryController(IMediator mediatr)
    {
        _mediatr = mediatr;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return CreateActionResult(await _mediatr.Send(new GetCountriesQuery()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return CreateActionResult(await _mediatr.Send(new GetCountryByIdQuery(id)));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCountryRequest request)
    {
        return CreateActionResult(await _mediatr.Send(new CreateCountryCommand(request)));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCountryRequest request)
    {
        return CreateActionResult(await _mediatr.Send(new UpdateCountryCommand(id,request)));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return CreateActionResult(await _mediatr.Send(new DeleteCountryCommand(id)));
    }
}
