using System.Collections.Generic;

namespace KMS_Altenburger_Andre
{
    
    /// <summary>
    /// Helper class and for listview
    /// </summary>
    public class Account
    {
        public string Transmitteriban1
        {
            get => Transmitteriban;
            set => Transmitteriban = value;
        }

        public string Recievingiban1
        {
            get => Recievingiban;
            set => Recievingiban = value;
        }

        public string Purpose1
        {
            get => Purpose;
            set => Purpose = value;
        }

        public string Amount1
        {
            get => Amount;
            set => Amount = value;
        }

        public string Bookingdate1
        {
            get => Bookingdate;
            set => Bookingdate = value;
        }

        private string Transmitteriban;
        private string Recievingiban;
        private string Purpose;
        private string Amount;
        private string Bookingdate;
        
        public static List<Account> accountTransactions = new List<Account>();


    }
}