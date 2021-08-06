using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Week4.Academy.Test.Core.Models;
using Week4.Academy.Test.Core.Repositories;

namespace Week4.Academy.Test.EF.Repositories
{
    public class EFCustomerRepository : ICustomerRepository
    {
        private readonly ServicesContext ctx;

        public EFCustomerRepository(ServicesContext context)
        {
            this.ctx = context;
        }

        public bool Add(Customer item)
        {
            if (item == null)
                return false;
            try
            {
                ctx.Customers.Add(item);
                ctx.SaveChanges();

                return true;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public bool DeleteById(int id)
        {
            if (id <= 0)
                return false;
            try
            {
                Customer customerToDelete = ctx.Customers.Find(id);
                if (customerToDelete == null)
                    return false;
                ctx.Customers.Remove(customerToDelete);
                ctx.SaveChanges();

                return true;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public IList<Customer> Fetch()
        {
            return ctx.Customers.ToList();
        }

        public Customer GetByID(int id)
        {
            if (id <= 0)
                return null;
            try
            {
                return ctx.Customers.Find(id);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public bool Update(Customer item)
        {
            if (item == null)
                return false;
            try
            {
                Customer customerToUpdate = ctx.Customers.Find(item.ID_Customer);
                if (customerToUpdate == null)
                    return false;

                customerToUpdate.FirstName = item.FirstName;
                customerToUpdate.LastName = item.LastName;
                customerToUpdate.CustomerCode = item.CustomerCode;
                customerToUpdate.Orders = item.Orders;

                ctx.SaveChanges();

                return true;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }
    }
}
