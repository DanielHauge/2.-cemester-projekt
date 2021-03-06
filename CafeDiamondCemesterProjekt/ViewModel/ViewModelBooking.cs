﻿using System;
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
        public string LView { get; set; }
        public DateTime bookingViewDato { get; set; }
        public List<Booking> BookingTilView { get; set; }
        public List<Booking> BookingTilView2 { get; set; }
        public ICommand TjekKunde { get { RelayCommand _relay = new RelayCommand(Tjek); return _relay; } }
        private void Tjek()
        {

            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='|DataDirectory|\DB\DB.mdf';Integrated Security=True";

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
                string navn = reader.GetString(1);
                Bstatus = "Bruger er fundet og booking der laves vil blive koblet på denne bruger, brugere har KundeId'et: " + KIDread + " - Navn: " + navn + ".";
                OnPropertyChanged("Bstatus");
            }
            else
            {
                MessageBoxResult res = MessageBox.Show("Kunde ikke finde bruger");
                KIDread = 0;
                Bstatus = "Bruger er ikke fundet og booking der laves vil blive ikke blive koblet til en bruger";
                OnPropertyChanged("Bstatus");
            }

            reader.Close();
            connection.Close();
        }
        public ICommand SletBooking { get { RelayCommand _relay = new RelayCommand(Slet); return _relay; } }
        private void Slet()
        {
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='|DataDirectory|\DB\DB.mdf';Integrated Security=True";
            string result = "";
            try
            {
                string str = LView.Remove(0, 4);
                for (int i = 0; i < str.Length; i++) // loop over the complete input
                {
                    if (Char.IsDigit(str[i])) //check if the current char is digit
                        result += str[i];
                    else
                        break; //Stop the loop after the first character
                }
                Debug.WriteLine(LView);
                Debug.WriteLine(result);
            }
            catch
            {
                MessageBoxResult res = MessageBox.Show("Der skal være markeret en booking for at kunne slette");
            }
            
            

            SqlConnection connection = new SqlConnection(connectionString);

            string insertSql = "DELETE FROM dbo.Book WHERE BID='" + result + "'";




            SqlCommand command = new SqlCommand(insertSql, connection);
            connection.Open();

            try
            {
                command.ExecuteNonQuery();
                Bstatus = "Booking slettet";
                MessageBoxResult ressss = MessageBox.Show("Booking Slettet");
                OnPropertyChanged("status");
                FyldListe();
            }
            catch (Exception)
            {
                MessageBoxResult res = MessageBox.Show("Der skete en fejl");
            }
            //NEW BOOKING ADDED
            connection.Close();
        }
        public ICommand TilføjBooking { get { RelayCommand _relay = new RelayCommand(TilfBooking); return _relay; } }
        private void TilfBooking()
        {
            // Find KID på kunde ved tjek Kunde

            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='|DataDirectory|\DB\DB.mdf';Integrated Security=True";

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
        public ICommand FyldListen { get { RelayCommand _relay = new RelayCommand(FyldListe); return _relay; } }
        public void FyldListe()
        {
            Debug.Write("TRYK");
            OnPropertyChanged("BookingTilView");
            OnPropertyChanged("BookingTilView2");
            DagsListe();
            SpecifikDag();
            OnPropertyChanged("BookingTilView");
            OnPropertyChanged("BookingTilView2");
        }
        private void SpecifikDag()
        {
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='|DataDirectory|\DB\DB.mdf';Integrated Security=True";
            OnPropertyChanged("bookingViewDato");
            SqlConnection connection = new SqlConnection(connectionString);
            string Specdato = bookingViewDato.ToShortDateString();
            Debug.Write(Specdato);
            string selectSql = ("select BID, bord, dato, KID from dbo.Book where dato LIKE '" + Specdato + "%'");

            SqlCommand command = new SqlCommand(selectSql, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<Booking> BookingList = new List<Booking>();
            while (reader.Read())
            {

                int BID = reader.GetInt16(0);
                int bord = reader.GetInt32(1);
                string dato = reader.GetString(2);
                int KID = reader.GetInt16(3);

                BookingList.Add(new Booking(BID, bord, dato, KID));

                reader.Read();
            }
            
            reader.Close();
            connection.Close();
            BookingTilView2 = BookingList;
            OnPropertyChanged("BookingTilView2");
        }
        private void DagsListe()
        {
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='|DataDirectory|\DB\DB.mdf';Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);
            string idagdato = DateTime.Today.ToShortDateString();
            string selectSql = ("select BID, bord, dato, KID from dbo.Book where dato LIKE '" + idagdato + "%'");

            SqlCommand command = new SqlCommand(selectSql, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<Booking> BookingList = new List<Booking>();
            while (reader.Read())
            {

                int BID = reader.GetInt16(0);
                int bord = reader.GetInt32(1);
                string dato = reader.GetString(2);
                int KID = reader.GetInt16(3);

                BookingList.Add(new Booking(BID, bord, dato, KID));

                reader.Read();
            }
            
            reader.Close();
            connection.Close();
            BookingTilView = BookingList;
            OnPropertyChanged("BookingTilView");
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