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

        public List<Event> EventListe { get; set; }

        public ICommand OpretEvent { get { RelayCommand _relay = new RelayCommand(OprEvent); return _relay; } }

        private void OprEvent()
        {
            //
        }

        public ICommand SletEvent { get { RelayCommand _relay = new RelayCommand(SletEvt); return _relay; } }

        private void SletEvt()
        {
            //
        }

        public ICommand RedigerEvent { get { RelayCommand _relay = new RelayCommand(RedigEvent); return _relay; } }

        private void RedigEvent()
        {
            //
        }

        public ICommand UpdaterEventListe { get { RelayCommand _relay = new RelayCommand(UpdEvent); return _relay; } }

        private void UpdEvent()
        {
            //
        }

        /// <summary>
        /// Vandpipe
        /// </summary>
        public string VPPris { get; set; }
        public string VPBeskrivelse { get; set; }
        public string VPNavn { get; set; }
        public string VPType { get; set; }

        public List<Produkt> VPListe { get; set; }

        public ICommand OpretVP { get { RelayCommand _relay = new RelayCommand(OprVP); return _relay; } }

        private void OprVP()
        {
            //
        }

        public ICommand SletVandp { get { RelayCommand _relay = new RelayCommand(SletVP); return _relay; } }

        private void SletVP()
        {
            //
        }

        public ICommand RedigerVP { get { RelayCommand _relay = new RelayCommand(RedigVP); return _relay; } }

        private void RedigVP()
        {
            //
        }

        public ICommand UpdaterVPListe { get { RelayCommand _relay = new RelayCommand(UpdVP); return _relay; } }

        private void UpdVP()
        {
            //
        }

        /// <summary>
        /// Drikkevare
        /// </summary>
        public string DVPris { get; set; }
        public string DVBeskrivelse { get; set; }
        public string DVNavn { get; set; }
        public string DVType { get; set; }

        public List<Produkt> DVListe { get; set; }

        public ICommand OpretDV { get { RelayCommand _relay = new RelayCommand(OprDV); return _relay; } }

        private void OprDV()
        {
            //
        }

        public ICommand SletDrikkeV { get { RelayCommand _relay = new RelayCommand(SletDV); return _relay; } }

        private void SletDV()
        {
            //
        }

        public ICommand RedigerDV { get { RelayCommand _relay = new RelayCommand(RedigDV); return _relay; } }

        private void RedigDV()
        {
            //
        }

        public ICommand UpdaterDVListe { get { RelayCommand _relay = new RelayCommand(UpdDV); return _relay; } }

        private void UpdDV()
        {
            //
        }




        /// <summary>
        /// snacks
        /// </summary>
        public string SPris { get; set; }
        public string SBeskrivelse { get; set; }
        public string SNavn { get; set; }
        public string SType { get; set; }

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
        public string DType { get; set; }

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
