using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIMongoDB.Models;
using WebAPIMongoDB.Services;

namespace WebAPIMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly ShopppingCartServices _shopppingCartServices;

        public OrderController(ShopppingCartServices shopppingCartServices)
        {
            _shopppingCartServices = shopppingCartServices;
        }

        [HttpGet]
        public ActionResult<List<Order>> Get() => _shopppingCartServices.Get();

        [HttpPost]
        public ActionResult<Order> createOrder(Order order)
        {
            _shopppingCartServices.CreateOrder(order);
            return Ok();
        }
    }
}
