using Onion.Sample.Application.Common;
using Onion.Sample.Core;
using Onion.Sample.Domain.Common;
using Onion.Sample.Domain.Repositories.Models;
using Onion.Sample.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Onion.Sample.Application.Services
{
	public class FlightService : IFlightService
	{
		private readonly IFeatureToggle _featureToggle;
		private readonly ITaskFlow _taskFlow;
		private readonly IFlightManager _flightManager;

		public FlightService(IFeatureToggle featureToggle, ITaskFlow taskFlow, IFlightManager flightManager)
		{
			_featureToggle = featureToggle;
			_taskFlow = taskFlow;
			_flightManager = flightManager;
		}

		public async Task<IEnumerable<FlightPackageModel>> QueryAsync(FlightQuery flightQuery)
		{
			var flightApiTypes = new List<FlightApiType>();
			if (_featureToggle.IsFeatureEnabled("JetSetsApi"))
			{
				flightApiTypes.Add(FlightApiType.JetSet);
			}
			if (_featureToggle.IsFeatureEnabled("StellaApi"))
			{
				flightApiTypes.Add(FlightApiType.Stella);
			}
			var flightTasks = new List<Task<IEnumerable<FlightPackageModel>>>();
			foreach (var flightApiType in flightApiTypes)
			{
				flightTasks.Add(_flightManager.QueryAsync(flightApiType, flightQuery));
			}
			await _taskFlow.InvokeAsync(flightTasks, TaskFlowStrategy.Parallel);
			var flightModels = new List<FlightPackageModel>();
			foreach (var flightTask in flightTasks)
			{
				flightModels.AddRange(await flightTask);
			}
			return flightModels;
		}
	}
}
