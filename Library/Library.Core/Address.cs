using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core
{
    public class Address
    {
        private string Street { get; set; }
        private string City { get; set; }
        private string County { get; set; }
        private int Number { get; set; }
        public Address(string street, string city, string county, int number)
        {
            if(city != null)
            {
                City = city;
            }
            else
            {
                throw new ArgumentNullException("City cannot be null");
            }
            if(street != null)
            {
                Street = street;
            }
            else
            {
                throw new ArgumentNullException("Street canot be null");
            }
            if (county != null)
            {
                County = county;
            }
            else
            {
                throw new ArgumentNullException("County canot be null");
            }
            if (number != null)
            {
                Number = number;
            }
            else
            {
                throw new ArgumentNullException("Number canot be null");
            }
        }

    }
}
