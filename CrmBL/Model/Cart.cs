﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace CrmBL.Model
{
    public class Cart: IEnumerable
    {
        public Customer Customer { get; set; }
        Dictionary<Product, int> Products { get; set; }

        public Cart(Customer customer)
        {
            Customer = customer;
            Products = new Dictionary<Product, int>();
        }

        public void Add(Product product)
        {
            if (product != null && Products.TryGetValue(product, out int count))
            {
                Products[product] = ++count;
            }
            else
            {
                Products.Add(product, 1);
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var product in Products.Keys)
            {
                for (int i = 0; i < Products[product]; i++)
                {
                    yield return product;
                }
            }
        }
        public List<Product> GetAll()
        {
            var result = new List<Product>();
            foreach (Product i in this)
            {
                result.Add(i);
            }
            return result;
        }
    }
}
