using System;
using System.Collections.Generic;
using System.Text;
using Week4.Academy.Test.Core.Models;

namespace Week4.Academy.Test.Core.Repositories
{
    public interface IBusinessLayer
    {
        #region Customer
        IList<Customer> FetchCustomer();

        Customer GetByIDCustomer(int id);

        bool AddCustomer(Customer item);

        bool UpdateCustomer(Customer item);

        bool DeleteByIdCustomer(int id);
        #endregion

        #region Order
        IList<Order> FetchOrder();

        Order GetByIDOrder(int id);

        bool AddOrder(Order item);

        bool UpdateOrder(Order item);

        bool DeleteByIdOrder(int id);
        #endregion

    }
}
