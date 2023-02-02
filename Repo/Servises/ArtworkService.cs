using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using PublishingHouse.Interfaces.Extensions.Pagination;
using Repo.Enums;
using Repo.Interfaces;
using Repo.Models;
using Repo.Models.Artwork;

namespace Repo.Servises;

public class ArtworkService : IArtwork
{
    private readonly AplicationContext _db;

    public ArtworkService(AplicationContext db)
    {
        _db = db;
    }
    public async Task<Artwork> Add(string name, string description, string picture)
    {
        if (await _db.Artworks.AllAsync(x => x.Name == name))
            throw new TirException($"Name {name} already exists!", EnumErrorCode.EntityIsAlreadyExists);
        var artwork = new Artwork
        {
            Name = name,
            Description = description,
            Picture = picture
        };
        await _db.AddAsync(artwork);
        await _db.SaveChangesAsync();
		
        return artwork;
    }

    public async Task<GetArtworkResponse> GetAllArtworkAsync(GetArtworkRequest request)
    {
        return await _db.Artworks.GetPageAsync<GetArtworkResponse, Artwork, ArtworkShortModel>(request, artwork =>
            new ArtworkShortModel
            {
                ID = artwork.ID,
                Name = artwork.Name,
                Description = artwork.Description,
                Picture = artwork.Picture
            });
    }

    public async Task<Artwork> GetArtworkAsync(long artworkId)
    {
        return await _db.Artworks.FirstOrDefaultAsync(x => x.ID == artworkId)
               ?? throw new TirException($"Artwork {artworkId} is not found!",
                   EnumErrorCode.EntityIsNotFound);
    }

    public async Task Update(long id, string name, string description, string picture)
    {
        var artwork = await _db.Artworks.FirstOrDefaultAsync(x => x.ID == id);
        if (artwork is null)
            throw new TirException($"Artwork Id = {id} is not found!", EnumErrorCode.EntityIsNotFound);

        if (!string.IsNullOrWhiteSpace(name))
            artwork.Name = name;
        if (!string.IsNullOrWhiteSpace(description))
            artwork.Description = description;
        if (!string.IsNullOrWhiteSpace(picture))
            artwork.Picture = picture;
        
        await _db.SaveChangesAsync();
    }

    public async Task DeleteArtworkAsync(long id)
    {
        if (await _db.Artworks.AnyAsync(x => x.ID == id))
            throw new TirException("Artwork is not exists!", EnumErrorCode.EntityIsNotFound);

        _db.Artworks.Remove(new Artwork {ID = id});
        await _db.SaveChangesAsync();
    }
}