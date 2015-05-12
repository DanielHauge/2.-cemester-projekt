using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeDiamondCemesterProjekt.DB;

namespace CafeDiamondCemesterProjekt.model{

    public class Kalender
    {
        public List<Booking> Bookingliste
        {
            get;
            set;
        }

        public void TilføjBooking(int Bord, DateTime Dato, string KID)
        {
            DB.DBEntityBooking ent = new DB.DBEntityBooking();

            DB.Booking booking = new DB.Booking();
            booking.Bord = Bord;
            booking.KundeID = KID;
            booking.Dato = Dato;

            ent.Bookings.Add(booking);
            ent.SaveChanges();
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
