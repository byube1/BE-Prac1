using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using WebAPIMongoDB.Models;

namespace WebAPIMongoDB.Services
{
   

    public class CustomerServices
    {
        private readonly IMongoCollection<Customer> _customer;

        public CustomerServices(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _customer = database.GetCollection<Customer>("customer");
        }

        public List<Customer> Get() =>
            _customer.Find(cus => true).ToList();

        public Customer Get(string id) =>
            _customer.Find<Customer>(cus => cus.Id == id).FirstOrDefault();

        public Customer Create(Customer cus)
        {
            _customer.InsertOne(cus);
            return cus;
        }

        public void Update(string id, Customer cusIn) =>
            _customer.ReplaceOne(cus => cus.Id == id, cusIn);

        public void Remove(Customer cusIn) =>
            _customer.DeleteOne(cus => cus.Id == cusIn.Id);

        public void Remove(string id) =>
            _customer.DeleteOne(cus => cus.Id == id);
    }
}

