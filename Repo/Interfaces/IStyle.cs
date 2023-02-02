using Data.Models;
using Repo.Models.Style;

namespace Repo.Interfaces;

public interface IStyle
{
    Task<Style> Add(string name, string description, string picture);

    Task<GetStyleResponse> GetAllStyleAsync(GetStyleRequest model);

    Task<Style> GetStyleAsync(long id);

    Task Update(long id, string name, string description, string picture);
    Task DeleteStyleAsync(long id);
}