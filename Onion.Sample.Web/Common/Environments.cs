using System;
using System.Threading.Tasks;
using Onion.Sample.Core;

namespace Onion.Sample.Application.Common
{
	public class Environments : IEnvironments
	{
		public Task<string> GetAsync(string name)
		{
			return Task.FromResult(Environment.GetEnvironmentVariable(name) ?? throw new ArgumentNullException(name));
		}
	}
}
