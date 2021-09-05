using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iterator_pattern
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime Orderdate { get; set; }

    }

    public interface IIterator<T>
    {
        bool NextItem();       
        T CurrentItem { get; }
    }

    public interface IAggegate<T>
    {
        IIterator<T> CreateIterator();
    }

    public class OrderContainer : IAggegate<Order>
    {
        private List<Order> orders = new List<Order>();

        public List<Order> OrderList
        {
            get 
            {
                return this.orders;
            }
        }

        public void AddOrder(Order order)
        {
            this.orders.Add(order);
        }

        public int OrderCount
        {
            get { return this.orders.Count; }
        }

        public IIterator<Order> CreateIterator()
        {
            return new OrderIterator(this);
        }
    }

    public class OrderIterator : IIterator<Order>
    {

        private OrderContainer _orderContainer;

        public OrderIterator(OrderContainer orderContainer)
        {
            this._orderContainer = orderContainer;
        }

        private int currentIndex = 0;

        public Order CurrentItem { get; private set; }

        public bool NextItem()
        {
            if (currentIndex < _orderContainer.OrderCount)
            {
                this.CurrentItem = this._orderContainer.OrderList[currentIndex++];
                return true;
            }
            else
            {
                return false;
            }
        }
    }


}
