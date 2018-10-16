using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caravans.model;

namespace Caravans.matma
{
    public class ceny
    {
        private string[] id = new string[11];
        private int[] cenaKup = new int[11];
        private int[] cenaSp = new int[11];
        private int[] ile = new int[11];

        public string getCenaKup(string idt)
        {
            for (int x = 0; x < 11; x++)
            {
                if (id[x] == idt) { return cenaKup[x].ToString(); }
            }
            return "";
        }
        public string getCenaSp(string idt)
        {
            for (int x = 0; x < 11; x++)
            {
                if (id[x] == idt) { return cenaSp[x].ToString(); }
            }
            return "";
        }
        public string getIle(string idt)
        {
            for (int x = 0; x < 11; x++)
            {
                if (id[x] == idt) { return ile[x].ToString(); }
            }
            return "";
        }

        public ceny(string a)
        {
            int pop = 0;
            string idm = "a";
            List<towar> towary = new List<towar>();

            foreach (TableTown t in Modele.tableTown)
            {
                string b = t.GetId();
                if (b == a)
                {
                    pop = t.GetPopulation();
                    idm = b;
                }
            }

            string idt;
            int ilosc = 0;
            int cena = 0;
            int prodD = 0;
            int prodM = 0;
            int zapD = 0;
            int zapM = 0;
            foreach (TableArtInTown t in Modele.tableArtInTown)
            {
                string x = t.GetId();
                if (x == idm)
                {
                    idt = t.GetIdArticle();
                    ilosc = t.GetNumber();
                    prodM = t.GetProduction();
                    zapM = t.GetRequisition();

                    foreach (TableArticle z in Modele.tableArticle)
                    {
                        x = z.GetId();
                        if (x == idt)
                        {
                            cena = z.GetPrice();
                            prodD = z.GetProduction();
                            zapD = z.GetRequisition();
                        }
                    }
                    towar tow = new towar(idt, ilosc, cena, prodD, prodM, zapD, zapM);
                    towary.Add(tow);
                }

            }

            int licznik = 0;

            foreach (towar tow in towary)
            {
                int pp = pop / 100;
                if (pp == 0) { pp = 1; }
                tow.policzCena(pp);
                id[licznik] = tow.dajId();
                cenaKup[licznik] = tow.dajCenaKup();
                cenaSp[licznik] = tow.dajCenaSprzed();
                ile[licznik] = tow.dajIlosc();
                licznik++;
            }
        }
    }

}
