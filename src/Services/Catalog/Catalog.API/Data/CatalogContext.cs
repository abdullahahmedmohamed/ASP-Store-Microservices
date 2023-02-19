using Catalog.API.Data.Interfaces;
using Catalog.API.Entities;
using Catalog.API.Options;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.API.Data;

public class CatalogContext : ICatalogContext
{
    
    public CatalogContext(IOptions<CatalogDbSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(
            databaseSettings.Value.ConnectionString);

       var mongoDatabase = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
        
        Products =mongoDatabase.GetCollection<Product>(
            databaseSettings.Value.ProductsCollectionName);
    }
    
    public IMongoCollection<Product> Products { get; } 

  
}
