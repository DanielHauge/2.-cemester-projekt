using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CafeDiamondCemesterProjekt.model
{

    public class RedigeringsHandler
    {
        public KundeHandler KH
        {
            get;
            set;
        }

        public Kalender Kalender
        {
            get;
            set;
        }

        public virtual Info InfoHandler
        {
            get;
            set;
        }

        public virtual void Login(object Brugernavn, object Adgangskode)
        {
            // Ikke implementeret
        }

    }

}