using Onion.Sample.Core.Models;

namespace Onion.Sample.Core
{
	public interface IEmailService
	{
		void SendAsync(Email email);
	}
}
