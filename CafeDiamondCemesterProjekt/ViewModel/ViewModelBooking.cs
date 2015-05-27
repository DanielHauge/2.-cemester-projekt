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

        public string bookingViewDato { get; set; }

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
                KIDread = reader.GetInt16(0);
            }
            else
            {
                MessageBoxResult res = MessageBox.Show("Kunde ikke finde bruger");
            }

            reader.Close();
            connection.Close();
        }
        public ICommand TilføjBooking { get { RelayCommand _relay = new RelayCommand(TilfBooking); return _relay; } }
        private void TilfBooking()
        {
            OnPropertyChanged("tid");
            OnPropertyChanged("bord");
            OnPropertyChanged("KID");



            // Find KID på kunde ved tjek Kunde

            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='|DataDirectory|\DB.mdf';Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            string insertSql = "insert into dbo.Booking (Bord, KundeID, Dato) values ('" +
               Bbord + "','" + KIDread + "','" + Bdato + "')";

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
