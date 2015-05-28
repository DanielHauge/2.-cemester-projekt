using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDiamondCemesterProjekt.Model
{
    class Booking
    {

        public int bid {get; set;} 
        public int bord { get; set;}

        public string dato { get; set; }
        public int kid { get; set; }


        public Booking(int a, int b, string c, int d)
        {
            bid = a;
            bord = b;
            dato = c;
            kid = d;
        }

        public override string ToString()
        {
            return string.Format("KundeID: {0}, Bord: {1}, Dato: {2}", kid, bord, dato);
        }
    }
}
