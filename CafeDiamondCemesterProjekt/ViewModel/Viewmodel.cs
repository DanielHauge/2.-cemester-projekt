using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using CafeDiamondCemesterProjekt.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using CafeDiamondCemesterProjekt.Model;
using CafeDiamondCemesterProjekt.View;
using System.Windows;
using System.Windows.Controls;

namespace CafeDiamondCemesterProjekt.ViewModel
{
    class Viewmodel : INotifyPropertyChanged
    {


        public string navn {get; set;}
        public string Email { get; set; }
        public string ListView { get; set; }
        public string Mobil { get; set; }
        public string password { get; set; }
        public string Saldo { get; set; }

        public bool Update = false;
        public string status { get; set; }

        public string søgefelt { get; set; }

        public int RedigVar { get; set; }

        public List<Kunde> ListeTilView { get; set; }

        public ICommand TilføjBruger { get { RelayCommand _relay = new RelayCommand(TilfBruger); return _relay; } }
        public void TilfBruger()
        {

            OnPropertyChanged("navn");
            OnPropertyChanged("Email");
            OnPropertyChanged("Saldo");
            OnPropertyChanged("password");
            OnPropertyChanged("Mobil");

            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Daniel\Documents\GitHub\2.-cemester-projekt\CafeDiamondCemesterProjekt\DB\DB.mdf;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            string insertSql;
            if (!Update)
            {
                insertSql = "insert into dbo.Kunde (Navn, Email, Saldo, Mobil, Password) values ('" +
                                      navn + "','" + Email + "','" + Saldo + "','" + Mobil + "','" + password + "')";
            }
            else
            {
                
                insertSql = "UPDATE dbo.Kunde SET Navn='" + navn + "', Email='" + Email + "', Saldo='" + Saldo + "', Mobil='" + Mobil + "', Password='" + password + "' WHERE KundeID='" + RedigVar + "';";
                
            }



            SqlCommand command = new SqlCommand(insertSql, connection);
            connection.Open();
            try{
                command.ExecuteNonQuery();
                if (Update)
                {
                    MessageBoxResult res = MessageBox.Show("Redigering er fuldført.");
                    status = "Redigeret!";
                    OnPropertyChanged("status");
                    Update = false;
                }
                else
                {
                    status = "Kunde oprettet";
                    MessageBoxResult ss = MessageBox.Show("Bruger oprettet");
                    OnPropertyChanged("status");
                }
                
            }
            catch (Exception)
            {
                MessageBoxResult res = MessageBox.Show("Fejl\nFejlen kan være opstået af flere årsager\n For at undgå fejlen forsøg at følge nedenstående\nAnvend kun heltal i Saldo\nAnvend kun 10 eller mindre tegn i mobilnummer");
                status = "Fejl opstået";
                OnPropertyChanged("status");
            }
            //NEW BOOKING ADDED
            connection.Close();

        }
        public ICommand RedigerKunde { get { RelayCommand _relay = new RelayCommand(Rediger); return _relay; } }
        private void Rediger()
        {
            Update = true;
            //Splitting shit
            FindRedigVar();
            
            if (RedigVar > 0)
            {
                MessageBoxResult res = MessageBox.Show("Redigering kan foretages nu!");
                status = "Redigering kan nu foretages.";
                OnPropertyChanged("status");
            }

        }

        private void FindRedigVar()
        {
            try
            {
                string str = ListView.Remove(0, 9);
                string result = "";
                for (int i = 0; i < str.Length; i++) // loop over the complete input
                {
                    if (Char.IsDigit(str[i])) //check if the current char is digit
                        result += str[i];
                    else
                        break; //Stop the loop after the first character
                }
                RedigVar = Int16.Parse(result);
            }
            catch
            {
                MessageBoxResult res = MessageBox.Show("Der skal være mærkeret en bruger");
            }
        }
        public ICommand SletKunde { get { RelayCommand _relay = new RelayCommand(Slet); return _relay; } }
        private void Slet()
        {
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Daniel\Documents\GitHub\2.-cemester-projekt\CafeDiamondCemesterProjekt\DB\DB.mdf;Integrated Security=True";
            OnPropertyChanged("RedigVar");
            SqlConnection connection = new SqlConnection(connectionString);
                FindRedigVar();

                string insertSql = "DELETE FROM dbo.Kunde WHERE KundeID='" + RedigVar + "'";

                Debug.Write(RedigVar);


            SqlCommand command = new SqlCommand(insertSql, connection);
            connection.Open();

            try
            {
                command.ExecuteNonQuery();
                status = "Bruger slettet";
                MessageBoxResult res = MessageBox.Show("Bruger Slettet");
                OnPropertyChanged("status");
                Søg();
            }
            catch (Exception)
            {
                MessageBoxResult res = MessageBox.Show("Der skete en fejl");
            }
            //NEW BOOKING ADDED
            connection.Close();
        }

        public ICommand SøgFunktion { get { RelayCommand _relay = new RelayCommand(Søg); return _relay; } }
        private void Søg()
        {
            
            OnPropertyChanged("søgefelt");
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Daniel\Documents\GitHub\2.-cemester-projekt\CafeDiamondCemesterProjekt\DB\DB.mdf;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            string selectSql = ("select KundeID, Navn, Email, Saldo, Mobil, Password from dbo.Kunde where Navn LIKE '%" + søgefelt+ "%'");

            SqlCommand command = new SqlCommand(selectSql, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<Kunde> KundeList = new List<Kunde>();
            while (reader.Read()){ 

                int KundeID = reader.GetInt16(0);
                string navn = reader.GetString(1);
                string Email = reader.GetString(2);
                int Saldo = reader.GetInt32(3);
                string Mobil = reader.GetString(4);
                string password = reader.GetString(5);

                KundeList.Add(new Kunde(KundeID, navn, navn, Saldo, Mobil, password));

                reader.Read();
            }

                reader.Close();
                connection.Close();

            ListeTilView = KundeList;
            OnPropertyChanged("ListeTilView");
        }


        #region propertychanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
