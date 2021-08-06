using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Week4.Academy.Test.SelfHosting
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(
                typeof(Week4.Academy.Test.WCF.CustomerService)))
            {
                host.Open();

                Console.WriteLine("----- Customer WCF Service -----\n" +
                    "Insert anything to stop service ...");
                Console.ReadLine();
            }
        }
    }
}
