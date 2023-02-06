using System.Collections.Generic;


namespace KMS_Altenburger_Andre
{
    public class MoneyBankMethods
    {
        public static Dictionary<string, string> IdAndNameDictionary = new Dictionary<string, string>();

        public static SortedDictionary<string, string> sortedAccountsDictionary = new SortedDictionary<string, string>();

        public static List<CustomerDetails> accountIbans = new List<CustomerDetails>();

        public static List<Account> transmitterIbans = new List<Account>();

        public static List<Account> recievingIbans = new List<Account>();

        public static string[] datas;


            //
            /// <summary>
            /// Sorting and making objects to be addet in to the Dictionary for the listview
            /// </summary>
            /// <param name="data"></param>

        public static void AddingDataToDictionary(string[] data)
        {

            for (int i = 1; i <= data.Length-1; i++)
            {
                if (sortedAccountsDictionary.ContainsKey(data[i]))
                {
                    sortedAccountsDictionary[data[i]] += "," + data[i + 1];
                }
                else
                {
                    sortedAccountsDictionary.Add(data[i], data[i+1]);
                }

                CustomerDetails customer = new CustomerDetails( data[i+1]);

                CustomerDetails.customerDetailsList.Add(customer);
                i++;
            }
        }
        //
        /// <summary>
        /// Sorting and making objects to be addet in to the Dictionary for the listview
        /// </summary>
        /// <param name="data"></param>

        public static void CustomerList(string data)
        {

            string[] sortedData = sortData(data, 17);
            
            for (int i = 0; i <= 99; i++)
            {

                Customer customer = new Customer(sortedData[i], sortedData[i + 1]);
                Customer.customerList.Add(customer);
                i++;

            }
        }
        //
        /// <summary>
        /// Sorting and making objects to be addet in to the Dictionary for the listview
        /// </summary>
        /// <param name="data"></param>

        public static void transactionList(string[] data)
        {

            datas=data;

            for (int i = 0, j = 0; i <= data.Length-2;)
            {
                if (sortedAccountsDictionary.ContainsValue(data[i])||sortedAccountsDictionary.ContainsValue(data[i+1]))
                {

                    Account.accountTransactions.Add(new Account() { Transmitteriban1 = data[i], Recievingiban1 = data[i+1]
                        , Purpose1 = data[i+2], Amount1 = data[i+3], Bookingdate1 = data[i+4]});

                }

                i+=5;
                
            }
        }

        //
        /// <summary>
        /// Generally sorting the data when reading it all
        /// </summary>
        /// <param name="data"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        
        public static string[] sortData(string data, int count)
        {
            string r = data.Remove(0, count);

            string replaced1Lines = r.Replace('\r', ' ');

            string replaced2Lines = replaced1Lines.Replace('\n', ',');

            string[] sortedLinesSplit = replaced2Lines.Split(',');
            
            return sortedLinesSplit;
        }
    }
    
}