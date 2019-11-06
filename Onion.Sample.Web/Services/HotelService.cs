using Onion.Sample.Application.Common;
using Onion.Sample.Core;
using Onion.Sample.Domain.Common;
using Onion.Sample.Domain.Repositories;
using Onion.Sample.Domain.Repositories.Models;
using Onion.Sample.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Onion.Sample.Application.Services
{
	public class HotelService : IHotelService
	{
		private readonly IHotelManager _hotelManager;
		private readonly IRoomTypeRepository _roomTypeRepository;
		private readonly IFeatureToggle _featureToggle;
		private readonly ITaskFlow _taskFlow;

		public HotelService(IHotelManager hotelManager, IRoomTypeRepository roomTypeRepository,
			IFeatureToggle featureToggle, ITaskFlow taskFlow)
		{
			_hotelManager = hotelManager;
			_roomTypeRepository = roomTypeRepository;
			_featureToggle = featureToggle;
			_taskFlow = taskFlow;
		}

		public async Task<IEnumerable<HotelModel>> QueryAsync(HotelQuery hotelQuery)
		{
			var hotelApiTypes = new List<HotelApiType>();
			if (_featureToggle.IsFeatureEnabled("SandalsApi"))
			{
				hotelApiTypes.Add(HotelApiType.Sandals);
			}
			if (_featureToggle.IsFeatureEnabled("StellaApi"))
			{
				hotelApiTypes.Add(HotelApiType.Stella);
			}
			var hotelTasks = new List<Task<IEnumerable<HotelModel>>>();
			foreach (var hotelApiType in hotelApiTypes)
			{
				hotelTasks.Add(_hotelManager.QueryAsync(hotelApiType, hotelQuery));
			}
			await _taskFlow.InvokeAsync(hotelTasks, TaskFlowStrategy.Parallel);
			var hotelModels = new List<HotelModel>();
			foreach(var hotelTask in hotelTasks)
			{
				hotelModels.AddRange(await hotelTask);
			}
			return hotelModels;
		}
	}
}
