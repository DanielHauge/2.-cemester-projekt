using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeDiamondCemesterProjekt.DB;

namespace CafeDiamondCemesterProjekt.model
{
    public class Kalender
    {
        public List<Booking> Bookingliste
        {
            get;
            set;
        }

        public static void TilføjBooking(int Bord, DateTime Dato, int KID)
        {
            

            Booking booking = new Booking();
            booking.Bord = Bord;
            booking.KundeID = KID;
            booking.Dato = Dato;
        }

        public void UpdaterDatabase()
        {
            // ikke implementeret
        }

        public void LæsDatabase()
        {
            // Ikke implementeret
        }

    }
}
