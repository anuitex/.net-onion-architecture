namespace Onion.Sample.Domain.Repositories.Models
{
	public class UserLoginQuery : BaseQuery
	{
		public string Email { get; private set; }
		public UserLoginQuery(string email)
		{
			Email = email;
		}
	}
}
