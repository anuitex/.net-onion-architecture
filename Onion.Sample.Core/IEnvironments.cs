using System.Threading.Tasks;

namespace Onion.Sample.Core
{
	public interface IEnvironments
	{
		/// <exception cref="System.ArgumentNullException">Thrown when environment variable does not exist!</exception>
		Task<string> GetAsync(string name);
	}
}
