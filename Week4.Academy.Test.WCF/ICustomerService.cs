using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Week4.Academy.Test.Core.Models;

namespace Week4.Academy.Test.WCF
{
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        IList<Customer> FetchCustomer();

        [OperationContract]
        Customer GetByIDCustomer(int id);

        [OperationContract]
        bool AddCustomer(Customer item);

        [OperationContract]
        bool UpdateCustomer(Customer item);

        [OperationContract]
        bool DeleteByIdCustomer(int id);

    }

}
