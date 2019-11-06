using System;

namespace Onion.Sample.Domain.Entities
{
	public class Flight : Entity
	{
		public string FlightNumber { get; private set; }
		public Airline Airline { get; private set; }
		public long AirlineId { get; private set; }
		public FlightType FlightType { get; private set; }
		public long FlightTypeId { get; private set; }
		public DateTime DateFrom { get; private set; }
		public DateTime DateTo { get; private set; }
		public decimal Price { get; private set; }
		public Location LocationFrom { get; private set; }
		public long LocationFromId { get; private set; }
		public Location LocationTo { get; private set; }
		public long LocationToId { get; private set; }

		public Flight(string flightNumber,long airlineId,long flightTypeId,DateTime dateFrom,DateTime dateTo,decimal price,
			long locationFromId,long locationToId)
		{
			FlightNumber = flightNumber;
			AirlineId = airlineId;
			FlightTypeId = flightTypeId;
			DateFrom = dateFrom;
			DateTo = dateTo;
			Price = price;
			LocationFromId = locationFromId;
			LocationToId = locationToId;
		}

		public Flight(string flightNumber, Airline airline, FlightType flightType,Location locationFrom,Location locationTo,
			DateTime dateFrom, DateTime dateTo, decimal price)
		{
			FlightNumber = flightNumber;
			AirlineId = airline.Id;
			Airline = airline;
			FlightTypeId = flightType.Id;
			FlightType = flightType;
			DateFrom = dateFrom;
			DateTo = dateTo;
			Price = price;
			LocationFrom = locationFrom;
			LocationTo = locationTo;
			LocationToId = locationTo.Id;
			LocationFromId = locationFrom.Id;
		}
	}
}
