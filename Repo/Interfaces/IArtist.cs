using Data.Models;
using Repo.Models.Artist;

namespace Repo.Interfaces;

public interface IArtist
{
    Task<Artist> Add(string name, string birthday);

    Task<GetArtistResponse> GetAllArtistAsync(GetArtistRequest model);

    Task<Artist> GetArtistAsync(long id);

    Task Update(long id, string name, string birthday);
    Task DeleteArtistAsync(long id);
}