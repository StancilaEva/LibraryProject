using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Library.Core
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public int Number { get; set; }

        [JsonIgnore]
        public Client Client { get; set; }

        public Address(int id, string street, string city, string county, int number, Client client)
        {
            Id = id;
            Street = street;
            City = city;
            County = county;
            Number = number;
            Client = client;
        }

        public Address(string street, string city, string county, int number)
        {
            if(!String.IsNullOrEmpty(city))
            {
                City = city;
            }
            else
            {
                throw new ArgumentNullException("City cannot be null");
            }
            if(!String.IsNullOrEmpty(street))
            {
                Street = street;
            }
            else
            {
                throw new ArgumentNullException("Street cannot be null");
            }
            if (!String.IsNullOrEmpty(county))
            {
                County = county;
            }
            else
            {
                throw new ArgumentNullException("County cannot be null");
            }
            if (number >0)
            {
                Number = number;
            }
            else
            {
                throw new ArgumentNullException("Number cannot be less than 0");
            }
        }

    }
}
