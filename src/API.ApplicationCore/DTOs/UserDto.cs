using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ApplicationCore.DTOs
{
    public class CreateUserRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }

    public class UpdateUserRequest : CreateUserRequest
    { 
    
    }

    public class UserResponse
    {
        public Guid Uid { get; set; }
        public string Name { get; set; } = null!;
    }
}
