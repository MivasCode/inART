using Data.Models;
using Repo.Models.ArtType;

namespace Repo.Interfaces;

public interface IArtType
{
    Task<ArtType> Add(long ID, string name);

    Task<GetArtTypeResponse> GetAllArtTypeAsync(GetArtTypeRequest model);

    Task<ArtType> GetArtTypeAsync(long id);

    Task Update(long id, string name);
    Task DeleteArtTypeAsync(long id);
}