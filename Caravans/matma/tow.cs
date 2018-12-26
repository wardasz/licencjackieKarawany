using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caravans.model;

namespace Caravans.matma
{
    class tow
    {
        private string IDtowar;
        private string IDmiasto;

        private int ilosc;                  //ilość towaru w mieście
        private int cenaDef;                //podstawowa cena towaru
        private int produkcjaDef;           //podstawowa produkcja towaru
        private int produkcjaMod;           //miejski modyfikator produkcji towaru
        private int zapotrzebowanieDef;     //podstawowe zapotrzebowanie na towar
        private int zapotrzebowanieMod;     //miejski modyfikator zapotrzebowania na towar
        private int populacja;

        private int cenaKup;
        private int cenaSp;
        private int prodAkt;
        private int zapoAkt;

        public tow(TableArtInTown t)
            : this(t.GetIdArticle(), t.GetId())
        {
        }

        public tow(string idt, string idm)
        {
            IDmiasto = idm;
            IDtowar = idt;

            TableArticle towar = Modele.ZnajdzTowar(idt);        
            cenaDef = towar.GetPrice();
            produkcjaDef = towar.GetProduction();
            zapotrzebowanieDef = towar.GetRequisition();


            TableArtInTown towarW = Modele.ZnajdzTowarWMiescie(idt, idm);
            ilosc = towarW.GetNumber();
            produkcjaMod = towarW.GetProduction();
            zapotrzebowanieMod = towarW.GetRequisition();

            TableTown miasto = Modele.ZnajdzMiasto(idm);
            populacja = miasto.GetPopulation();

            cenaKup = 0;
            cenaDef = 0;
            prodAkt = 0;
            zapoAkt = 0;
        }

        public int DajCeneKup()
        {
            return cenaKup;
        }

        public int DajCeneSp()
        {
            return cenaSp;
        }

        public void policzZapotrzebowanie()
        {
            double x;
            if (zapotrzebowanieDef == 0)
            {
                if (zapotrzebowanieMod == 0)
                {
                    x = 0;
                }
                else
                {
                    x = zapotrzebowanieMod / 10;
                }
            }
            else
            {
                if (zapotrzebowanieMod == 0)
                {
                    x = zapotrzebowanieDef;
                }
                else
                {
                    x = zapotrzebowanieMod + 100;
                    x = x / 100;
                    x = x * zapotrzebowanieDef;
                }
            }
            int zap = Convert.ToInt32(x);
            int pop = populacja / 100;
            zapoAkt = zap * pop;
        }

        public void policzProdukcje()
        {
            double x;
            if (produkcjaDef == 0)
            {
                if (produkcjaMod == 0)
                {
                    x = 0;
                }
                else
                {
                    x = produkcjaMod / 10;
                }
            }
            else
            {
                if (produkcjaMod == 0)
                {
                    x = produkcjaDef;
                }
                else
                {
                    x = produkcjaMod + 100;
                    x = x / 100;
                    x = x * produkcjaDef;
                }
            }
            int prod = Convert.ToInt32(x);
            int pop = populacja / 100;
            prodAkt = prod * pop;
        }

        public void zmianaIlosci()
        {
            policzZapotrzebowanie();
            policzProdukcje();
            int wynik = 0;
            int niedobor = 0;

            ilosc -= zapoAkt;
            if (ilosc < 0)
            {
                wynik--;
                niedobor = ilosc * -1;
                ilosc = 0;
            }

            if (niedobor == 0)
            {
                ilosc += prodAkt;
            }
            else
            {
                ilosc += prodAkt;
                niedobor /= 2;
                ilosc -= niedobor;
                if (ilosc < 0)
                {
                    ilosc = 0;
                    wynik--;
                }
            }

            double roznica;
            if (zapoAkt == 0)
            {
                roznica = 0;
            }
            else
            {
                roznica = ilosc / zapoAkt;
            }
            if (roznica >= 5) { wynik++; }

            foreach (TableArtInTown t in Modele.tableArtInTown)
            {
                if (t.GetIdArticle() == IDtowar && t.GetId() == IDmiasto)
                {
                    t.SetNumber(ilosc);
                }
            }

            foreach (TableTown t in Modele.tableTown)
            {
                if (t.GetId() == IDmiasto)
                {
                    int prosp = t.GetProsperity();
                    prosp = prosp + wynik;
                    t.SetProsperity(prosp);
                }
            }
        }

        public void policzCena()
        {
            policzZapotrzebowanie();
            policzProdukcje();

            double roznica;
            if (zapoAkt == 0)
            {
                roznica = 1;
            }
            else
            {
                roznica = ilosc / zapoAkt;
            }

            if (roznica < 0.18)
            {
                cenaKup = -1;
                cenaSp = 8 * cenaDef;
                if (cenaKup == cenaSp) { cenaKup++; }
                return;
            }
            if (roznica < 0.25)
            {
                double x = roznica - 0.18;
                double y = x / 0.07;
                double z = 3 * y;
                cenaKup = -1;
                cenaSp = (int)((8 - z) * cenaDef);
                if (cenaKup == cenaSp) { cenaKup++; }
                return;
            }
            if (roznica < 0.5)
            {
                double x = roznica - 0.25;
                double y = x / 0.25;
                double z = 3 * y;
                cenaSp = (int)((5 - z) * cenaDef);
                cenaKup = (int)((5 - z) * cenaDef * 1.1);
                if (cenaKup == cenaSp) { cenaKup++; }
                return;
            }
            if (roznica < 0.9)
            {
                double x = roznica - 0.5;
                double y = x / 0.4;
                double z = 1 * y;
                cenaSp = (int)((2 - z) * cenaDef);
                cenaKup = (int)((2 - z) * cenaDef * 1.1);
                if (cenaKup == cenaSp) { cenaKup++; }
                return;
            }
            if (roznica < 1.1)
            {
                cenaSp = (int)(cenaDef);
                cenaKup = (int)(cenaDef * 1.1);
                if (cenaKup == cenaSp) { cenaKup++; }
                return;
            }
            if (roznica < 2)
            {
                double x = roznica - 1.1;
                double y = x / 0.9;
                double z = 0.3 * y;
                cenaSp = (int)((1 - z) * cenaDef);
                cenaKup = (int)((1 - z) * cenaDef * 1.1);
                if (cenaKup == cenaSp) { cenaKup++; }
                return;
            }
            if (roznica < 10)
            {
                double x = roznica - 2;
                double y = x / 8;
                double z = 0.5 * y;
                cenaSp = (int)((0.7 - z) * cenaDef);
                cenaKup = (int)((0.7 - z) * cenaDef * 1.1);
                if (cenaKup == cenaSp) { cenaKup++; }
                return;
            }
            cenaSp = (int)(0.2 * cenaDef);
            cenaKup = (int)(0.2 * cenaDef * 1.1);
            if (cenaKup == cenaSp) { cenaKup++; }

        }
    }
}
