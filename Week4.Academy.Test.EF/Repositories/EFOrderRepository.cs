using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Week4.Academy.Test.Core.Models;
using Week4.Academy.Test.Core.Repositories;

namespace Week4.Academy.Test.EF.Repositories
{
    public class EFOrderRepository : IOrderRepository
    {
        private readonly ServicesContext ctx;

        public EFOrderRepository(ServicesContext context)
        {
            this.ctx = context;
        }

        public bool Add(Order item)
        {
            if (item == null)
                return false;
            try
            {
                ctx.Orders.Add(item);
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
                Order orderToDelete = ctx.Orders.Find(id);
                if (orderToDelete == null)
                    return false;
                ctx.Orders.Remove(orderToDelete);
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

        public IList<Order> Fetch()
        {
            try
            {
                return ctx.Orders.ToList();
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

        public Order GetByID(int id)
        {
            if (id <= 0)
                return null;
            try
            {
                return ctx.Orders.Find(id);
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

        public bool Update(Order item)
        {
            if (item == null)
                return false;
            try
            {
                Order orderToUpdate = ctx.Orders.Find(item.ID_Order);
                if (orderToUpdate == null)
                    return false;

                orderToUpdate.ID_Customer = item.ID_Customer;
                orderToUpdate.Import = item.Import;
                orderToUpdate.OrderCode = item.OrderCode;
                orderToUpdate.OrderDate = item.OrderDate;
                orderToUpdate.ProductCode = item.ProductCode;
                orderToUpdate.Customer = item.Customer;

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
