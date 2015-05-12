using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            DB.DBEntity Ent = new DBEntity();

            Booking B = new Booking();
            B.Bord = Bord;
            B.Dato = Dato;
            B.KundeID = KID;

            //Ent.Bookings.Add(B);
            //Ent.SaveChanges();


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
