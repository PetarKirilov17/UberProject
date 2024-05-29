using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uber.Core.Contracts;
using Uber.Core.Models;
using Uber.Infrastructure.Data.Common;
using Uber.Infrastructure.Data.Models;

namespace Uber.Core.Services
{
	public class PersonService : IPersonService
	{
		private readonly IRepository _repo;

		public PersonService(IRepository repo)
        {
			_repo = repo;
		}

        public async Task CreatePerson(string userId, PersonViewModel person)
		{
			var entity = new Person()
			{
				UserId = userId,
				FirstName = person.FirstName,
				LastName = person.LastName,
				Gender = person.Gender,
				Age = person.Age
			};
			await _repo.AddAsync(entity);
			await _repo.SaveChangesAsync();
		}

        public async Task<List<Person>> GetAllPeople()
        {
			return await _repo.All<Person>().ToListAsync();
        }

        public async Task<Person> GetPersonByPersonId(int personId)
        {
            return await _repo.GetByIdAsync<Person>(personId);
        }
    }
}
