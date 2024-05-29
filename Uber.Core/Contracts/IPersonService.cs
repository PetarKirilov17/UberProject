using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uber.Core.Models;
using Uber.Infrastructure.Data.Models;

namespace Uber.Core.Contracts
{
	public interface IPersonService
	{
		Task CreatePerson(string userId, PersonViewModel person);

		Task<List<Person>> GetAllPeople();

		Task<Person> GetPersonByPersonId(int personId);
		
	}
}
