using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Onion.Sample.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using Onion.Sample.Application.Services;
using Onion.Sample.Domain.Repositories.Models;
using Onion.Sample.Application.ViewModels.Hotel;
using Onion.Sample.Application.ViewModels;
using Onion.Sample.Application.ViewModels.Flight;

namespace Onion.Sample.Application.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
		private readonly IFlightService _flightService;
		private readonly IFlightTypeRepository _flightTypeRepository;

		public FlightController(IFlightService flightService, IFlightTypeRepository flightTypeRepository)
		{
			_flightService = flightService ?? throw new ArgumentNullException(nameof(flightService));
			_flightTypeRepository = flightTypeRepository ?? throw new ArgumentNullException(nameof(flightTypeRepository));
		}
		
		[HttpGet("flight-types")]
		public async Task<ActionResult<IEnumerable<HotelRoomTypeView>>> GetFlightTypesAsync()
		{
			var flightTypes = await _flightTypeRepository.QueryAsync(new BaseQuery());
			var flightTypesViews = flightTypes.Select(flightType => new FlightTypeView(flightType));
			return Ok(flightTypesViews);
		}
		
		[HttpGet]
		public async Task<ActionResult<IEnumerable<HotelRoomTypeView>>> QueryNewsAsync(FlightQueryView query)
		{
			FlightQuery flightQuery = query;
			var flights = await _flightService.QueryAsync(flightQuery);
			var flightViews = flights.Select(hotel => new FlightView(hotel));
			return Ok(flightViews);
		}
	}
}
