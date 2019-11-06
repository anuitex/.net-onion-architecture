using Onion.Sample.Domain.Entities;
using Onion.Sample.Domain.Repositories.Models;
using System;

namespace Onion.Sample.Domain.Repositories
{
	public interface IHotelPriceRepository : IRepository<HotelPrice, HotelPriceQuery>, IDisposable
	{
	}
}
