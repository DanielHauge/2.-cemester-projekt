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
    class ViewModelBooking : INotifyPropertyChanged
    {
        public string BMobil { get; set; }
        public int Bbord { get; set; }
        public string Bdato { get; set; }
        public string TjekVar { get; set; }
        public int KIDread { get; set; }
        public string Bstatus { get; set; }
        public string bookingViewDato { get; set; }

        public ICommand TjekKunde { get { RelayCommand _relay = new RelayCommand(Tjek); return _relay; } }
        private void Tjek()
        {
            OnPropertyChanged("BMobil");

            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Daniel\Documents\GitHub\2.-cemester-projekt\CafeDiamondCemesterProjekt\DB\DB.mdf;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            string selectSql = ("select KundeID, Navn, Email, Saldo, Mobil, Password from dbo.Kunde where Mobil LIKE '%" + BMobil + "%'");

            SqlCommand command = new SqlCommand(selectSql, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            Debug.Write(BMobil);

            if (reader.Read())
            {
                MessageBoxResult res = MessageBox.Show("Bruger fundet");
                KIDread = reader.GetInt16(0);
            }
            else
            {
                MessageBoxResult res = MessageBox.Show("Kunde ikke finde bruger");
                KIDread = 0;
            }

            reader.Close();
            connection.Close();
        }
        public ICommand TilføjBooking { get { RelayCommand _relay = new RelayCommand(TilfBooking); return _relay; } }
        private void TilfBooking()
        {
            OnPropertyChanged("Bbord");
            OnPropertyChanged("Bdato");



            // Find KID på kunde ved tjek Kunde

            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Daniel\Documents\GitHub\2.-cemester-projekt\CafeDiamondCemesterProjekt\DB\DB.mdf;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            string insertSql = "insert into dbo.Book (bord, dato, KID) values ('" +
               Bbord + "','" + Bdato + "','" + KIDread + "')";

            SqlCommand command = new SqlCommand(insertSql, connection);
            connection.Open();

            Debug.Write(Bbord);
            Debug.Write(KIDread);
            Debug.Write(Bdato);
           
                command.ExecuteNonQuery();
                MessageBoxResult res = MessageBox.Show("Booking Oprettet");
                Bstatus = "Booking Oprettet";
                OnPropertyChanged("Bstatus");
               
            
           
            connection.Close();
            KIDread = 0;
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
