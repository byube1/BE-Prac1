using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using WebAPIMongoDB.Models;

namespace WebAPIMongoDB.Services
{
    public class ShopppingCartServices
    {
        private readonly IMongoCollection<Order> _order;

        public ShopppingCartServices(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _order = database.GetCollection<Order>("cart");
        }

        public List<Order> Get() =>
            _order.Find(ord => true).ToList();

        public Order CreateOrder(Order order)
        {
            _order.InsertOne(order);
            return order;
        } 
    }
}
