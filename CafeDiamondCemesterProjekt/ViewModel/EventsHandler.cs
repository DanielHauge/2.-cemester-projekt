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
    class EventsHandler : INotifyPropertyChanged
    {
        /// <summary>
        /// Events
        /// </summary>

        public string Evtdato { get; set; }

        public string EvtOverskrift { get; set; }

        public string Evtbeskrivelse { get; set; }

        public bool EvtRedig = false;

        public int EvtRedigVar { get; set; }

        public string EvtListView { get; set; }

        public List<Event> EventListe { get; set; }

        public ICommand OpretEvent { get { RelayCommand _relay = new RelayCommand(OprEvent); return _relay; } }

        private void OprEvent()
        {
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='|DataDirectory|\DB\DB.mdf';Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            string insertSql;
            if (EvtRedig)
            {
                insertSql = "UPDATE dbo.Events SET Overskrift='" + EvtOverskrift + "', Dato='" + Evtdato + "', Beskrivelse='" + Evtbeskrivelse + "' WHERE Id='" + EvtRedigVar + "';";
            }
            else
            {
                insertSql = "insert into dbo.Events (Overskrift, Dato, Beskrivelse) values ('" +
                                      EvtOverskrift + "','" + Evtdato + "','" + Evtbeskrivelse + "')";

            }



            SqlCommand command = new SqlCommand(insertSql, connection);
            connection.Open();
            try
            {
                command.ExecuteNonQuery();

                if (EvtRedig)
                {
                    MessageBoxResult res = MessageBox.Show("Redigering er fuldført.");
                    EvtRedig = false;
                }
                else
                {
                    MessageBoxResult ss = MessageBox.Show("Event oprettet");
                }
            }
            catch (Exception)
            {
                MessageBoxResult res = MessageBox.Show("Fejl");

            }
            UpdEvent();
            //NEW BOOKING ADDED
            connection.Close();
        }

        public ICommand SletEvent { get { RelayCommand _relay = new RelayCommand(SletEvt); return _relay; } }

        private void SletEvt()
        {
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='|DataDirectory|\DB\DB.mdf';Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            FindEvtRedigVar();

            string insertSql = "DELETE FROM dbo.Events WHERE Id='" + EvtRedigVar + "'";

            Debug.Write(EvtRedigVar);



            SqlCommand command = new SqlCommand(insertSql, connection);
            connection.Open();

            try
            {
                command.ExecuteNonQuery();
                MessageBoxResult res = MessageBox.Show("Event Slettet");
                UpdEvent();
            }
            catch (Exception)
            {
                MessageBoxResult res = MessageBox.Show("Der skete en fejl");
            }
            //NEW BOOKING ADDED
            connection.Close();
        }

        private void FindEvtRedigVar()
        {
            try
            {
                string str = EvtListView;
                string result = "";
                for (int i = 0; i < str.Length; i++)
                {
                    if (Char.IsDigit(str[i]))
                        result += str[i];
                    else
                        break;
                }
                EvtRedigVar = Int16.Parse(result);
            }
            catch
            {
                MessageBoxResult res = MessageBox.Show("Der skal være mærkeret et Event");
            }
        }

        public ICommand RedigerEvent { get { RelayCommand _relay = new RelayCommand(RedigEvent); return _relay; } }

        private void RedigEvent()
        {
            EvtRedig = true;
            //Splitting shit
            FindEvtRedigVar();

            if (EvtRedigVar > 0)
            {
                Debug.WriteLine(EvtRedigVar);
                MessageBoxResult res = MessageBox.Show("Redigering kan foretages nu!\nSkriv venligst alle informationerne til redigering\nAlle felter vil blive redigeret ud fra hvad der står uanset om felterne er tomme");
            }
        }

        public ICommand UpdaterEventListe { get { RelayCommand _relay = new RelayCommand(UpdEvent); return _relay; } }

        private void UpdEvent()
        {
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='|DataDirectory|\DB\DB.mdf';Integrated Security=True";
            OnPropertyChanged("EventListe");
            SqlConnection connection = new SqlConnection(connectionString);
            string selectSql = ("select * from dbo.Events");

            SqlCommand command = new SqlCommand(selectSql, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<Event> tliste = new List<Event>();
            while (reader.Read())
            {

                int id = reader.GetInt16(0);
                string overskrift = reader.GetString(1);
                string dato = reader.GetString(2);
                string beskrivelse = reader.GetString(3);

                tliste.Add(new Event(id, overskrift, dato, beskrivelse));

                reader.Read();
            }

            reader.Close();
            connection.Close();
            EventListe = tliste;
            OnPropertyChanged("EventListe");
        }

        /// <summary>
        /// Vandpipe
        /// </summary>
        public string VPPris { get; set; }
        public string VPBeskrivelse { get; set; }
        public string VPNavn { get; set; }
        public int VPType = 1;
        public bool VPRedig = false;
        public string VPListView { get; set; }
        public int VPRedigVar { get; set; }
        public List<Produkt> VPListe { get; set; }

        public ICommand OpretVP { get { RelayCommand _relay = new RelayCommand(OprVP); return _relay; } }

        private void OprVP()
        {
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='|DataDirectory|\DB\DB.mdf';Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            string insertSql;
            if (VPRedig)
            {
                insertSql = "UPDATE dbo.Produkt SET Pris='" + VPPris + "', Beskrivelse='" + VPBeskrivelse + "', Pnavn='" + VPNavn + "', Type='"+VPType+"' WHERE Id='" + VPRedigVar + "';";
            }
            else
            {
                insertSql = "insert into dbo.Produkt (Pris, Beskrivelse, Pnavn, Type) values ('" +
                                      VPPris + "','" + VPBeskrivelse + "','" + VPNavn + "','"+VPType+"')";
            }



            SqlCommand command = new SqlCommand(insertSql, connection);
            connection.Open();
            try{
                command.ExecuteNonQuery();

                if (VPRedig)
                {
                    MessageBoxResult res = MessageBox.Show("Redigering er fuldført.");
                    VPRedig = false;
                }
                else
                {
                    MessageBoxResult ss = MessageBox.Show("Event oprettet");
                }
            }
            catch (Exception)
            {
                MessageBoxResult res = MessageBox.Show("Fejl");
            }

            //NEW BOOKING ADDED
            connection.Close();
        }

        public ICommand SletVandp { get { RelayCommand _relay = new RelayCommand(SletVP); return _relay; } }

        private void SletVP()
        {
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='|DataDirectory|\DB\DB.mdf';Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            FindVPRedigVar();

            string insertSql = "DELETE FROM dbo.Produkt WHERE Id='" + VPRedigVar + "'";

            Debug.Write(VPRedigVar);



            SqlCommand command = new SqlCommand(insertSql, connection);
            connection.Open();

            try
            {
                command.ExecuteNonQuery();
                MessageBoxResult res = MessageBox.Show("Event Slettet");
                UpdVP();
            }
            catch (Exception)
            {
                MessageBoxResult res = MessageBox.Show("Der skete en fejl");
            }
            //NEW BOOKING ADDED
            connection.Close();
        }

        private void FindVPRedigVar()
        {
            try
            {
                string str = VPListView;
                string result = "";
                for (int i = 0; i < str.Length; i++)
                {
                    if (Char.IsDigit(str[i]))
                        result += str[i];
                    else
                        break;
                }
                VPRedigVar = Int16.Parse(result);
            }
            catch
            {
                MessageBoxResult res = MessageBox.Show("Der skal være mærkeret et Event");
            }
        }

        public ICommand RedigerVP { get { RelayCommand _relay = new RelayCommand(RedigVP); return _relay; } }

        private void RedigVP()
        {
            VPRedig = true;
            //Splitting shit
            FindVPRedigVar();

            if (VPRedigVar > 0)
            {
                Debug.WriteLine(VPRedigVar);
                MessageBoxResult res = MessageBox.Show("Redigering kan foretages nu!\nSkriv venligst alle informationerne til redigering\nAlle felter vil blive redigeret ud fra hvad der står uanset om felterne er tomme");
            }
        }

        public ICommand UpdaterVPListe { get { RelayCommand _relay = new RelayCommand(UpdVP); return _relay; } }

        private void UpdVP()
        {
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='|DataDirectory|\DB\DB.mdf';Integrated Security=True";
            OnPropertyChanged("VPListe");
            SqlConnection connection = new SqlConnection(connectionString);
            string selectSql = ("select * from dbo.Produkt WHERE Type='"+VPType+"'");

            SqlCommand command = new SqlCommand(selectSql, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<Produkt> tliste = new List<Produkt>();
            while (reader.Read())
            {

                int id = reader.GetInt16(0);
                int Pris = reader.GetInt32(1);
                string Beskrivelse = reader.GetString(2);
                string Pnavn = reader.GetString(3);

                tliste.Add(new Produkt(id, Pris, Beskrivelse, Pnavn));

                reader.Read();
            }

            reader.Close();
            connection.Close();
            VPListe = tliste;
            OnPropertyChanged("VPListe");
        }

        /// <summary>
        /// Drikkevare
        /// </summary>
        public string DVPris { get; set; }
        public string DVBeskrivelse { get; set; }
        public string DVNavn { get; set; }
        public string DVListView { get; set; }
        public int DVType = 2;
        public bool DVRedig = false;
        public int DVRedigVar { get; set; }
        public List<Produkt> DVListe { get; set; }

        public ICommand OpretDV { get { RelayCommand _relay = new RelayCommand(OprDV); return _relay; } }

        private void OprDV()
        {
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='|DataDirectory|\DB\DB.mdf';Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            string insertSql;
            if (DVRedig)
            {
                insertSql = "UPDATE dbo.Produkt SET Pris='" + DVPris + "', Beskrivelse='" + DVBeskrivelse + "', Pnavn='" + DVNavn + "', Type='" + DVType + "' WHERE Id='" + DVRedigVar + "';";
            }
            else
            {
                insertSql = "insert into dbo.Produkt (Pris, Beskrivelse, Pnavn, Type) values ('" +
                                      DVPris + "','" + DVBeskrivelse + "','" + DVNavn + "','" + DVType + "')";
            }



            SqlCommand command = new SqlCommand(insertSql, connection);
            connection.Open();
            try
            {
                command.ExecuteNonQuery();

                if (DVRedig)
                {
                    MessageBoxResult res = MessageBox.Show("Redigering er fuldført.");
                    DVRedig = false;
                }
                else
                {
                    MessageBoxResult ss = MessageBox.Show("Event oprettet");
                }
            }
            catch (Exception)
            {
                MessageBoxResult res = MessageBox.Show("Fejl");
            }

            //NEW BOOKING ADDED
            connection.Close();
        }

        public ICommand SletDrikkeV { get { RelayCommand _relay = new RelayCommand(SletDV); return _relay; } }

        private void SletDV()
        {
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='|DataDirectory|\DB\DB.mdf';Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            FindDVRedigVar();

            string insertSql = "DELETE FROM dbo.Produkt WHERE Id='" + DVRedigVar + "'";

            Debug.Write(DVRedigVar);



            SqlCommand command = new SqlCommand(insertSql, connection);
            connection.Open();

            try
            {
                command.ExecuteNonQuery();
                MessageBoxResult res = MessageBox.Show("Event Slettet");
                UpdVP();
            }
            catch (Exception)
            {
                MessageBoxResult res = MessageBox.Show("Der skete en fejl");
            }
            //NEW BOOKING ADDED
            connection.Close();
        }

        private void FindDVRedigVar()
        {
            try
            {
                string str = DVListView;
                string result = "";
                for (int i = 0; i < str.Length; i++)
                {
                    if (Char.IsDigit(str[i]))
                        result += str[i];
                    else
                        break;
                }
                DVRedigVar = Int16.Parse(result);
            }
            catch
            {
                MessageBoxResult res = MessageBox.Show("Der skal være mærkeret et Event");
            }
        }

        public ICommand RedigerDV { get { RelayCommand _relay = new RelayCommand(RedigDV); return _relay; } }

        private void RedigDV()
        {
            DVRedig = true;
            //Splitting shit
            FindDVRedigVar();

            if (DVRedigVar > 0)
            {
                Debug.WriteLine(DVRedigVar);
                MessageBoxResult res = MessageBox.Show("Redigering kan foretages nu!\nSkriv venligst alle informationerne til redigering\nAlle felter vil blive redigeret ud fra hvad der står uanset om felterne er tomme");
            }
        }

        public ICommand UpdaterDVListe { get { RelayCommand _relay = new RelayCommand(UpdDV); return _relay; } }

        private void UpdDV()
        {
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='|DataDirectory|\DB\DB.mdf';Integrated Security=True";
            OnPropertyChanged("DVListe");
            SqlConnection connection = new SqlConnection(connectionString);
            string selectSql = ("select * from dbo.Produkt WHERE Type='" + DVType + "'");

            SqlCommand command = new SqlCommand(selectSql, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<Produkt> tliste = new List<Produkt>();
            while (reader.Read())
            {

                int id = reader.GetInt16(0);
                int Pris = reader.GetInt32(1);
                string Beskrivelse = reader.GetString(2);
                string Pnavn = reader.GetString(3);

                tliste.Add(new Produkt(id, Pris, Beskrivelse, Pnavn));

                reader.Read();
            }

            reader.Close();
            connection.Close();
            DVListe = tliste;
            OnPropertyChanged("DVListe");
        }




        /// <summary>
        /// snacks
        /// </summary>
        public string SPris { get; set; }
        public string SBeskrivelse { get; set; }
        public string SNavn { get; set; }
        public string SListView { get; set; }
        public int SType = 3;
        public bool SRedig = false;
        public int SRedigVar { get; set; }
        public List<Event> SListe { get; set; }

        public ICommand OpretS { get { RelayCommand _relay = new RelayCommand(OprS); return _relay; } }

        private void OprS()
        {
            //
        }

        public ICommand SletSnack { get { RelayCommand _relay = new RelayCommand(SletS); return _relay; } }

        private void SletS()
        {
            //
        }

        public ICommand RedigerS { get { RelayCommand _relay = new RelayCommand(RedigS); return _relay; } }

        private void RedigS()
        {
            //
        }

        public ICommand UpdaterSListe { get { RelayCommand _relay = new RelayCommand(UpdS); return _relay; } }

        private void UpdS()
        {
            //
        }


        /// <summary>
        /// Diverse
        /// </summary>

        public string DPris { get; set; }
        public string DBeskrivelse { get; set; }
        public string DNavn { get; set; }
        public int DType = 5;
        public string DListView { get; set; }
        public bool DRedig = false;
        public int DRedigVar { get; set; }
        public List<Event> DListe { get; set; }

        public ICommand OpretD { get { RelayCommand _relay = new RelayCommand(OprD); return _relay; } }

        private void OprD()
        {
            //
        }

        public ICommand SletDiv { get { RelayCommand _relay = new RelayCommand(SletD); return _relay; } }

        private void SletD()
        {
            //
        }

        public ICommand RedigerD { get { RelayCommand _relay = new RelayCommand(RedigD); return _relay; } }

        private void RedigD()
        {
            //
        }

        public ICommand UpdaterDListe { get { RelayCommand _relay = new RelayCommand(UpdD); return _relay; } }

        private void UpdD()
        {
            //
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
