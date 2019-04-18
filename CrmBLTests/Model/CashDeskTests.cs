using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrmBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBL.Model.Tests
{
    [TestClass()]
    public class CashDeskTests
    {
        [TestMethod()]
        public void CashDeskTest()
        {
            //arrange
            var customer1 = new Customer() {
                CustomerId=1,
                Name ="testUser1",

            };
            var customer2 = new Customer() {
                CustomerId=2,
                Name ="testUser2",

            };
            var seller = new Seller()
            {
                SellerId = 5,
                Name = "Garry"
            };
            var product1 = new Product()
            {
                ProductId = 1,
                Name = "pr1",
                Price = 100M,
                Count = 10
            };
            var product2 = new Product()
            {
                ProductId = 2,
                Name = "pr2",
                Price = 200M,
                Count = 5
            };
            var cart1 = new Cart(customer1);
            cart1.Add(product1);
            cart1.Add(product1);
            cart1.Add(product2);
            var cart2 = new Cart(customer2);
            cart2.Add(product1);
            cart2.Add(product2);
            cart2.Add(product2);
            cart2.Add(product2);
            var cashdesk = new CashDesk(1, seller);
            cashdesk.Enqueue(cart1);
            cashdesk.Enqueue(cart2);

            var expectedCart1Result = 400;
            var expectedCart2Result = 700;


            //act
            var cart1ActualResult = cashdesk.Dequeue();
            var cart2ActualResult = cashdesk.Dequeue();
            //assert

            Assert.AreEqual(expectedCart1Result, cart1ActualResult);
            Assert.AreEqual(expectedCart2Result, cart2ActualResult);
            Assert.AreEqual(7, product1.Count);
            Assert.AreEqual(1, product2.Count);

        }

        
    }
}