using System.Threading.Tasks;
using Onion.Sample.Core;

namespace Onion.Sample.Infrastructure
{
	public class Logger : ILogger
	{
		public Task ErrorAsync(string message, object source)
		{
			throw new System.NotImplementedException();
		}

		public Task InfoAsync(string message, object source = null)
		{
			throw new System.NotImplementedException();
		}

		public Task WarningAsync(string message, object source)
		{
			throw new System.NotImplementedException();
		}
	}
}
