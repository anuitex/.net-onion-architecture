﻿using Onion.Sample.Domain.Entities;
using Onion.Sample.Domain.Repositories.Models;
using System;

namespace Onion.Sample.Domain.Repositories
{
	public interface IFlightTypeRepository : IRepository<FlightType, BaseQuery>, IDisposable
	{
	}
}
