using API.ApplicationCore.DTOs;
using API.ApplicationCore.Entities;
using API.ApplicationCore.Exceptions;
using API.Infrastructure.Persistence.Contexts;
using AutoMapper;
using API.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.ApplicationCore;

namespace API.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly APIContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(APIContext context, IMapper mapper)
        {
            this._mapper = mapper;
            this._context = context;
        }


        public ProductResponse CreateProduct(CreateProductRequest request)
        {
            var product = this._mapper.Map<Product>(request);
            product.Name = request.Name;
            product.Price = request.Price;
            product.CreatedAt = product.UpdatedAt = DateUtil.GetCurrentDate();

            this._context.Products.Add(product);
            this._context.SaveChanges();

            return _mapper.Map<ProductResponse>(product);
        }

        public void DeleteProductById(Guid pid)
        {
            var product = _context.Products.Find(pid);
            if (product != null)
            {
                this._context.Products.Remove(product);
                this._context.SaveChanges();
            }
            else
            {
                throw new NotFoundException();
            }
        }

        public ProductResponse GetProductById(Guid pid)
        {
            var product = this._context.Products.Find(pid);
            if (product != null)
            {
                return this._mapper.Map<ProductResponse>(product);
            }
            throw new NotFoundException();
        }

        public List<ProductResponse> GetProducts()
        {
            return this._context.Products.Select(o => this._mapper.Map<ProductResponse>(o)).ToList();
        }

        public ProductResponse UpdateProduct(Guid pid, UpdateProductRequest request)
        {
            var product = this._context.Products.Find(pid);
            if (product != null)
            {
                product.Name = request.Name;
                product.Price = request.Price;
                product.UpdatedAt = DateUtil.GetCurrentDate();

                this._context.Products.Update(product);
                this._context.SaveChanges();

                return _mapper.Map<ProductResponse>(product);
            }

            throw new NotFoundException();
        }
    }
}
