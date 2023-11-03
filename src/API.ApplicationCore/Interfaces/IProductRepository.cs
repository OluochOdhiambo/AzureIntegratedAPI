using API.ApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ApplicationCore.Interfaces
{
    public interface IProductRepository
    {
        List<ProductResponse> GetProducts();

        ProductResponse GetProductById(Guid pid);

        void DeleteProductById(Guid pid);

        ProductResponse CreateProduct(CreateProductRequest request);

        ProductResponse UpdateProduct(Guid pid, UpdateProductRequest request);
    }
}
