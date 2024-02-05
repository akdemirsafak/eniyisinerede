using eniyisinerede.API.Models;
using eniyisinerede.API.RequestModels.Palace;
using eniyisinerede.API.ResponseModels.Palace;
using Riok.Mapperly.Abstractions;

namespace eniyisinerede.API.Mappers.Palaces;

[Mapper]
public partial class PalaceMapper
{
    public partial PalaceResponse PalaceToPalaceResponse(Palace palace);
    public partial List<PalaceResponse> PalacesToPalaceListResponse(List<Palace> palaces);

    public partial Palace CreatePalaceRequestToPalace(CreatePalaceRequest createPalaceRequest);
    public partial CreatedPalaceResponse PalaceToCreatedPalaceResponse(Palace palace);

    public partial UpdatedPalaceResponse PalaceToUpdatedPalaceResponse(Palace palace);
    public partial Palace UpdatePalaceRequestToPalace(UpdatePalaceRequest updatePalaceRequest);
}
