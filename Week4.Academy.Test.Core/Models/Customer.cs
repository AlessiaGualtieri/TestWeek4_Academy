using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Week4.Academy.Test.Core.Models
{
    [DataContract]
    public class Customer
    {
        [DataMember]
        public int ID_Customer { get; set; }
        [DataMember]
        public string CustomerCode { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }

        public IList<Order> Orders { get; set; }

        public override string ToString()
        {
            return $"{ID_Customer} - {FirstName} {LastName}, " +
                $"customer code: {CustomerCode}";
        }
    }
}
