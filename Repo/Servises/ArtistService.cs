using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using PublishingHouse.Interfaces.Extensions.Pagination;
using Repo.Enums;
using Repo.Interfaces;
using Repo.Models;
using Repo.Models.Artist;

namespace Repo.Servises;

public class ArtistService : IArtist
{
    private readonly AplicationContext _db;

    public ArtistService(AplicationContext db)
    {
        _db = db;
    }
    public async Task<Artist> Add(string name, string birthday)
    {
        if (await _db.Artists.AllAsync(x => x.Name == name))
            throw new TirException($"Name {name} already exists!", EnumErrorCode.EntityIsAlreadyExists);
        var artist = new Artist
        {
            Name = name,
            Birthday = birthday
        };
        await _db.AddAsync(artist);
        await _db.SaveChangesAsync();
		
        return artist;
    }
        public async Task<GetArtistResponse> GetAllArtistAsync(GetArtistRequest request)
    {
        return await _db.Artists.GetPageAsync<GetArtistResponse, Artist, ArtistShortModel>(request, artist =>
            new ArtistShortModel
            {
                ID = artist.ID,
                Name = artist.Name,
                Birthday = artist.Birthday
            });
    }

    public async Task<Artist> GetArtistAsync(long artistId)
    {
        return await _db.Artists.FirstOrDefaultAsync(x => x.ID == artistId)
               ?? throw new TirException($"Artist {artistId} is not found!",
                   EnumErrorCode.EntityIsNotFound);
    }

    public async Task Update(long id, string name, string birthday)
    {
        var artist = await _db.Artists.FirstOrDefaultAsync(x => x.ID == id);
        if (artist is null)
            throw new TirException($"Artist Id = {id} is not found!", EnumErrorCode.EntityIsNotFound);

        if (!string.IsNullOrWhiteSpace(name))
            artist.Name = name;
        if (!string.IsNullOrWhiteSpace(birthday))
            artist.Birthday = birthday;
        
        await _db.SaveChangesAsync();
    }

    public async Task DeleteArtistAsync(long id)
    {
        if (await _db.Artists.AnyAsync(x => x.ID == id))
            throw new TirException("Artist is not exists!", EnumErrorCode.EntityIsNotFound);

        _db.Artists.Remove(new Artist {ID = id});
        await _db.SaveChangesAsync();
    }
}