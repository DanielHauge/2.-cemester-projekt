using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDiamondCemesterProjekt.Model
{
    class Kunde
    {
        public string navn {get; set;} 
        public string Email { get; set;}

        public int Saldo { get; set; }
        public int KundeID { get; set; }

        public string mobil { get; set; }
        public string pass { get; set; }


        public Kunde(int a, string b, string c, int d, string m, string p)
        {
            KundeID = a;
            navn = b;
            Email = c;
            Saldo = d;
            mobil = m;
            pass = p;

        }

        public override string ToString()
        {
            return string.Format("KundeID: {0}, navn: {1}, Email: {2}, Saldo: {3}, Mobil: {4}", KundeID, navn, Email, Saldo, mobil);
        }
    }
}
