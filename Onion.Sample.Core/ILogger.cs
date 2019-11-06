using System.Threading.Tasks;

namespace Onion.Sample.Core
{
	public interface ILogger
	{
		Task InfoAsync(string message, object source = null);
		Task WarningAsync(string message, object source);
		Task ErrorAsync(string message, object source);
	}
}
