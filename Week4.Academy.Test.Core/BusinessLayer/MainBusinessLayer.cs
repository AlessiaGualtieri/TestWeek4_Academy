using System;
using System.Collections.Generic;
using System.Text;
using Week4.Academy.Test.Core.Models;
using Week4.Academy.Test.Core.Repositories;

namespace Week4.Academy.Test.Core.BusinessLayer
{
    public class MainBusinessLayer : IBusinessLayer
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IOrderRepository orderRepository;

        public MainBusinessLayer(ICustomerRepository customerRepository, IOrderRepository orderRepository)
        {
            this.customerRepository = customerRepository;
            this.orderRepository = orderRepository;
        }

        #region Customer
        public bool AddCustomer(Customer item)
        {
            return (item == null) ? false : customerRepository.Add(item);
        }

        public bool DeleteByIdCustomer(int id)
        {
            return (id <= 0) ? false : customerRepository.DeleteById(id);
        }

        public IList<Customer> FetchCustomer()
        {
            return customerRepository.Fetch();
        }

        public Customer GetByIDCustomer(int id)
        {
            return (id <= 0) ? null : customerRepository.GetByID(id);
        }

        public bool UpdateCustomer(Customer item)
        {
            return (item == null) ? false : customerRepository.Update(item);
        }

        #endregion

        #region Order
        public bool AddOrder(Order item)
        {
            return (item == null) ? false : orderRepository.Add(item);
        }


        public bool DeleteByIdOrder(int id)
        {
            return (id <= 0) ? false : orderRepository.DeleteById(id);
        }


        public IList<Order> FetchOrder()
        {
            return orderRepository.Fetch();
        }


        public Order GetByIDOrder(int id)
        {
            return (id <= 0) ? null : orderRepository.GetByID(id);
        }

        public bool UpdateOrder(Order item)
        {
            return (item == null) ? false : orderRepository.Update(item);
        }

        #endregion
    }
}
