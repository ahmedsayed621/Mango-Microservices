using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductService.API.DbContexts;
using ProductService.API.Dto;
using ProductService.API.Models;

namespace ProductService.API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;

        public ProductRepository(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            Product product= _mapper.Map<Product>(productDto);
            if(product.Id>0)
            {
                _context.Update(product);
            }
            else
            {
                _context.Add(product);
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<Product,ProductDto>(product);
        }

        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                Product product = await _context.Products.FirstOrDefaultAsync(x=>x.Id == id);
                if (product == null)
                {
                    return false;
                }

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            Product product = await _context.Products.Where(x=>x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<Product> productList = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(productList);
        }
    }
}
