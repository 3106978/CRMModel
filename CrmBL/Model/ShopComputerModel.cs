﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CrmBL.Model
{
    public class ShopComputerModel
    {
        Random rnd = new Random();
        Generator Generator { get; set; } = new Generator();
        public List<CashDesk> CashDesks { get; set; } = new List<CashDesk>();
        public List<Sell> Sells { get; set; } = new List<Sell>();
        public List<Cart> Carts { get; set; } = new List<Cart>();
        public List<Check> Checks { get; set; } = new List<Check>();
        public Queue<Seller> Sellers { get; set; } = new Queue<Seller>();
        bool isWorking = false;

        public int CustomerSpeed { get; set; } = 100;

        public int CashdeskSpeed { get; set; } = 100;
        public ShopComputerModel()
        {
            var sellers = Generator.GetNewSellers(20);
            Generator.GetNewProducts(1000);
            Generator.GetNewCustomers(100);
            foreach (var seller in sellers)
            {
                Sellers.Enqueue(seller);
            }
            for (int i = 0; i < 3; i++)
            {
                CashDesks.Add(new CashDesk(CashDesks.Count, Sellers.Dequeue()));
            }
        }
        public void Start()
        {
            isWorking = true;
            Task.Run(() => CreateCarts(10, CustomerSpeed));

            var cashDeskTasks = CashDesks.Select(c => new Task(() => CashDeskWork(c, CashdeskSpeed)));
            foreach (var task in cashDeskTasks)
            {
                task.Start();
            }
        }
        public void Stop()
        {
            isWorking = false;
        }
        private void CashDeskWork(CashDesk cashDesk, int sleep)
        {
            while (isWorking)
            {
                if (cashDesk.Count > 0)
                {
                    cashDesk.Dequeue();
                    Thread.Sleep(sleep);
                }
            }
            
        }
        private void CreateCarts(int customerCounts, int sleep)
        {
            while (isWorking)
            {
                var customers = Generator.GetNewCustomers(customerCounts);
                
                foreach (var customer in customers)
                {
                    var cart = new Cart(customer);
                    foreach (var product in Generator.GetRandomProducts(10,30))
                    {
                        cart.Add(product);
                    }
                    var cashDesk = CashDesks[rnd.Next(CashDesks.Count)];// TODO
                    cashDesk.Enqueue(cart);
                }
                Thread.Sleep(sleep);
            }
            
        }
    }
}
