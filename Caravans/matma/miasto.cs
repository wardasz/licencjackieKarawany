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
        List<towar> towary = new List<towar>();

        public miasto(string s, int a, int b, int c, int d)
        {
            id = s;
            populacja = a;
            gotowosc = b;
            zywnosc = c;
            dobrobyt = d;
        }

        public int getPopulacje() { return populacja; }
        public int getZywnosc() { return zywnosc; }
        public int getGotowosc() { return gotowosc; }
        public int getDobrobyt() { return dobrobyt; }

        public void wypelnij(string id)
        {
            foreach (TableArtInTown t in Modele.tableArtInTown)
            {
                string x = t.GetId();
                if (x == id)
                {
                    string idt = t.GetIdArticle();
                    int ilosc = t.GetNumber();
                    int prodM = t.GetProduction();
                    int zapM = t.GetRequisition();

                    foreach (TableArticle z in Modele.tableArticle)
                    {
                        x = z.GetId();
                        if (x == idt)
                        {
                            int cena = z.GetPrice();
                            int prodD = z.GetProduction();
                            int zapD = z.GetRequisition();
                            towar tow = new towar(idt, ilosc, cena, prodD, prodM, zapD, zapM);
                            towary.Add(tow);
                        }
                    }
                }
            }
        }

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

        public void policzTowary()
        {
            foreach (towar x in towary)
            {
                int pop = populacja / 100;
                if (pop == 0) { pop = 1; }
                int zmiana = x.zmianaIlosci(pop);
                dobrobyt = +zmiana;
            }
        }

        public void dajDane()
        {
            foreach (towar x in towary)
            {
                x.wyprowadzDane(id);
            }
        }

        public void policzZywnosc(int popu)
        {
            int zapJabl=0;
            int zapMies=0;
            int zapChleb=0;
            int ileJabl=0;
            int ileMies=0;
            int ileChleb=0;
            String idek;

            foreach(towar tow in towary)
            {
                idek = tow.dajId();
                switch (idek)
                {
                    case "TO02": //jabłka
                        zapJabl = tow.policzZapotrzebowanie(popu);
                        ileJabl = tow.dajIlosc();
                        break;
                    case "TO05": //chleb
                        zapChleb = tow.policzZapotrzebowanie(popu);
                        ileChleb = tow.dajIlosc();
                        break;
                    case "TO04": //mieso
                        zapMies = tow.policzZapotrzebowanie(popu);
                        ileMies = tow.dajIlosc();
                        break;
                    default:
                        break;
                }
            }

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
