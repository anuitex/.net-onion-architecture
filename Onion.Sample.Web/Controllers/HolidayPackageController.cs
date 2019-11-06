using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using Onion.Sample.Application.Services;
using Onion.Sample.Application.ViewModels.Hotel;
using Onion.Sample.Application.ViewModels.Flight;
using Onion.Sample.Core;

namespace Onion.Sample.Application.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class HolidayPackageController : ControllerBase
    {
		private readonly IHotelService _hotelService;
		private readonly IFlightService _flightService;
		private readonly ILogger _logger;
		public HolidayPackageController(IHotelService hotelService, IFlightService flightService,
			ILogger logger)
		{
			_hotelService = hotelService ?? throw new ArgumentNullException(nameof(hotelService));
			_flightService = flightService ?? throw new ArgumentNullException(nameof(flightService));
			_logger = logger;
		}
		
		[HttpGet("holiday-packages")]
		public async Task<ActionResult<IEnumerable<HotelRoomTypeView>>> GetHolidayPackages(HotelQueryView hotelQuery, 
			FlightQueryView flightQuery)
		{
			try
			{
				var flights = await _flightService.QueryAsync(flightQuery);
				var flightViews = flights.Select(hotel => new FlightView(hotel));

				var hotels = await _hotelService.QueryAsync(hotelQuery);
				var hotelViews = hotels.Select(hotel => new HotelView(hotel));

				//TODO: Mapping package

				return Ok();//TODO: Return packages
			}catch(Exception exception)
			{
				await _logger.ErrorAsync("HolidayPackageController.GetHolidayPackages", exception);
				return StatusCode(500);
			}
		}
	}
}
