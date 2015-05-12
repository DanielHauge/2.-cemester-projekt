using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CafeDiamondCemesterProjekt.model
{
    public class Kalender
    {
        public List<Booking> Bookingliste
        {
            get;
            set;
        }

        public void TilføjBooking(int Bord, DateTime Dato, int KID)
        {
            DB.DBEntities Ent = new DB.DBEntities();

            Booking B = new Booking();
            B.Bord = Bord;
            B.Dato = Dato;
            B.KundeID = KID;

            


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
