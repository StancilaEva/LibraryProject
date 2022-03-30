using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.DTOs
{
    public class LogInDTO
    {
        public LogInDTO(string userName, string id)
        {
            UserName = userName;
            Id = id;
        }

        public string UserName { get; set; }
        public string Id { get; set; }
    }
}
