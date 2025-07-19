using SimpleProductApi.DTOs;
using SimpleProductApi.Models;
using System.Xml.Linq;

namespace SimpleProductApi.Services
{
    public class ProductService
    {
        private readonly List<Product> _products = new();
        private int _nextId = 1;

        public List<Product> GetAll() => _products;

        public Product? GetById(int id) =>
            _products.FirstOrDefault(p => p.Id == id);

        public Product Create(ProductDto dto)
        {
            var product = new Product
            {
                Id = _nextId++,
                Name = dto.Name,
                Price = dto.Price
            };

            _products.Add(product);
            return product;
        }

        public bool Update(int id, ProductDto dto)
        {
            var product = GetById(id);
            if (product == null) return false;

            product.Name = dto.Name;
            product.Price = dto.Price;
            return true;
        }

        public bool Delete(int id)
        {
            var product = GetById(id);
            if (product == null) return false;

            _products.Remove(product);
            return true;
        }
    }
}
