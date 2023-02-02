using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using PublishingHouse.Interfaces.Extensions.Pagination;
using Repo.Enums;
using Repo.Interfaces;
using Repo.Models;
using Repo.Models.Style;

namespace Repo.Servises;

public class StyleService : IStyle
{
    private readonly AplicationContext _db;

    public StyleService(AplicationContext db)
    {
        _db = db;
    }
    public async Task<Style> Add(string name, string description, string picture)
    {
        if (await _db.Styles.AllAsync(x => x.Name == name))
            throw new TirException($"Name {name} already exists!", EnumErrorCode.EntityIsAlreadyExists);
        var style = new Style
        {
            Name = name,
            Description = description,
            Picture = picture
        };
        await _db.AddAsync(style);
        await _db.SaveChangesAsync();
		
        return style;
    }

    public async Task<GetStyleResponse> GetAllStyleAsync(GetStyleRequest request)
    {
        return await _db.Styles.GetPageAsync<GetStyleResponse, Style, StyleShortModel>(request, style =>
            new StyleShortModel
            {
                ID = style.ID,
                Name = style.Name,
                Description = style.Description,
                Picture = style.Picture
            });
    }

    public async Task<Style> GetStyleAsync(long styleId)
    {
        return await _db.Styles.FirstOrDefaultAsync(x => x.ID == styleId)
               ?? throw new TirException($"Style {styleId} is not found!",
                   EnumErrorCode.EntityIsNotFound);
    }

    public async Task Update(long id, string name, string description, string picture)
    {
        var style = await _db.Styles.FirstOrDefaultAsync(x => x.ID == id);
        if (style is null)
            throw new TirException($"Style Id = {id} is not found!", EnumErrorCode.EntityIsNotFound);

        if (!string.IsNullOrWhiteSpace(name))
            style.Name = name;
        if (!string.IsNullOrWhiteSpace(description))
            style.Description = description;
        if (!string.IsNullOrWhiteSpace(picture))
            style.Picture = picture;
        
        await _db.SaveChangesAsync();
    }

    public async Task DeleteStyleAsync(long id)
    {
        if (await _db.Styles.AnyAsync(x => x.ID == id))
            throw new TirException("Style is not exists!", EnumErrorCode.EntityIsNotFound);

        _db.Styles.Remove(new Style {ID = id});
        await _db.SaveChangesAsync();
    }
}