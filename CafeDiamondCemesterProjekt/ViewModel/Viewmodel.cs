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

namespace CafeDiamondCemesterProjekt.ViewModel
{
    class Viewmodel : INotifyPropertyChanged
    {

        public DateTime tid { get; set; }
        public int bord { get; set; }
        public int KID { get; set; }

        public string navn {get; set;}
        public string Email { get; set; }
        public string Mobil { get; set; }
        public string password { get; set; }
        public string Saldo { get; set; }


        public string status { get; set; }
        public string TjekVar { get; set; }
        public string søgefelt { get; set; }

        public List<Kunde> ListeTilView { get; set; }

        public ICommand TilføjBooking { get { RelayCommand _relay = new RelayCommand(TilfBooking); return _relay; } }
        public ICommand TilføjBruger { get { RelayCommand _relay = new RelayCommand(TilfBruger); return _relay; } }
        public ICommand TjekKunde { get { RelayCommand _relay = new RelayCommand(Tjek); return _relay; } }

        private void Tjek()
        {
            OnPropertyChanged("TjekVar");

            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Daniel\Documents\GitHub\2.-cemester-projekt\CafeDiamondCemesterProjekt\DB\DB.mdf;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            string selectSql = ("select KundeID, Navn, Email, Saldo, Mobil, Password from dbo.Kunde where Mobil LIKE '" + TjekVar + "'");

            SqlCommand command = new SqlCommand(selectSql, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();


            if (reader.Read())
            {
                MessageBoxResult res = MessageBox.Show("Bruger fundet");
            }else
            {
                MessageBoxResult res = MessageBox.Show("Kunde ikke finde bruger");
            }

            reader.Close();
            connection.Close();
        }
        public ICommand SøgFunktion { get { RelayCommand _relay = new RelayCommand(Søg); return _relay; } }

        private void Søg()
        {
            
            OnPropertyChanged("søgefelt");
            Debug.WriteLine(søgefelt);
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

        public void TilfBruger()
        {
            
            OnPropertyChanged("navn");
            OnPropertyChanged("Email");
            OnPropertyChanged("Saldo");
            OnPropertyChanged("password");
            OnPropertyChanged("Mobil");

            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Daniel\Documents\GitHub\2.-cemester-projekt\CafeDiamondCemesterProjekt\DB\DB.mdf;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            string insertSql = "insert into dbo.Kunde (Navn, Email, Saldo, Mobil, Password) values ('" +
                                  navn + "','" + Email + "','" + Saldo + "','" + Mobil + "','" + password + "')";

            SqlCommand command = new SqlCommand(insertSql, connection);
            connection.Open();

            try{
                command.ExecuteNonQuery();
                status = "Kunde oprettet";
                MessageBoxResult res = MessageBox.Show("Bruger oprettet");
                OnPropertyChanged("status");
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

        private void TilfBooking()
        {
            OnPropertyChanged("tid");
            OnPropertyChanged("bord");
            OnPropertyChanged("KID");
            

            var tidd = tid.ToLongDateString();

            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='|DataDirectory|\DB.mdf';Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            string insertSql = "insert into dbo.Booking (Bord, KundeID, Dato) values ('" +
                                  bord + "','" + KID + "','" + tidd + "')";

            SqlCommand command = new SqlCommand(insertSql, connection);
            connection.Open();


            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBoxResult res = MessageBox.Show("Fejl");
            }
            //NEW BOOKING ADDED
            connection.Close();
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
