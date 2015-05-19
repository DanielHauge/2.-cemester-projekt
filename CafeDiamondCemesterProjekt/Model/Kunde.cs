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

        public string Saldo { get; set; }
        public int KundeID { get; set; }


        public Kunde(int a, string b, string c, string d)
        {
            KundeID = a;
            navn = b;
            Email = c;
            Saldo = d;

        }

        public override string ToString()
        {
            return string.Format("KundeID: {0}, navn: {1}, Email: {2}, Saldo {3}", KundeID, navn, Email, Saldo);
        }
    }
}
