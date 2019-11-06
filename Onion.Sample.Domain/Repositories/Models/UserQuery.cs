namespace Onion.Sample.Domain.Repositories.Models
{
	public class UserQuery : BaseQuery
	{
		public string Email { get; private set; }

		public UserQuery(string email)
		{

		}
	}
}
