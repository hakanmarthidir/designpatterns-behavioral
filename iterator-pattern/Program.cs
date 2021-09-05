using System;

namespace iterator_pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderContainer orderContainer = new OrderContainer();
            orderContainer.AddOrder(new Order() { Id= Guid.NewGuid(), Orderdate=DateTime.Now.AddDays(4)  });
            orderContainer.AddOrder(new Order() { Id = Guid.NewGuid(), Orderdate = DateTime.Now.AddDays(1) });
            orderContainer.AddOrder(new Order() { Id = Guid.NewGuid(), Orderdate = DateTime.Now.AddDays(3) });
            orderContainer.AddOrder(new Order() { Id = Guid.NewGuid(), Orderdate = DateTime.Now.AddDays(2) });


            var orderIterator = orderContainer.CreateIterator();

            while (orderIterator.NextItem())
            {
                Console.WriteLine(orderIterator.CurrentItem.Id);
            }
        }
    }
}
