using System;
using System.ComponentModel.DataAnnotations;


namespace API.ApplicationCore.DTOs
{
    public class CreateProductRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }
    }

    public class UpdateProductRequest : CreateProductRequest 
    { 

    }

    public class ProductResponse 
    { 
        public Guid Pid { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
