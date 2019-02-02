using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caravans.model;
using Caravans;

namespace Caravans.matma
{
    class czas
    {
        public void tura()
        {
            int czas = Modele.getTime();
            czas++;
            Modele.setTime(czas);
            foreach (TableCaravan kar in Modele.tableCaravan)//odejmujemy jedna ture od karawan
            {
                kar.ChangeDuration(); // tu juz jest kontrola czy jest zero tur
                if (kar.GetDuration() != 0)
                {
                    Random rng = new Random();
                    int random = rng.Next(100);
                    if (random == 1) napad(kar.GetId());
                }
            }
            dzien();
            wyplata();
            if (czas % 7 == 0) { tydzien(); }
        }

        public void napad(string id)
        {
            Random rng = new Random();
            int ochrona = 0;
            int slozba = 0;
            foreach (TableCaravan kar in Modele.tableCaravan)
            {
                if (kar.GetId() == id)
                {
                    ochrona = kar.GetGuard();
                    slozba = kar.GetMinions();
                    kar.BackDuration();
                }
            }
            int sila = 15 + (10 * ochrona) + (2 * slozba);

            int ilu = rng.Next(2, 12);
            int wrogSila = 0;
            for (int x = 0; x <= ilu; x++)
            {
                int moc = rng.Next(4, 8);
                wrogSila = wrogSila + moc;
            }
            string numer = id.Remove(0, 2);
            string wynik = "Karawana nr. " + numer + " została napadnięta";
            if (sila > wrogSila * 2)
            {
                wynik = wynik + ", aczkolwiek napastników zdołano przegonić bez większych strat.";
                GamesWindow.napadliNas(wynik);
                return;
            }
            if (sila > wrogSila)
            {
                wynik = wynik + ", aczkolwiek udało się przegonić napastników. Nie obyło się jednak bez strat w ludziach.";
                int straty = rng.Next(3);
                for (int x = 0; x <= straty; x++)
                {
                    foreach (TableCaravan kar in Modele.tableCaravan)
                    {
                        if (kar.GetId() == id)
                        {
                            if (kar.GetGuard() > 0)
                            {
                                int z = kar.GetGuard();
                                z--;
                                kar.SetGuard(z);
                            }
                            else
                            {
                                int z = kar.GetMinions();
                                z--;
                                if (z < 0) z = 0;
                                kar.SetMinions(z);
                            }
                        }
                    }
                }
                GamesWindow.napadliNas(wynik);
                return;
            }
            if (2 * sila > wrogSila)
            {
                wynik = wynik + " i choć udało się co nieco uratować, to większość obsługi i towaru została utracona.";
                foreach (TableArtInCaravan art in Modele.tableArtInCaravan)
                {
                    if (art.GetId() == id)
                    {
                        int ilosc = art.GetNumber();
                        double zmienna = ilosc;
                        zmienna = zmienna * 0.4;
                        ilosc = (int)zmienna;
                        art.SetNumber(ilosc);
                    }
                }
                foreach (TableCaravan kar in Modele.tableCaravan)
                {
                    if (kar.GetId() == id)
                    {
                        kar.SetMinions(1);
                        kar.SetWagons(1);
                        kar.SetGuard(0);
                        Boolean czyOk = false;
                        while (czyOk == false)
                        {
                            int pojemnosc = przekaznik.PoliczPojemnosc(id);
                            int obciozenie = przekaznik.PoliczObciozenie(id);
                            if (pojemnosc < obciozenie)
                            {
                                int y = kar.GetWagons();
                                y++;
                                kar.SetWagons(y);
                            }
                            else
                            {
                                czyOk = true;
                            }
                        }
                    }
                }
                GamesWindow.napadliNas(wynik);
                return;
            }
            wynik = wynik + " i niemalże wszystko przepadło.";
            foreach (TableArtInCaravan art in Modele.tableArtInCaravan)
            {
                if (art.GetId() == id)
                {
                    art.SetNumber(0);
                }
            }
            foreach (TableCaravan kar in Modele.tableCaravan)
            {
                if (kar.GetId() == id)
                {
                    kar.SetMinions(1);
                    kar.SetWagons(1);
                    kar.SetGuard(0);
                }
            }
            GamesWindow.napadliNas(wynik);
        }

        public void wyplata()
        {
            int kasa = 0;
            int x;
            foreach (TableCaravan kar in Modele.tableCaravan)
            {
                x = kar.GetGuard();
                x = x * 3;
                kasa = kasa + x;
                x = kar.GetMinions();
                kasa = kasa + x;
            }

            x = Modele.getGold();
            x = x - kasa;
            if (x < 0)
            {
                MainWindow.wi.zbankrutowales();
            }
            Modele.setGold(x);
        }

        public void dzien()
        {
            string ids;
            string idm;
            string idm2;
            string idt;
            string[] ruiny = new string[12];
            int ileRuin = 0;
            int czas;
            int licznik;
            List<TableTownState> kasowane = new List<TableTownState>();

            foreach (TableTownState stan in Modele.tableTownState)
            {
                ids = stan.GetIdState();
                idm = stan.GetId();
                czas = stan.GetDuration();
                czas--;
                stan.SetDuration(czas);
                if (czas == 0)     //koniec stanu
                {
                    switch (ids)
                    {
                        case "ST01":  //zaraza
                            foreach (TableArtInTown tow in Modele.tableArtInTown)
                            {
                                idt = tow.GetIdArticle();
                                idm2 = tow.GetId();
                                if (idt == "TO11" && idm == idm2)   //medykamenty
                                {
                                    licznik = tow.GetRequisition();
                                    licznik -= 500;
                                    tow.SetRequisition(licznik);
                                }
                            }
                            break;
                        case "ST02": //susza
                            foreach (TableArtInTown tow in Modele.tableArtInTown)
                            {
                                idt = tow.GetIdArticle();
                                idm2 = tow.GetId();
                                if (idt == "TO02" && idm == idm2)   //jabłka
                                {
                                    licznik = tow.GetProduction();
                                    licznik += 50;
                                    tow.SetProduction(licznik);
                                }
                                if (idt == "TO05" && idm == idm2)   //chleb
                                {
                                    licznik = tow.GetProduction();
                                    licznik += 50;
                                    tow.SetProduction(licznik);
                                }
                            }
                            break;
                        case "ST03": //nieurodzaj
                            foreach (TableArtInTown tow in Modele.tableArtInTown)
                            {
                                idt = tow.GetIdArticle();
                                idm2 = tow.GetId();
                                if (idt == "TO02" && idm == idm2)   //jabłka
                                {
                                    licznik = tow.GetProduction();
                                    licznik += 20;
                                    tow.SetProduction(licznik);
                                }
                                if (idt == "TO05" && idm == idm2)   //chleb
                                {
                                    licznik = tow.GetProduction();
                                    licznik += 20;
                                    tow.SetProduction(licznik);
                                }
                            }
                            break;
                        case "ST04": //obf. plony
                            foreach (TableArtInTown tow in Modele.tableArtInTown)
                            {
                                idt = tow.GetIdArticle();
                                idm2 = tow.GetId();
                                if (idt == "TO02" && idm == idm2)   //jabłka
                                {
                                    licznik = tow.GetProduction();
                                    licznik -= 20;
                                    tow.SetProduction(licznik);
                                }
                                if (idt == "TO05" && idm == idm2)   //chleb
                                {
                                    licznik = tow.GetProduction();
                                    licznik -= 20;
                                    tow.SetProduction(licznik);
                                }
                            }
                            break;
                        case "ST05": //w. obf. plony
                            foreach (TableArtInTown tow in Modele.tableArtInTown)
                            {
                                idt = tow.GetIdArticle();
                                idm2 = tow.GetId();
                                if (idt == "TO02" && idm == idm2)   //jabłka
                                {
                                    licznik = tow.GetProduction();
                                    licznik -= 50;
                                    tow.SetProduction(licznik);
                                }
                                if (idt == "TO05" && idm == idm2)   //chleb
                                {
                                    licznik = tow.GetProduction();
                                    licznik -= 50;
                                    tow.SetProduction(licznik);
                                }
                            }
                            break;
                        case "ST06": //pożar  
                            ruiny[ileRuin] = idm;
                            ileRuin++;
                            break;
                        case "ST07": //odbudowa
                            foreach (TableArtInTown tow in Modele.tableArtInTown)
                            {
                                idt = tow.GetIdArticle();
                                idm2 = tow.GetId();
                                if (idt == "TO01" && idm == idm2)   //materiały budowlane
                                {
                                    licznik = tow.GetRequisition();
                                    licznik -= 50;
                                    tow.SetRequisition(licznik);
                                }

                            }
                            break;
                        case "ST08": //war prep
                            foreach (TableArtInTown tow in Modele.tableArtInTown)
                            {
                                idt = tow.GetIdArticle();
                                idm2 = tow.GetId();
                                if (idt == "TO06" && idm == idm2)   //bron
                                {
                                    licznik = tow.GetRequisition();
                                    licznik -= 100;
                                    tow.SetRequisition(licznik);
                                }
                            }
                            break;
                        case "ST09": //war
                            foreach (TableArtInTown tow in Modele.tableArtInTown)
                            {
                                idt = tow.GetIdArticle();
                                idm2 = tow.GetId();
                                if (idt == "TO02" && idm == idm2)   //jabłka
                                {
                                    licznik = tow.GetRequisition();
                                    licznik -= 200;
                                    tow.SetRequisition(licznik);
                                }
                                if (idt == "TO05" && idm == idm2)   //chleb
                                {
                                    licznik = tow.GetRequisition();
                                    licznik -= 200;
                                    tow.SetRequisition(licznik);
                                }
                                if (idt == "TO04" && idm == idm2)   //mieso
                                {
                                    licznik = tow.GetRequisition();
                                    licznik -= 200;
                                    tow.SetRequisition(licznik);
                                }
                                if (idt == "TO01" && idm == idm2)   //surowce
                                {
                                    licznik = tow.GetRequisition();
                                    licznik -= 25;
                                    tow.SetRequisition(licznik);
                                }
                                if (idt == "TO11" && idm == idm2)   //medykamenty
                                {
                                    licznik = tow.GetRequisition();
                                    licznik -= 50;
                                    tow.SetRequisition(licznik);
                                }
                            }
                            break;
                        case "ST010": //oblężenie
                            ruiny[ileRuin] = idm;
                            ileRuin++;
                            break;
                        case "ST11": //gold age
                            foreach (TableArtInTown tow in Modele.tableArtInTown)
                            {
                                idt = tow.GetIdArticle();
                                idm2 = tow.GetId();
                                if (idt == "TO01" && idm == idm2)   //drewno
                                {
                                    licznik = tow.GetRequisition();
                                    licznik -= 10;
                                    tow.SetRequisition(licznik);
                                }
                                if (idt == "TO02" && idm == idm2)   //jabłko
                                {
                                    licznik = tow.GetRequisition();
                                    licznik -= 20;
                                    tow.SetRequisition(licznik);
                                }
                                if (idt == "TO03" && idm == idm2)   //tkanina
                                {
                                    licznik = tow.GetProduction();
                                    licznik -= 25;
                                    tow.SetProduction(licznik);
                                }
                                if (idt == "TO04" && idm == idm2)   //mięso
                                {
                                    licznik = tow.GetRequisition();
                                    licznik -= 20;
                                    tow.SetRequisition(licznik);
                                }
                                if (idt == "TO05" && idm == idm2)   //chleb
                                {
                                    licznik = tow.GetRequisition();
                                    licznik -= 20;
                                    tow.SetRequisition(licznik);
                                }
                                if (idt == "TO06" && idm == idm2)   //bron
                                {
                                    licznik = tow.GetProduction();
                                    licznik -= 25;
                                    tow.SetProduction(licznik);
                                }
                                if (idt == "TO07" && idm == idm2)   //perla
                                {
                                    licznik = tow.GetProduction();
                                    licznik -= 45;
                                    tow.SetProduction(licznik);

                                    licznik = tow.GetRequisition();
                                    licznik -= 20;
                                    tow.SetRequisition(licznik);
                                }
                                if (idt == "TO08" && idm == idm2)   //przyprawy
                                {
                                    licznik = tow.GetRequisition();
                                    licznik -= 20;
                                    tow.SetRequisition(licznik);
                                }
                                if (idt == "TO09" && idm == idm2)   //wino
                                {
                                    licznik = tow.GetRequisition();
                                    licznik -= 20;
                                    tow.SetRequisition(licznik);
                                }
                                if (idt == "TO11" && idm == idm2)   //alchemia
                                {
                                    licznik = tow.GetProduction();
                                    licznik -= 40;
                                    tow.SetProduction(licznik);
                                }
                            }
                            break;
                        default:
                            break;
                    }

                    TableTownState zakonczony = new TableTownState(idm, ids, 1);
                    kasowane.Add(zakonczony);
                }
                else
                {
                    //ewentualne działania podczas stanu
                    switch (ids)
                    {
                        case "ST01":  //zaraza
                            foreach (TableTown miasto in Modele.tableTown)
                            {
                                if (miasto.GetId() == idm)
                                {
                                    int pop = miasto.GetPopulation();
                                    double populacja = pop;
                                    double ofiary = populacja * 0.05;
                                    int of = (int)ofiary;
                                    pop = pop - of;
                                    if (pop < 50) pop = 50;
                                    miasto.SetPopulation(pop);
                                }
                            }
                            break;
                        case "ST02": //susza
                            break;
                        case "ST03": //nieurodzaj
                            break;
                        case "ST04": //obf. plony
                            break;
                        case "ST05": //w. obf. plony
                            break;
                        case "ST06": //pożar  
                            foreach (TableArtInTown tow in Modele.tableArtInTown)
                            {
                                idm2 = tow.GetId();
                                if (idm == idm2)   //dowolny towar w mieście (oberwą wszystkie po kolei)
                                {
                                    licznik = tow.GetProduction();
                                    licznik -= 5;
                                    tow.SetProduction(licznik);

                                    licznik = tow.GetNumber();
                                    licznik -= 10;
                                    tow.SetNumber(licznik);
                                }
                            }
                            break;
                        case "ST07": //odbudowa
                            foreach (TableArtInTown tow in Modele.tableArtInTown)
                            {
                                idm2 = tow.GetId();
                                if (idm == idm2)   //dowolny towar w mieście (oberwą wszystkie po kolei)
                                {
                                    licznik = tow.GetProduction();
                                    licznik += 5;
                                    tow.SetProduction(licznik);
                                }
                            }
                            break;
                        case "ST08": //war prep
                            foreach (TableTown miasto in Modele.tableTown)
                            {
                                if (miasto.GetId() == idm)
                                {
                                    int gotowosc = miasto.GetMilitary();
                                    gotowosc += 5;
                                    miasto.SetMilitary(gotowosc);
                                }
                            }
                            break;
                        case "ST09": //war
                            break;
                        case "ST010": //oblężenie
                            foreach (TableArtInTown tow in Modele.tableArtInTown)
                            {
                                idm2 = tow.GetId();
                                if (idm == idm2)   //dowolny towar w mieście (oberwą wszystkie po kolei)
                                {
                                    licznik = tow.GetProduction();
                                    licznik -= 5;
                                    tow.SetProduction(licznik);

                                    licznik = tow.GetNumber();
                                    licznik -= 10;
                                    tow.SetNumber(licznik);
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

            foreach (TableTownState stan in kasowane)
            {
                Modele.KoniecStanu(stan.GetIdState(), stan.GetId());
            }

            //losowanie ewentualnych nowych stanów

            Boolean flaga;
            foreach (TableTown miasto in Modele.tableTown)
            {
                idm = miasto.GetId();
                int dobro = miasto.GetProsperity();
                if (dobro > 250)
                {
                    flaga = Modele.NowyStan("ST11", idm, 5);//gold age
                    if (flaga == false)
                    {
                        foreach (TableArtInTown tow in Modele.tableArtInTown)
                        {
                            idt = tow.GetIdArticle();
                            idm2 = tow.GetId();
                            if (idt == "TO01" && idm == idm2)   //drewno
                            {
                                licznik = tow.GetRequisition();
                                licznik += 10;
                                tow.SetRequisition(licznik);
                            }
                            if (idt == "TO02" && idm == idm2)   //jabłko
                            {
                                licznik = tow.GetRequisition();
                                licznik += 20;
                                tow.SetRequisition(licznik);
                            }
                            if (idt == "TO03" && idm == idm2)   //tkanina
                            {
                                licznik = tow.GetProduction();
                                licznik += 25;
                                tow.SetProduction(licznik);
                            }
                            if (idt == "TO04" && idm == idm2)   //mięso
                            {
                                licznik = tow.GetRequisition();
                                licznik += 20;
                                tow.SetRequisition(licznik);
                            }
                            if (idt == "TO05" && idm == idm2)   //chleb
                            {
                                licznik = tow.GetRequisition();
                                licznik += 20;
                                tow.SetRequisition(licznik);
                            }
                            if (idt == "TO06" && idm == idm2)   //bron
                            {
                                licznik = tow.GetProduction();
                                licznik += 25;
                                tow.SetProduction(licznik);
                            }
                            if (idt == "TO07" && idm == idm2)   //perla
                            {
                                licznik = tow.GetProduction();
                                licznik += 45;
                                tow.SetProduction(licznik);

                                licznik = tow.GetRequisition();
                                licznik += 20;
                                tow.SetRequisition(licznik);
                            }
                            if (idt == "TO08" && idm == idm2)   //przyprawy
                            {
                                licznik = tow.GetRequisition();
                                licznik += 20;
                                tow.SetRequisition(licznik);
                            }
                            if (idt == "TO09" && idm == idm2)   //wino
                            {
                                licznik = tow.GetRequisition();
                                licznik += 20;
                                tow.SetRequisition(licznik);
                            }
                            if (idt == "TO11" && idm == idm2)   //alchemia
                            {
                                licznik = tow.GetProduction();
                                licznik += 40;
                                tow.SetProduction(licznik);
                            }
                        }
                    }
                }

                int gotowosc = miasto.GetMilitary();
                if (gotowosc < 50)
                {
                    flaga = Modele.NowyStan("ST08", idm, 12);//warprep
                    if (flaga == false)
                    {
                        foreach (TableArtInTown tow in Modele.tableArtInTown)
                        {
                            idt = tow.GetIdArticle();
                            idm2 = tow.GetId();
                            if (idt == "TO06" && idm == idm2)   //bron
                            {
                                licznik = tow.GetRequisition();
                                licznik += 100;
                                tow.SetRequisition(licznik);
                            }
                        }
                    }
                }
                if (gotowosc > 300)
                {
                    flaga = Modele.NowyStan("ST09", idm, 20);//war
                    if (flaga == false)
                    {
                        foreach (TableArtInTown tow in Modele.tableArtInTown)
                        {
                            idt = tow.GetIdArticle();
                            idm2 = tow.GetId();
                            if (idt == "TO02" && idm == idm2)   //jabłka
                            {
                                licznik = tow.GetRequisition();
                                licznik += 200;
                                tow.SetRequisition(licznik);
                            }
                            if (idt == "TO05" && idm == idm2)   //chleb
                            {
                                licznik = tow.GetRequisition();
                                licznik += 200;
                                tow.SetRequisition(licznik);
                            }
                            if (idt == "TO04" && idm == idm2)   //mieso
                            {
                                licznik = tow.GetRequisition();
                                licznik += 200;
                                tow.SetRequisition(licznik);
                            }
                            if (idt == "TO01" && idm == idm2)   //surowce
                            {
                                licznik = tow.GetRequisition();
                                licznik += 25;
                                tow.SetRequisition(licznik);
                            }
                            if (idt == "TO11" && idm == idm2)   //medykamenty
                            {
                                licznik = tow.GetRequisition();
                                licznik += 50;
                                tow.SetRequisition(licznik);
                            }
                        }
                    }
                }

            }

            while (ileRuin > 0)
            {
                ileRuin--;
                idm = ruiny[ileRuin];
                foreach (TableTown miasto in Modele.tableTown)
                {
                    idm2 = miasto.GetId();
                    if (idm == idm2)
                    {
                        flaga = Modele.NowyStan("ST07", idm, 10);  //odbudowa
                        if (flaga == false)
                        {

                            foreach (TableArtInTown tow in Modele.tableArtInTown)
                            {
                                idt = tow.GetIdArticle();
                                idm2 = tow.GetId();
                                if (idt == "TO01" && idm == idm2)   //materiały budowlane
                                {
                                    licznik = tow.GetRequisition();
                                    licznik += 50;
                                    tow.SetRequisition(licznik);
                                }
                            }
                        }
                    }
                }

            }



            foreach (TableTown miasto in Modele.tableTown)
            {
                idm = miasto.GetId();
                Random rng = new Random();
                int randomek = rng.Next(100);
                int czas2 = rng.Next(5, 16);

                switch (randomek)
                {
                    case 1:
                        flaga = Modele.NowyStan("ST01", idm, czas2);  //zaraza
                        if (flaga == false)
                        {
                            foreach (TableArtInTown tow in Modele.tableArtInTown)
                            {
                                idt = tow.GetIdArticle();
                                idm2 = tow.GetId();
                                if (idt == "TO11" && idm == idm2)   //medykamenty
                                {
                                    licznik = tow.GetRequisition();
                                    licznik += 500;
                                    tow.SetRequisition(licznik);
                                }
                            }
                        }
                        break;
                    case 2:
                        flaga = Modele.NowyStan("ST02", idm, czas2);  //susza
                        if (flaga == false)
                        {
                            foreach (TableArtInTown tow in Modele.tableArtInTown)
                            {
                                idt = tow.GetIdArticle();
                                idm2 = tow.GetId();
                                if (idt == "TO02" && idm == idm2)   //jabłka
                                {
                                    licznik = tow.GetProduction();
                                    licznik -= 50;
                                    tow.SetProduction(licznik);
                                }
                                if (idt == "TO05" && idm == idm2)   //chleb
                                {
                                    licznik = tow.GetProduction();
                                    licznik -= 50;
                                    tow.SetProduction(licznik);
                                }
                            }
                        }
                        break;
                    case 3:
                        flaga = Modele.NowyStan("ST03", idm, czas2);  //nieurodzaj
                        if (flaga == false)
                        {
                            foreach (TableArtInTown tow in Modele.tableArtInTown)
                            {
                                idt = tow.GetIdArticle();
                                idm2 = tow.GetId();
                                if (idt == "TO02" && idm == idm2)   //jabłka
                                {
                                    licznik = tow.GetProduction();
                                    licznik -= 20;
                                    tow.SetProduction(licznik);
                                }
                                if (idt == "TO05" && idm == idm2)   //chleb
                                {
                                    licznik = tow.GetProduction();
                                    licznik -= 20;
                                    tow.SetProduction(licznik);
                                }
                            }
                        }
                        break;
                    case 4:
                        flaga = Modele.NowyStan("ST04", idm, czas2);  //obfite plony
                        if (flaga == false)
                        {
                            foreach (TableArtInTown tow in Modele.tableArtInTown)
                            {
                                idt = tow.GetIdArticle();
                                idm2 = tow.GetId();
                                if (idt == "TO02" && idm == idm2)   //jabłka
                                {
                                    licznik = tow.GetProduction();
                                    licznik += 20;
                                    tow.SetProduction(licznik);
                                }
                                if (idt == "TO05" && idm == idm2)   //chleb
                                {
                                    licznik = tow.GetProduction();
                                    licznik += 20;
                                    tow.SetProduction(licznik);
                                }
                            }
                        }
                        break;
                    case 5:
                        flaga = Modele.NowyStan("ST05", idm, czas2);  //b. obf. plony
                        if (flaga == false)
                        {
                            foreach (TableArtInTown tow in Modele.tableArtInTown)
                            {
                                idt = tow.GetIdArticle();
                                idm2 = tow.GetId();
                                if (idt == "TO02" && idm == idm2)   //jabłka
                                {
                                    licznik = tow.GetProduction();
                                    licznik += 50;
                                    tow.SetProduction(licznik);
                                }
                                if (idt == "TO05" && idm == idm2)   //chleb
                                {
                                    licznik = tow.GetProduction();
                                    licznik += 50;
                                    tow.SetProduction(licznik);
                                }
                            }
                        }
                        break;
                    case 6:
                        czas2 /= 2;
                        flaga = Modele.NowyStan("ST06", idm, czas2);  //pożar
                        break;
                    default:
                        break;
                }

            }
        }

        public void tydzien()
        {
            foreach (TableArtInTown towar in Modele.tableArtInTown)
            {
                towar tmp = new towar(towar);
                tmp.zmianaIlosci();
            }

            foreach (TableTown miasto in Modele.tableTown)
            {              
                miasto miasto2 = new miasto(miasto);

                miasto2.zmianaPopulacji();

                miasto.SetPopulation(miasto2.getPopulacje());
                miasto.SetMilitary(miasto2.getGotowosc());
                miasto.SetProsperity(miasto2.getDobrobyt());
                miasto.SetFood(miasto2.getZywnosc());
            }
        }
    }
}
