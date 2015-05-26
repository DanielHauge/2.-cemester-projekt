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
        public DateTime tid { get; set; }
        public int bord { get; set; }
        public int KID { get; set; }



        public ICommand TilføjBooking { get { RelayCommand _relay = new RelayCommand(TilfBooking); return _relay; } }
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
