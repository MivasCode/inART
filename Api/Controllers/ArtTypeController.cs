using System.ComponentModel.DataAnnotations;
using Api.Models.Card;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repo.Interfaces;
using Repo.Models.ArtType;
using Repo.Models.Card;
using Repo.Models.Discont;
using Service.Model;
using PublishingHouse.Interfaces.Extensions.Pagination;

namespace Api.Controllers;

/// <summary>
///     Факультеты
/// </summary>
[Route("/[Controller]")]
[Produces("application/json")]
public class ArtTypeController : Microsoft.AspNetCore.Mvc.Controller
{
	private readonly IArtType _arttype;

	public ArtTypeController(IArtType arttype)
	{
		_arttype = arttype;
	}

	/// <summary>
	///     Добавить дисконт
	/// </summary>
	/// <param name="model"></param>
	/// <returns></returns>
	[HttpPost]
	[Route($"{nameof(Add)}")]
	[ProducesResponseType(200, Type = typeof(BaseResponse<long>))]
	[ProducesResponseType(400, Type = typeof(BaseResponse))]
	///[Authorize]///
	public async Task<BaseResponse<long>> Add([FromQuery] long ID, string model)
	{
		var result = await _arttype.Add(ID, model);
		return new BaseResponse<long>(result?.ID ?? 0);
	}

	/// <summary>
	///     Получить список всех факультетов
	/// </summary>
	/// <returns></returns>
	[HttpGet]
	[Route($"{nameof(GetAll)}")]
	[ProducesResponseType(200, Type = typeof(BaseResponse<GetArtTypeResponse>))]
	[ProducesResponseType(400, Type = typeof(BaseResponse))]
	public async Task<BaseResponse<GetArtTypeResponse>> GetAll([FromQuery] Page request)
	{
		var result = await _arttype.GetAllArtTypeAsync(new GetArtTypeRequest {Page = request});
		return new BaseResponse<GetArtTypeResponse>(result);
	}

	/// <summary>
	///     Получить факультет
	/// </summary>
	/// <returns></returns>
	[HttpGet]
	[Route($"{nameof(Get)}")]
	[ProducesResponseType(200, Type = typeof(BaseResponse<(long Id, string Name,double Value)>))]
	[ProducesResponseType(400, Type = typeof(BaseResponse))]
	public async Task<BaseResponse<(long ID, string Name)>> Get([FromQuery] [Required] long id)
	{
		var result = await _arttype.GetArtTypeAsync(id);
		return new BaseResponse<(long ID, string Name)>((result.ID, result.Name));
	}

	/// <summary>
	///     Переименовать факультет
	/// </summary>
	/// <returns></returns>
	[HttpPatch]
	[Route($"{nameof(Rename)}")]
	[ProducesResponseType(200, Type = typeof(BaseResponse))]
	[ProducesResponseType(400, Type = typeof(BaseResponse))]
	///[Authorize]///
	public async Task<BaseResponse> Rename([FromQuery] long id,  string name)
	{
		await _arttype.Update(id, name);
		return new BaseResponse();
	}

	/// <summary>
	///     Удалить факультет
	/// </summary>
	/// </summary>
	/// <returns></returns>
	[HttpDelete]
	[Route($"{nameof(Delete)}")]
	[ProducesResponseType(200, Type = typeof(BaseResponse))]
	[ProducesResponseType(400, Type = typeof(BaseResponse))]
	//[Authorize]
	public async Task<BaseResponse> Delete([FromQuery] long id)
	{
		await _arttype.DeleteArtTypeAsync(id);
		return new BaseResponse();
	}
}