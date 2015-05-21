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

namespace CafeDiamondCemesterProjekt.ViewModel
{
    class Viewmodel : INotifyPropertyChanged
    {

        public DateTime tid { get; set; }
        public int bord { get; set; }
        public int KID { get; set; }

        public string navn {get; set;}
        
        public string Email { get; set; }
        public string Saldo { get; set; }
        public string status { get; set; }

        public string søgefelt { get; set; }

        public List<Kunde> ListeTilView { get; set; }

        public ICommand TilføjBooking { get { RelayCommand _relay = new RelayCommand(TilfBooking); return _relay; } }
        public ICommand TilføjBruger { get { RelayCommand _relay = new RelayCommand(TilfBruger); return _relay; } }

        public ICommand SøgFunktion { get { RelayCommand _relay = new RelayCommand(Søg); return _relay; } }

        private void Søg()
        {
            
            OnPropertyChanged("søgefelt");
            
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Daniel\Documents\GitHub\2.-cemester-projekt\CafeDiamondCemesterProjekt\DB\DB.mdf;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            string selectSql = "select KundeID, Navn, Email, Saldo from dbo.Kunde where Navn LIKE '" + søgefelt + "';";

            SqlCommand command = new SqlCommand(selectSql, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<Kunde> KundeList = new List<Kunde>();
            while (reader.Read()){ 
            try
            {
                reader.Read();

                int KundeID = reader.GetInt16(0);
                string navn = reader.GetString(1);
                string Email = reader.GetString(2);
                string Saldo = reader.GetString(3);

                KundeList.Add(new Kunde(KundeID, navn, navn, Saldo));

            }
            catch (Exception)
            {

            }
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
            Debug.WriteLine(navn);
            Debug.WriteLine(Email);
            Debug.WriteLine(Saldo);
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Daniel\Documents\GitHub\2.-cemester-projekt\CafeDiamondCemesterProjekt\DB\DB.mdf;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            string insertSql = "insert into dbo.Kunde (Navn, Email, Saldo) values ('" +
                                  navn + "','" + Email + "','" + Saldo + "')";

            SqlCommand command = new SqlCommand(insertSql, connection);
            connection.Open();

            try
            {
                command.ExecuteNonQuery();
                status = "Kunde oprettet";
                OnPropertyChanged("status");
            }
            catch (Exception)
            {
                status = "Der opstod en fejl";
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
