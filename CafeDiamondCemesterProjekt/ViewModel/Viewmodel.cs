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

namespace CafeDiamondCemesterProjekt.ViewModel
{
    class Viewmodel
    {

        public DateTime tid { get; set; }
        public int bord { get; set; }
        public int KID { get; set; }



        public ICommand TilføjBooking { get { RelayCommand _relay = new RelayCommand(TilfBooking); return _relay; } }

        private void TilfBooking()
        {
            model.Kalender.TilføjBooking(bord, tid, KID);
        }
    }
}
