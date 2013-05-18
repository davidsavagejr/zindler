namespace zindler.web.Models
{
	public class Address
	{
		public string StreetLine1 { get; set; }
		public string StreetLine2 { get; set; }
		public string StreetLine3 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string PostalCode { get; set; }
		public string Latitude { get; set; }
		public string Longitude { get; set; }
		public string GeoAccuracy { get; set; }
	}
}