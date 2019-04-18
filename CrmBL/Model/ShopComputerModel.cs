using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var customers = Generator.GetNewCustomers(10);
            var carts = new Queue<Cart>();
            foreach (var customer in customers)
            {
                var cart = new Cart(customer);
                foreach (var prod in Generator.GetRandomProducts(3, 30))
                {
                    cart.Add(prod);
                }
                carts.Enqueue(cart);
            }
            

            while (carts.Count>0)
            {
                var cashDesk = CashDesks[rnd.Next(CashDesks.Count - 1)];// TODO
                cashDesk.Enqueue(carts.Dequeue());
            }
            while (CashDesks.Count>0)
            {
                var cashDesk = CashDesks[rnd.Next(CashDesks.Count - 1)];// TODO
                var money= cashDesk.Dequeue();
                CashDesks.Remove(cashDesk);
            }

        }
    }
}
