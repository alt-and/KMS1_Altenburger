using System;
using System.IO;
using System.Windows;
using System.Windows.Forms;


namespace KMS_Altenburger_Andre
{
    /// <summary>
    /// Interaktionslogik für TransactionWindow.xaml
    /// </summary>
    public partial class TransactionWindow : Window
    {

        MainWindow main;
        public TransactionWindow(MainWindow mainWindow, string selectedItem)
        {
            main = mainWindow;
            InitializeComponent();
            FillListView(selectedItem);
        }


        /// <summary>
        /// Filling the listView's Recieved Money and Send Money with Information, calculating and displaying the account balance and also the send and recieved money
        /// </summary>
        /// <param name="selectedItem"></param>
        /// 
        private void FillListView(string selectedItem)
        {
            MoneyBankMethods.transmitterIbans.Clear();
            MoneyBankMethods.recievingIbans.Clear();

            recievingIbans_ListView.ItemsSource = null;
            transmitterIbans_ListView.ItemsSource = null;

            string betterItem = selectedItem.Remove(24, 1);
            string recievingMoney = "";
            string transmittingMoney = "";

            for (int i = 0, j = 1, x = 0; i <= MoneyBankMethods.datas.Length - 2;)
            {
                if (betterItem.Equals(MoneyBankMethods.datas[x]))
                {
                    MoneyBankMethods.transmitterIbans.Add(new Account()
                    {
                        Transmitteriban1 = MoneyBankMethods.datas[i],
                        Recievingiban1 = MoneyBankMethods.datas[i + 1]
                        ,
                        Purpose1 = MoneyBankMethods.datas[i + 2],
                        Amount1 = MoneyBankMethods.datas[i + 3],
                        Bookingdate1 = MoneyBankMethods.datas[i + 4]
                    });
                    transmittingMoney += MoneyBankMethods.datas[i + 3] + "/";

                }
                else if (betterItem.Equals(MoneyBankMethods.datas[j]))
                {
                    MoneyBankMethods.recievingIbans.Add(new Account()
                    {
                        Transmitteriban1 = MoneyBankMethods.datas[i+1],
                        Recievingiban1 = MoneyBankMethods.datas[i]
                        ,
                        Purpose1 = MoneyBankMethods.datas[i + 2],
                        Amount1 = MoneyBankMethods.datas[i + 3],
                        Bookingdate1 = MoneyBankMethods.datas[i + 4]
                    });
                    recievingMoney += MoneyBankMethods.datas[i + 3] + "/";
                }

                i += 5;
                x += 5;
                j += 5;

            }

            BalanceLogic(recievingMoney, transmittingMoney);

            recievingIbans_ListView.ItemsSource = MoneyBankMethods.recievingIbans;
            transmitterIbans_ListView.ItemsSource = MoneyBankMethods.transmitterIbans;

        }

        
        /// <summary>
        /// Balance logik
        /// </summary>
        /// <param name="recievingMoney"></param>
        /// <param name="transmittingMoney"></param>

        public void BalanceLogic(string recievingMoney, string transmittingMoney)
        {

            string[] splittedRecievingMoney = recievingMoney.Replace('.', ',').Split('/');
            string[] splittedTransmittingMoney = transmittingMoney.Replace('.', ',').Split('/');
            decimal standartBalance = 0;
            decimal transmittedMoney = 0;
            decimal recievedMoney = 0;

            for (int i = 0; i < splittedRecievingMoney.Length - 1; i++)
            {
                standartBalance += Convert.ToDecimal(splittedRecievingMoney[i]);
                recievedMoney += Convert.ToDecimal(splittedRecievingMoney[i]);
            }

            for (int i = 0; i < splittedTransmittingMoney.Length - 1; i++)
            {
                standartBalance -= Convert.ToDecimal(splittedTransmittingMoney[i]);
                transmittedMoney -= Convert.ToDecimal(splittedTransmittingMoney[i]);
            }

            Math.Round(standartBalance);

            showAccountBalance_lbl.Content = standartBalance;
            showRecievedMoney_lbl.Content = recievedMoney;
            showSendMoney_lbl.Content = transmittedMoney;

        }

        
        /// <summary>
        /// Event to close the window and show the main window again
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            main.Show();
        }

        
        /// <summary>
        /// Saves the Bookings with a good looking format
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void SaveFilesButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Text (*.txt)|*.txt|Csv (*.csv)|*.csv";
            saveFile.FilterIndex = 3;
            saveFile.InitialDirectory = Environment.CurrentDirectory;
            if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                StreamWriter sw = new StreamWriter(saveFile.FileName, false);

                sw.WriteLine("|TransmitterIBAN, RecievingIBAN, Purpose, Amount, BookingDate|");

                foreach (Account item in MoneyBankMethods.transmitterIbans)
                {
                    sw.Write(item.Transmitteriban1 + ", " + item.Recievingiban1 + ", " + item.Purpose1 + ", " + item.Amount1 + "€," + item.Bookingdate1 + Environment.NewLine);
                }
                
                sw.Write("\n\n|RecievingIBAN, TransmitterIBAN, Purpose, Amount, BookingDate|\n");

                foreach (Account item in MoneyBankMethods.recievingIbans)
                {
                    sw.Write(item.Transmitteriban1 + ", " + item.Recievingiban1 + ", " + item.Purpose1 + ", " + item.Amount1 + "€," + item.Bookingdate1 + Environment.NewLine);
                }

                System.Windows.MessageBox.Show("Success");

                sw.Close();

            }
        }
    }
}
