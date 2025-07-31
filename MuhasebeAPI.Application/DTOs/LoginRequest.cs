using MuhasebeAPI.Domain.Entities;

namespace MuhasebeAPI.Application.DTOs
    {
        public class LoginRequest
        {
            /// <summary>
            /// Phone number should start with 'B' or 'C' (e.g., B5xxxxxxxxx or C5xxxxxxxxx)
            /// </summary>
            public string PhoneNumber { get; set; } = null!;
            public string Password { get; set; } = null!;
            public UserType UserType { get; set; }
        }
    }

