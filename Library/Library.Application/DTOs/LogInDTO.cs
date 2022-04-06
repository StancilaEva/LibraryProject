using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.DTOs
{
    public class LogInDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public LogInDTO(string userName, int id)
        {
            UserName = userName;
            Id = id;
        }
    }
}
