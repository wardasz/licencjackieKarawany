using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caravans.model;

namespace Caravans.matma
{
    class miasto
    {
        private string id;
        private int populacja;
        private int gotowosc;       //100 to standard, powyzej 300 wypowiada wojnę
        private int zywnosc;        //-100 to kompletny brak, 0 standard, 100-2x tyle, 200-3x tyle...
        private int dobrobyt;       //uj wie

        public miasto(string ID)
        {
            TableTown tmp = Modele.ZnajdzMiasto(ID);
            id = ID;
            populacja = tmp.GetPopulation();
            gotowosc = tmp.GetMilitary();
            zywnosc = tmp.GetFood();
            dobrobyt = tmp.GetProsperity();
        }
        public miasto(TableTown t)
        {
            id = t.GetId();
            populacja = t.GetPopulation();
            gotowosc = t.GetMilitary();
            zywnosc = t.GetFood();
            dobrobyt = t.GetProsperity();
        }

        public int getPopulacje() { return populacja; }
        public int getZywnosc() { return zywnosc; }
        public int getGotowosc() { return gotowosc; }
        public int getDobrobyt() { return dobrobyt; }

        public void zmianaPopulacji()
        {
            int pop = populacja / 100;
            if (pop == 0) pop = 1;
            policzZywnosc(pop);
            int zpop;
            int zyw = zywnosc;
            if (zyw < 0)
            {
                zyw *= -1;
                zyw /= 4;
                zpop = populacja * zyw;
                zpop /= 200;
                populacja -= zpop;
            }
            if (zyw > 0 && zyw <= 100)
            {
                zyw /= 10;
                zpop = populacja * zyw;
                zpop /= 500;
                populacja += zpop;
            }
            if (zyw > 100 && zyw <= 1000)
            {
                zyw -= 100;
                zyw /= 40;
                zyw += 10;
                zpop = populacja * zyw;
                zpop /= 500;
                populacja += zpop;
            }
            if (zyw > 1000)
            {
                zpop = populacja * 33;
                zpop /= 500;
                populacja += zpop;
            }
            if (populacja < 50) populacja = 50;
        }

        public void policzZywnosc(int popu)
        {
            int zapJabl;
            int zapMies;
            int zapChleb;
            int ileJabl;
            int ileMies;
            int ileChleb;

            TableArtInTown towar1 = Modele.ZnajdzTowarWMiescie("TO02", id);
            towar towar2 = new towar(towar1);
            towar2.policzZapotrzebowanie();
            zapJabl = towar2.DajZapotrzebowanie();
            ileJabl = towar1.GetNumber();

            towar1 = Modele.ZnajdzTowarWMiescie("TO04", id);
            towar2 = new towar(towar1);
            towar2.policzZapotrzebowanie();
            zapMies = towar2.DajZapotrzebowanie();
            ileMies = towar1.GetNumber();

            towar1 = Modele.ZnajdzTowarWMiescie("TO05", id);
            towar2 = new towar(towar1);
            towar2.policzZapotrzebowanie();
            zapChleb = towar2.DajZapotrzebowanie();
            ileChleb = towar1.GetNumber();

            double zapSuma = zapMies + zapJabl + zapChleb;
            double ileSuma = ileMies + ileJabl + ileChleb;

            double roznica;            
            if (zapSuma == 0)
            {
                roznica = 1;
            }
            else
            {
                roznica = ileSuma / zapSuma;
            }

            roznica *= 100;
            roznica -= 100;
            int roz = (Int32)roznica;
            zywnosc = roz;
        }
    }
}
