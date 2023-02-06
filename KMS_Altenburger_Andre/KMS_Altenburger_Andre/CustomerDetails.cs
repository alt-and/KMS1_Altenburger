using System.Collections.Generic;

namespace KMS_Altenburger_Andre
{
    //Helper class and for listview
    public class CustomerDetails
    {

        public string Accountnumber;

        public string Accountnumber1
        {
            get => Accountnumber;
            set => Accountnumber = value;
        }

        public static List<CustomerDetails> customerDetailsList = new List<CustomerDetails>();

        public CustomerDetails(string accountnumber)
        {
            Accountnumber = accountnumber;
        }

        public override string ToString()
        {
            return this.Accountnumber;
        }
    }
}