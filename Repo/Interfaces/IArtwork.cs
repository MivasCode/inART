using Data.Models;
using Repo.Models.Artwork;

namespace Repo.Interfaces;

public interface IArtwork
{
    Task<Artwork> Add(string name, string description, string picture);

    Task<GetArtworkResponse> GetAllArtworkAsync(GetArtworkRequest model);

    Task<Artwork> GetArtworkAsync(long id);

    Task Update(long id, string name, string description, string picture);
    Task DeleteArtworkAsync(long id);
}