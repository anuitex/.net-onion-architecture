using Onion.Sample.Application.Models;
using System.Threading.Tasks;

namespace Onion.Sample.Application.Services.Interfaces
{
	public interface IUserSession
	{
		Task<UserSession> GetSessionAsync();
	}
}
