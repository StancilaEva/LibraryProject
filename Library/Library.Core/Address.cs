using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core
{
    public class Address
    {
        private string street;
        private string city;
        private string county;
        private int number;

        public Address()
        {

        }

        public Address(string street, string city, string county, int number)
        {
            this.street = street;
            this.city = city;
            this.county = county;
            this.number = number;
        }

     

    }
}
