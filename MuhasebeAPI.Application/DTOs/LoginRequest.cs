using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    namespace MuhasebeAPI.Application.DTOs
    {
        public class LoginRequest
        {
            public string AreaCode { get; set; } = null!;
            public string PhoneNumber { get; set; } = null!;
            public string Password { get; set; } = null!;
        }
    }

