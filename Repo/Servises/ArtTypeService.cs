using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using PublishingHouse.Interfaces.Extensions.Pagination;
using Repo.Enums;
using Repo.Interfaces;
using Repo.Models;
using Repo.Models.ArtType;

namespace Repo.Servises;

public class ArtTypeService : IArtType
{
    private readonly AplicationContext _db;

    public ArtTypeService(AplicationContext db)
    {
        _db = db;
    }
    public async Task<ArtType> Add(long id, string name)
 
    {
        
        if (await _db.ArtTypes.AllAsync(x => x.Name == name))
            throw new TirException($"Name {name} already exists!", EnumErrorCode.EntityIsAlreadyExists);
        var arttype = new ArtType
        {
            ID = id,
            Name = name
        };
        await _db.AddAsync(arttype);
        await _db.SaveChangesAsync();
		
        return arttype;

    }

    public async Task<GetArtTypeResponse> GetAllArtTypeAsync(GetArtTypeRequest request)
    {
        return await _db.ArtTypes.GetPageAsync<GetArtTypeResponse, ArtType, ArtTypeShortModel>(request, arttype =>
            new ArtTypeShortModel
            {
                ID = arttype.ID,
                Name = arttype.Name
            });
    }

    public async Task<ArtType> GetArtTypeAsync(long arttypeId)
    {
        return await _db.ArtTypes.FirstOrDefaultAsync(x => x.ID == arttypeId)
               ?? throw new TirException($"ArtType {arttypeId} is not found!",
                   EnumErrorCode.EntityIsNotFound);
    }

    public async Task Update(long id, string name)
    {
        var arttype = await _db.ArtTypes.FirstOrDefaultAsync(x => x.ID == id);
        if (arttype is null)
            throw new TirException($"ArtType Id = {id} is not found!", EnumErrorCode.EntityIsNotFound);

        if (!string.IsNullOrWhiteSpace(name))
            arttype.Name = name;
        
        await _db.SaveChangesAsync();
    }

    public async Task DeleteArtTypeAsync(long id)
    {
        var arttype = await _db.ArtTypes.FirstOrDefaultAsync(x => x.ID == id);
        if (arttype is null)
            throw new TirException($"ArtType Id = {id} is not found!", EnumErrorCode.EntityIsNotFound);

        _db.ArtTypes.Remove(arttype);
        await _db.SaveChangesAsync();
    }
}