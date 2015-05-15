using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace CafeDiamondCemesterProjekt.model
{
    public class KundeHandler
    {
        public List<DB.Kunde> KundeListe
        {
            get;
            set;
        }

        public RedigeringsHandler RedigeringsHandler1
        {
            get;
            set;
        }

        public static void TilføjKunde(string Navn, string Email, int Saldo)
        {
            DB.DBEntityKunde entK = new DB.DBEntityKunde();

            DB.Kunde K = new DB.Kunde();
            K.Email = Email;
            K.Navn = Navn;
            K.Saldo = Saldo;

            entK.Kundes.Add(K);
            entK.SaveChanges();
        }

        public void UpdaterDatabase()
        {
            // Ikke implementeret
        }

        public void Læsdatabase()
        {
            // Ikke implementeret
        }

    }
}
