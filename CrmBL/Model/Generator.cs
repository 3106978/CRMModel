using System;
using System.Collections.Generic;

namespace CrmBL.Model
{
    public class Generator
    {
        Random rnd = new Random();
        public List<Customer> Customers  = new List<Customer>();
        public List<Product> Products  = new List<Product>();

        public List<Seller> Sellers= new List<Seller>();

        public List<Customer> GetNewCustomers(int count)
        {
            var result = new List<Customer>();
            for (int i = 0; i < count; i++)
            {
                var customer = new Customer()
                {
                    CustomerId=i,
                    Name = GetRandomText()
                };
                Customers.Add(customer);
                result.Add(customer);
            }
            return Customers;
        }
        public List<Seller> GetNewSellers(int count)
        {
            var result = new List<Seller>();
            for (int i = 0; i < count; i++)
            {
                var seller = new Seller()
                {
                    SellerId=i,
                    Name = GetRandomText()
                };
                Sellers.Add(seller);
                result.Add(seller);
            }
            return result;
        }

        public List<Product> GetNewProducts(int count)
        {
            var result = new List<Product>();
            for (int i = 0; i < count; i++)
            {
                var product = new Product()
                {
                    ProductId = i,
                    Name = GetRandomText(),
                    Count = rnd.Next(0, 1000),
                    Price = Convert.ToDecimal(rnd.Next(5, 5000) + rnd.NextDouble())
                };
                Products.Add(product);
                result.Add(product);
            }
            return result;
        }
        public List<Product> GetRandomProducts(int min, int max)
        {
            var result = new List<Product>();
            var count = rnd.Next(min, max);
            for (int i = 0; i < count; i++)
            {
                result.Add(Products[rnd.Next(Products.Count - 1)]);
            }
            return result;
        }

        private static string  GetRandomText()=> Guid.NewGuid().ToString().Substring(0, 5);
        
    }
    
}
