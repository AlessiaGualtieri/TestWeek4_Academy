using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Week4.Academy.Test.Core.BusinessLayer;
using Week4.Academy.Test.Core.Models;
using Week4.Academy.Test.Core.Repositories;
using Week4.Academy.Test.EF.Repositories;

namespace Week4.Academy.Test.WCF
{
    public class CustomerService : ICustomerService
    {
        private readonly IBusinessLayer mainBL;

        public CustomerService()
        {
            this.mainBL = new MainBusinessLayer(new EFCustomerRepository(new EF.ServicesContext()),
                new EFOrderRepository(new EF.ServicesContext()));
        }

        public bool AddCustomer(Customer item)
        {
            if (item == null)
                return false;
            return mainBL.AddCustomer(item);
        }

        public bool DeleteByIdCustomer(int id)
        {
            if (id <= 0)
                return false;
            return mainBL.DeleteByIdCustomer(id);
        }

        public IList<Customer> FetchCustomer()
        {
            return mainBL.FetchCustomer();
        }

        public Customer GetByIDCustomer(int id)
        {
            if (id <= 0)
                return null;
            return mainBL.GetByIDCustomer(id);
        }

        public bool UpdateCustomer(Customer item)
        {
            if (item == null)
                return false;
            return mainBL.UpdateCustomer(item);
        }
    }
}
