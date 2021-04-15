using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using WebAPIMongoDB.Models;

namespace WebAPIMongoDB.Services
{
    public class CustomerService
    {
        private readonly IMongoCollection<Customer> _customer;
        public CustomerService(IDatabaseSetting settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _customer = database.GetCollection<Customer>("customer");
        }
        public List<Customer> Get() =>
            _customer.Find(pd => true).ToList();

    }
}
