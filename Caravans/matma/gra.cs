using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caravans.model;

namespace Caravans.matma
{
    class gra
    {
        Modele x = new Modele();

        public static void zapisz()
        {
            Modele.Save();

        }

        public static void wczytaj()
        {        
            Modele.Load();
        }

        public static void nowa()
        {
            Modele.Repop();
        }
    }
}
