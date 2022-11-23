using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication2.Models.Interfaces
{
	public interface ICast
	{
		// CREATE
		Task<Cast> CreateCastMember(Cast cast);

		// GET ALL

		Task<List<Cast>> GetAllCastMembers();

		// GET ONE BY ID
		Task<Cast> GetCastMember(int id);

		// GET CASTMEMBERS OF A PARTICULAR SHOW
		Task<List<Cast>> GetShowCastMembers(int showId);

		// UPDATE
		Task<Cast> UpdateCastMember(int id, Cast cast);

		// DELETE
		Task DeleteCastMember(int id);

		Task AddCastMember(int castId, Cast cast);
		//Task AddCastMember(int castId, int personId);
		Task RemovePersonFromCast(int castId);
	}
}
