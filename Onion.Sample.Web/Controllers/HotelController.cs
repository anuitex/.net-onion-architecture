using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Onion.Sample.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using Onion.Sample.Application.Services;
using Onion.Sample.Domain.Repositories.Models;
using Onion.Sample.Application.ViewModels.Hotel;

namespace Onion.Sample.Application.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
		private readonly IHotelService _hotelService;
		private readonly IRoomTypeRepository _roomTypeRepository;

		public HotelController(IHotelService hotelService, IRoomTypeRepository roomTypeRepository)
		{
			_hotelService = hotelService ?? throw new ArgumentNullException(nameof(hotelService));
			_roomTypeRepository = roomTypeRepository ?? throw new ArgumentNullException(nameof(roomTypeRepository));
		}
		
		[HttpGet("room-types")]
		public async Task<ActionResult<IEnumerable<HotelRoomTypeView>>> GetRoomTypesAsync()
		{
			var roomTypes = await _roomTypeRepository.QueryAsync(new BaseQuery());
			var roomTypesViews = roomTypes.Select(roomType => new HotelRoomTypeView(roomType));
			return Ok(roomTypesViews);
		}
		
		[HttpGet]
		public async Task<ActionResult<IEnumerable<HotelRoomTypeView>>> QueryNewsAsync(HotelQueryView query)
		{
			HotelQuery hotelQuery = query;
			var hotels = await _hotelService.QueryAsync(hotelQuery);
			var hotelViews = hotels.Select(hotel => new HotelView(hotel));
			return Ok(hotelViews);
		}
	}
}
