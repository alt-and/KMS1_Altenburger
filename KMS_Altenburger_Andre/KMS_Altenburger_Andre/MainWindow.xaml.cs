using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;



namespace KMS_Altenburger_Andre
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        /// <summary>
        /// Loading the Necessary Files as ReadallText and then splitting it all with ","//
        /// </summary>
        public void LoadFiles()
        {

            FolderBrowserDialog openFiles = new FolderBrowserDialog();
            
            if (openFiles.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string folderPath = openFiles.SelectedPath;
                string customer = Path.Combine(folderPath, "Kunden.csv");
                string account = Path.Combine(folderPath, "Konten.csv");
                string transactions = Path.Combine(folderPath, "Buchungen.csv");
                
                //Getting data and then sending the data to be sorted and put in a list/Dictionary
                
                if (File.Exists(customer))
                {
                    load_Btn.IsEnabled = false;

                    string customerLines = File.ReadAllText(customer);

                    MoneyBankMethods.CustomerList(customerLines);

                    customerIdAndName_ListView.ItemsSource = Customer.customerList;

                    lst_ViewAddingItems();

                }
                if (File.Exists(account))
                {
                    load_Btn.IsEnabled = false;

                    string accountLines = File.ReadAllText(account);

                    string[] sortedDataArray = MoneyBankMethods.sortData(accountLines, 21);

                    MoneyBankMethods.AddingDataToDictionary(sortedDataArray);

                }
                if (File.Exists(transactions))
                {

                    load_Btn.IsEnabled = false;

                    string transactionLines = File.ReadAllText(transactions);

                    string[] sortedDataArray = MoneyBankMethods.sortData(transactionLines, 69);

                    MoneyBankMethods.transactionList(sortedDataArray);

                }
                else
                {
                    MessageBox.Show("Please choose the rigth folder.\n*In the folder has to be the 'Kunden.csv', 'Konten.csv' and 'Buchungen.csv'*");
                }
            }
            else
            {
                MessageBox.Show("Please choose a valid path!");
            }
        }
        
        
        /// <summary>
        /// Load Files Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        private void LoadFilesButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            details_Btn.IsEnabled=true;
            LoadFiles();
        }
        
        
        /// <summary>
        /// //Here im adding the items from accountOverviews(CustomerID and Name)
        /// </summary>
        
        private void lst_ViewAddingItems()
        {

            foreach (KeyValuePair<string, string> item in MoneyBankMethods.IdAndNameDictionary)
            {
                customerIdAndName_ListView.Items.Add(item.Key + item.Value);
            }

        }

        /// <summary>
        /// Generating the Transaction window and giving the selected iban with it 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void details_Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            try{

                string selectedItem = customerIban_ListView.SelectedItem.ToString();

                TransactionWindow transactionWindow = new TransactionWindow(this, selectedItem);

                transactionWindow.Show();

                this.Hide();
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message + "\nPlease choose a customer before continueing!", "ERROR");
            }
            
            
        }
        
        /// <summary>
        /// This is to search for the mathcing customer id for the iban's
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void detailedCustomerAccount_ListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            MoneyBankMethods.accountIbans.Clear();

            customerIban_ListView.ItemsSource = null;

            int selectedIndex = customerIdAndName_ListView.SelectedIndex;

            if (customerIdAndName_ListView.SelectedItem != null)
            {
                foreach (KeyValuePair<string, string> item in MoneyBankMethods.sortedAccountsDictionary)
                {

                    string[] ibanArray = MoneyBankMethods.sortedAccountsDictionary[item.Key].Split(',');

                    for (int i = 0; i < ibanArray.Length; i++)
                    {
                        if (item.Key.Equals(Customer.customerList[selectedIndex].Customerid))
                        {
                            MoneyBankMethods.accountIbans.Add(new CustomerDetails(ibanArray[i]) { Accountnumber = ibanArray[i] });
                        }
                    }

                }
                customerIban_ListView.ItemsSource = MoneyBankMethods.accountIbans;
            }
            else
            {
                details_Btn.IsEnabled = false;
                MessageBox.Show("Please choose a Customer before continueing");
            }
        }
    }
}