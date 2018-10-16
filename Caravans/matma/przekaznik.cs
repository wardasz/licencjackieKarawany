using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caravans.model;

namespace Caravans.matma
{
    public class przekaznik
    {
        public static List<string> dajKarawany()
        {
            List<string> lista = new List<string>();
            foreach(TableCaravan kar in Modele.tableCaravan)
            {
                lista.Add(kar.GetId());
            }

            return lista;
        }

        public static string DajCzasS()
        {
            int x = Modele.getTime();
            string y = x.ToString();
            return y;
        }

        public static int DajCzas()
        {
            int x = Modele.getTime();
            return x;
        }

        public static string DajKaseS()
        {
            int x = Modele.getGold();
            string y = x.ToString();
            return y;
        }

        public static int DajKase()
        {
            int x = Modele.getGold();
            return x;
        }

        public static string IleTowaru(string idk, string idt)
        {
            string wynik = "";
            foreach (TableArtInCaravan xyz in Modele.tableArtInCaravan)
            {
                string id1 = xyz.GetId();
                string id2 = xyz.GetIdArticle();
                if (id1 == idk && id2 == idt)
                {
                    int zmienna = xyz.GetNumber();
                    if (zmienna == 0)
                    {
                        wynik = "0";
                    }
                    else
                    {
                        wynik = zmienna.ToString();
                    }
                }
            }
            return wynik;
        }

        //oddaje stringa do wydrukowania w oknie karawany
        public static string lokalizuj(string idk)
        {
            string roboczy;
            string nazwa = "";
            int czas = 0;
            string idl = "";
            foreach (TableCaravan kar in Modele.tableCaravan)
            {
                roboczy = kar.GetId();
                if (roboczy == idk)
                {
                    idl = kar.GetIdLoc();
                    czas = kar.GetDuration();
                }
            }
            foreach (TableTown miasto in Modele.tableTown)
            {
                roboczy = miasto.GetIdLoc();
                if (roboczy == idl)
                {
                    nazwa = miasto.GetName();
                }
            }

            if (czas == 0)
            {
                return nazwa;
            }
            else
            {
                string wynik = "W drodze do " + nazwa + " pozostało " + czas + " tur";
                return wynik;

            }
        }

        //oddaje id miasta
        public static string lok(string idk)
        {
            string roboczy;
            string wynik="";
            string idl = "";
            foreach (TableCaravan kar in Modele.tableCaravan)
            {
                roboczy = kar.GetId();
                if (roboczy == idk)
                {
                    idl = kar.GetIdLoc();
                }
            }
            foreach (TableTown miasto in Modele.tableTown)
            {
                roboczy = miasto.GetIdLoc();
                if (roboczy == idl)
                {
                    wynik = miasto.GetId();
                }
            }

            return wynik;
        }

        public static string dajNazwe(string id)
        {
            string wynik = "";
            foreach (TableTown miasto in Modele.tableTown)
            {
                if (miasto.GetId() == id) wynik = miasto.GetName();
            }
            return wynik;
        }

        public static int CzasPodrozy(string id)
        {
            int wynik = 0;
            foreach (TableCaravan kar in Modele.tableCaravan)
            {
                if ( kar.GetId()== id)
                {
                    wynik = kar.GetDuration();
                }
            }

            return wynik;
        } 

        public static int dajWozy(string id)
        {
            foreach (TableCaravan karawana in Modele.tableCaravan)
            {
                if (karawana.GetId() == id)
                {
                    return karawana.GetWagons();
                }
            }
            return 0;
        }

        public static int dajOchrone(string id)
        {
            foreach (TableCaravan karawana in Modele.tableCaravan)
            {
                if (karawana.GetId() == id)
                {
                    return karawana.GetGuard();
                }
            }
            return 0;
        }

        public static int dajPomagierow(string id)
        {
            foreach (TableCaravan karawana in Modele.tableCaravan)
            {
                if (karawana.GetId() == id)
                {
                    return karawana.GetMinions();
                }
            }
            return 0;
        }

        public static int PoliczObciozenie(string id)
        {
            int wynik=0;
            foreach(TableArtInCaravan towar in Modele.tableArtInCaravan)
            {
                if (towar.GetId() == id)
                {
                    wynik += towar.GetNumber();
                }
            }
            return wynik;
        }

        public static int PoliczPojemnosc(string id)
        {
            int wynik=200;
            foreach (TableCaravan karawana in Modele.tableCaravan)
            {
                if (karawana.GetId() == id)
                {
                    wynik = 200 * karawana.GetWagons();
                }
            }
            return wynik;
        }

        public static int DajPopulacje(string id)
        {
            int wynik = 0;
            foreach(TableTown miasto in Modele.tableTown)
            {
                if (miasto.GetId() == id) wynik = miasto.GetPopulation();
            }
            return wynik;
        }

        public static string dajInfo(string idt, string idm, int populacja)
        {
            int pop = populacja / 100;
            if (pop == 0) { pop = 1; }
            string wynik = "";
            int ilosc=0;
            int cenaDef=0;                
            int produkcjaDef=0;          
            int produkcjaMod=0;           
            int zapotrzebowanieDef=0;   
            int zapotrzebowanieMod = 0;

            foreach(TableArticle towar in Modele.tableArticle)
            {
                if (towar.GetId() == idt)
                {
                    cenaDef = towar.GetPrice();
                    produkcjaDef = towar.GetProduction();
                    zapotrzebowanieDef = towar.GetRequisition();
                }
            }

            foreach(TableArtInTown towar in Modele.tableArtInTown)
            {
                if(towar.GetId()==idm && towar.GetIdArticle() == idt)
                {
                    ilosc = towar.GetNumber();
                    zapotrzebowanieMod = towar.GetRequisition();
                    produkcjaMod = towar.GetProduction();
                }
            }

            towar tow = new towar(idt, ilosc, cenaDef, produkcjaDef, produkcjaMod, zapotrzebowanieDef, zapotrzebowanieMod);
            int prod = tow.policzProdukcje(pop);
            int zap = tow.policzZapotrzebowanie(pop);
            int x;
            if (prod == zap) wynik = "Produkcja idealnie pokrywa zapotrzebowanie.";
            if (prod > zap)
            {
                wynik = "Produkcja jest większa niż zapotrzebowanie.";
                x = zap * 2;
                if (prod > x) wynik = "Produkcja jest ponad dwa razy większa niż zapotrzebowanie.";
                x = zap * 3;
                if (prod > x) wynik = "Produkcja jest ponad trzy razy większa niż zapotrzebowanie.";
                x = zap * 4;
                if (prod > x) wynik = "Produkcja jest ponad cztery razy większa niż zapotrzebowanie.";
                x = zap * 5;
                if (prod > x) wynik = "Produkcja jest ponad pięć razy większa niż zapotrzebowanie.";
            }
            if (prod < zap)
            {
                x = prod - zap;
                x = ilosc / x;
                wynik = "Produkcja jest mniejsza niż zapotrzebowanie, zapasy wyczerpią cię w ciągu " + x + " tygodni.";
            }

            return wynik;
        }

        public static string dajWojo(string id)
        {
            int wojo=0;
            foreach(TableTown miasto in Modele.tableTown)
            {
                if (miasto.GetId() == id) wojo = miasto.GetMilitary();
            }
            if (wojo < 100) return "fatalna";
            if (wojo > 300) return "wojenna";
            if (wojo > 200) return "doskonała";
            return "standardowa";
        }

        public static string dajZarcie(string id)
        {
            int zarcie=0;
            foreach (TableTown miasto in Modele.tableTown)
            {
                if (miasto.GetId() == id) zarcie = miasto.GetFood();
            }
            if (zarcie < -25) return "głód";
            if (zarcie < 0) return "niedobór";
            if (zarcie > 100) return "szalony nadmiar";
            if (zarcie > 50) return "nadmiar";
            if (zarcie > 20) return "lekka nadwyżka";
            return "wystarczające";
        }

        public static string dajBogactwo(string id)
        {
            int hajs=0;
            foreach (TableTown miasto in Modele.tableTown)
            {
                if (miasto.GetId() == id) hajs = miasto.GetProsperity();
            }
            if (hajs < -100) return "bida z nędzą";
            if (hajs < -50) return "bieda";
            if (hajs < -0) return "ubióstwo";
            if (hajs > 200) return "burżujstwo";
            if (hajs > 100) return "bogactwo";
            if (hajs > 50) return "nadmiar zbytków";
            return "przeciętna";
        }

        public static string dajStany(string id)
        {
            string wynik = "";
            Boolean flaga = false;
            string ids;
            foreach(TableTownState stan in Modele.tableTownState)
            {
                if (stan.GetId() == id)
                {
                    ids = stan.GetIdState();
                    foreach(TableState stan2 in Modele.tableState)
                    {
                        if (stan2.GetId() == ids)
                        {
                            if (flaga == true) wynik = wynik + ", ";
                            wynik = wynik + stan2.GetName() + "(" + stan.GetDuration() + ")";
                            flaga = true;
                        }
                    }
                }
            }
            return wynik;
        }

        public static Boolean czyMoznaPodrozowac(string id)
        {
            int wozy = 0;
            int ochrona = 0;
            int pomoc = 0;
            int jest;
            int trzeba;

            foreach (TableCaravan kar in Modele.tableCaravan)
            {
                if (kar.GetId() == id)
                {
                    wozy = kar.GetWagons();
                    pomoc = kar.GetMinions();
                    ochrona = kar.GetGuard();
                }
            }

            jest = ochrona + pomoc + 1;
            trzeba = wozy * 2;
            if (jest >= trzeba)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
