using System.Threading.Tasks;
using WebApplication2.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using WebApplication2.Models.DTO;
using WebApplication2.Models.Interfaces;

namespace WebApplication2.Models.Services
{
	public class CastService: ICast
	{
		private TestDbContext _testDbContext;

		public CastService(TestDbContext testDbContext)
		{
			_testDbContext = testDbContext;
		}

		public async Task<Cast> CreateCastMember(Cast cast)
		{
			_testDbContext.Entry(cast).State = EntityState.Added;
			await _testDbContext.SaveChangesAsync();
			return cast;

		}

		public async Task<List<Cast>> GetAllCastMembers()
		{
			return await _testDbContext.Casts
				.Include(c => c.Show).ThenInclude(s => s.Venue)
				//.ThenInclude(s => ((Show)s).Title)
				.Include(c => c.Person)
				//.ThenInclude(p => p.Name)
				.ToListAsync();
		}
		public async Task<List<Cast>> GetShowCastMembers(int showId)
		{

			return await _testDbContext.Casts
				.Where(c => c.ShowId == showId)
				.Include(c => c.Show)
				//.ThenInclude(s => s.Title)
				.Include(c => c.Person)
				//.ThenInclude(p => p.Name)
				.ToListAsync();
		}

		public async Task<Cast> GetCastMember(int id)
		{

			return await _testDbContext.Casts
				.Include(c => c.Show)
				//.ThenInclude(s => s.Title)
				.Include(c => c.Person)
				//.ThenInclude(p => p.Name)
				.FirstOrDefaultAsync(c => c.Id == id);
		}
		public async Task<CastDTO> GetCastMemberDetails(int id)
		{
            var c = await _testDbContext.Casts
                .Include(c => c.Show)
                //.ThenInclude(s => s.Title)
                .Include(c => c.Person)
                //.ThenInclude(p => p.Name)
                .FirstOrDefaultAsync(c => c.Id == id);
            CastDTO cast = new CastDTO() { JobTitle = c.JobTitle, Person = c.Person, Show = c.Show };
            return cast;
        }
		public async Task DeleteCastMember(int id)
		{
			Cast cast = await GetCastMember(id);
			_testDbContext.Entry(cast).State = EntityState.Deleted;
			await _testDbContext.SaveChangesAsync();
		}

		public async Task AddCastMember(int castId, Cast cm)
		{
			var cast = new Cast
			{
				ShowId = cm.ShowId,
				JobTitle = cm.JobTitle,
				PersonId = cm.PersonId,
				PersonName = cm.PersonName,
				ShowName = cm.ShowName,

			};

			_testDbContext.Casts.Add(cast);
			
			
			await _testDbContext.SaveChangesAsync();
		}

		public async Task RemovePersonFromCast(int castId)
		{
			var cast = _testDbContext.Casts.Where(c => c.Id == castId).FirstOrDefault();
			_testDbContext.Casts.Remove(cast);

			await _testDbContext.SaveChangesAsync();

		}

		public async Task<Cast> UpdateCastMember(int cId, Cast cm)
		{
			return cm;
		}
	}
}
