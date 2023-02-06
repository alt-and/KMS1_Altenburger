using System.Collections.Generic;

namespace KMS_Altenburger_Andre
{
    //Helper class and for listview
    public class Customer
    {
        public Customer(string customerid, string name)
        {
            Customerid = customerid;
            Name = name;
        }

        public string Customerid1
        {
            get => Customerid;
            set => Customerid = value;
        }

        public string Name1
        {
            get => Name;
            set => Name = value;
        }

        public static List<Customer> customerList = new List<Customer>();

        public string Customerid;
        public string Name;
    }
}