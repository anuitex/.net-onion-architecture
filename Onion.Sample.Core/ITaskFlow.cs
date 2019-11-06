using System.Collections.Generic;
using System.Threading.Tasks;

namespace Onion.Sample.Core
{
	public interface ITaskFlow
	{
		Task InvokeAsync<T>(IEnumerable<Task<T>> tasks, TaskFlowStrategy strategy);
	}

	public enum TaskFlowStrategy
	{
		Parallel = 0,
		Synchronously = 1
	}
}
