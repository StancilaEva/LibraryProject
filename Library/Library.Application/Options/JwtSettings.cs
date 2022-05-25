using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Options
{
    public class JwtSettings
    {
        public string StringKey { get; set; }
        public string Issuer{get;set; }
        public string[] Audiences { get; set; }
    }
}
