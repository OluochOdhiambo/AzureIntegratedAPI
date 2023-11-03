using API.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ApplicationCore.DTOs
{
    public class CreateOrderRequest
    {
        [Required]
        public Guid Oid { get; set; }
    }

    public class UpdateOrderRequest : CreateOrderRequest
    {

    }

    public class OrderResponse
    { 
        public Guid Oid { get; set; }
    }
}
