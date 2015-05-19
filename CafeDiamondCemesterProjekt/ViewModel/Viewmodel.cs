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

namespace CafeDiamondCemesterProjekt.ViewModel
{
    class Viewmodel : INotifyPropertyChanged
    {

        public DateTime tid { get; set; }
        public int bord { get; set; }
        public int KID { get; set; }

        public string navn {get; set;}
        public string Email { get; set; }
        public int Saldo { get; set; }




        public ICommand TilføjBooking { get { RelayCommand _relay = new RelayCommand(TilfBooking); return _relay; } }
        public ICommand TilføjBruger { get { RelayCommand _relay = new RelayCommand(TilfBruger); return _relay; } }

        public void TilfBruger()
        {

            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='|DataDirectory|\DB.mdf';Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            string insertSql = "insert into dbo.Kunde (Navn, Email, Saldo) values ('" +
                                  navn + "','" + Email + "','" + Saldo + "')";

            SqlCommand command = new SqlCommand(insertSql, connection);
            connection.Open();
            
            command.ExecuteNonQuery();
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
            
            command.ExecuteNonQuery();
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
