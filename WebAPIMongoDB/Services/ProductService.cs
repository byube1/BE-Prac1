using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using WebAPIMongoDB.Models;

namespace WebAPIMongoDB.Services
{
    
    public class ProductService
    {
        private readonly IMongoCollection<Product> _product;

        public ProductService(IProductDbDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _product = database.GetCollection<Product>(settings.ProductCollectionName);
        }

        public List<Product> Get() =>
            _product.Find(pd => true).ToList();

        public Product Get(string id) =>
            _product.Find<Product>(book => book.Id == id).FirstOrDefault();

        public Product Create(Product pd)
        {
            _product.InsertOne(pd);
            return pd;
        }

        public void Update(string id, Product pdIn) =>
            _product.ReplaceOne(pd => pd.Id == id, pdIn);

        public void Remove(Product pdIn) =>
            _product.DeleteOne(pd => pd.Id == pdIn.Id);

        public void Remove(string id) =>
            _product.DeleteOne(pd => pd.Id == id);
    }
}
