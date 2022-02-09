using ProductMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.Helper
{
    public class HelperClass
    {
        public static List<Product> products = new List<Product>
        {
            new Product{ ProductId = 1, ProductName = "mobile", Description = "This is OnePlus8t mobile ", ImageName = "../images/product1.jpg", Price = 40000, Rating = 5},
            new Product{ ProductId = 2, ProductName = "watch", Description = "This is Iwatch", ImageName = "../images/product2.jpg", Price = 30000, Rating = 5},
            new Product{ ProductId = 3, ProductName = "laptop", Description = "This is Mac Laptop", ImageName = "../images/product3.jpg", Price = 80000, Rating = 4},
            new Product{ ProductId = 4, ProductName = "headset", Description = "This is Amazon Headset", ImageName = "../images/product4.jpg", Price = 4599, Rating = 2},
            new Product{ ProductId = 5, ProductName = "home theater", Description = "This is Roger Home Theater", ImageName = "../images/product5.jpg", Price = 4000, Rating = 5}
        };
    }
}
