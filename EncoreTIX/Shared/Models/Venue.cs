using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncoreTIX.Shared.Models
{
    public class Venue
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Type { get; set; }
        public string? Url {  get; set; }
        public string? Locale { get; set; }
        public List<Image> Images { get; set; }
        public string? PostalCode { get; set; }
        public string? TimeZone { get; set; }
        public City? City { get; set; }
        public State? State { get; set; }
        public Country? Country { get; set; }
        public Address? Address { get; set; }
        public Location? Location { get; set; }
        public string? ParkingDetail { get; set; }

    }

    public class City
    {
        public string? Name { get; set; }
    }

    public class State
    {
        public string? Name { get; set; }
        public string? StateCode { get; set; }
    }

    public class Country
    {
        public string? Name { get; set; }
        public string? CountryCode { get; set; }
    }

    public class Address
    {
        public string? Line1 { get; set; }
        public string? Line2 { get; set; }
    }

    public class Location
    {
        public string? Longitude { get; set; }
        public string? Latitude { get; set; }
    }

    public class GeneralInfo
    {
        public string? GeneralRule { get; set; }
        public string? ChildRule { get; set; }
    }
}
