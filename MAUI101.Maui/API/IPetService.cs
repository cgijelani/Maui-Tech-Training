using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI101.Maui.API
{
	public interface IPetService
	{
		[Get("/breeds/{id}")]
		Task<GetPetResponse> GetPets(string id);

		[Get("/breeds?limit=6&page=0}")]
		Task<List<GetPetResponse>> GetPetList();
	}
}
