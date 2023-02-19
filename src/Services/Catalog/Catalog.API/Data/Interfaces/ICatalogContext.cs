using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data.Interfaces;

public interface ICatalogContext
{
    public IMongoCollection<Product> Products { get; }
}
