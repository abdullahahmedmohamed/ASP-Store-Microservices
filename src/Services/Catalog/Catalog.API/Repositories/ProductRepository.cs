using Catalog.API.Data.Interfaces;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ICatalogContext _context;
    public ProductRepository(ICatalogContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
      return await _context.Products.Find(_ => true).ToListAsync();
    }
    public async Task<Product> GetProduct(string id)
    {
        //FilterDefinition<Product> filter = Builders<Product>.Filter.Eq("Id", id);
        return await _context.Products.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
    {
        return await _context.Products.Find(x => x.Category == categoryName).ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProductByName(string name)
    {
        FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(nameof(Product.Name), name);
        return await _context.Products.Find(filter).ToListAsync();
    }




    public async Task CreateProduct(Product product)
    {
        await _context.Products.InsertOneAsync(product);
    }
   
   
    public async Task<bool> UpdateProduct(Product product)
    {
       var updateResult = await _context.Products.ReplaceOneAsync(x => x.Id == product.Id, product);
       return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
    }

    public async Task<bool> DeleteProduct(string id)
    {
        var deleteResult = await _context.Products.DeleteOneAsync(x => x.Id == id);
        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }

}
