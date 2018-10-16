using Caravans.model;

namespace Caravans.matma
{
    class podroz
    {
        private const string NULL = "NULL";

        public static void podrozdo(string miastoid, string karawanaid)
        {

            int liczbamiast = 0, i = 0, pomocint;
            string cel = "";
            Tablicadoliczenia najmniejszywezel = new Tablicadoliczenia(), pom = new Tablicadoliczenia();
            najmniejszywezel.Setczas(-1);
            pom.Setczas(-1);

            foreach (TableTown y in Modele.tableTown)//liczy ile jest miast i czy dane miasto istnieje 
            {
                if (y.GetId() != NULL)
                {// spr czy nie ma nulla
                    liczbamiast++;
                    if (y.GetId() == miastoid)
                    {
                        cel = y.GetIdLoc();
                    }
                }
            }
            Tablicadoliczenia[] table = new Tablicadoliczenia[liczbamiast];
            foreach (TableLoc z in Modele.tableLoc)// wpisuje do tablicy id lokacji (bez nulli)
            {
                if (z.GetId() != NULL)
                {
                    table[i] = new Tablicadoliczenia(z.GetId());
                    i++;
                }
            }
            i = 0;//usunac pozniej jesli bd taka potrzeba
                  //tu trz bd dodac ifa juz obliczonych drog pozniej
            foreach (TableCaravan x in Modele.tableCaravan)
            {
                if (x.GetId() == karawanaid && x.GetDuration() == 0 && x.GetIdLoc() != cel)
                {

                    foreach (Tablicadoliczenia t in table)// liczy odleglosci punktow sasiednich od lokacji karawany
                    {
                        if (x.GetIdLoc() != t.GetIdLoc())
                        {
                            foreach (TableRoad road in Modele.tableRoad)//sprawdza czy te lokacje sa polaczone jesli tak to wpisuje dlugosc i ustawia id poprzedniej lokacji
                            {
                                if (road.GetIdLoc_1() == x.GetIdLoc() && road.GetIdLoc_2() == t.GetIdLoc() || road.GetIdLoc_2() == x.GetIdLoc() && road.GetIdLoc_1() == t.GetIdLoc())
                                {

                                    t.Setczas(road.GetLength());

                                    if (najmniejszywezel.Getczas() > t.Getczas())
                                        najmniejszywezel = t;

                                    else if (najmniejszywezel.Getczas() == -1)
                                        najmniejszywezel = t;

                                    t.SetpoprzIdloc(x.GetIdLoc());
                                }
                            }
                        }
                        else if (x.GetIdLoc() == t.GetIdLoc())
                        {
                            t.Setdone(1);
                            t.Setczas(0);
                        }
                    } // koniec pierwszego etapu dijkstry

                    for (i = 0; i < 11; i++)
                    {
                        foreach (Tablicadoliczenia t in table)// liczy odleglosci punktow sasiednich od lokacji najmniejszego wezla
                        {
                            if (najmniejszywezel.GetIdLoc() != t.GetIdLoc() && t.Getdone() != 1)
                            {
                                foreach (TableRoad road in Modele.tableRoad)//sprawdza czy te lokacje sa polaczone jesli tak to wpisuje dlugosc i ustawia id poprzedniej lokacji
                                {
                                    if (road.GetIdLoc_1() == najmniejszywezel.GetIdLoc() && road.GetIdLoc_2() == t.GetIdLoc() || road.GetIdLoc_2() == najmniejszywezel.GetIdLoc() && road.GetIdLoc_1() == t.GetIdLoc())
                                    {
                                        pomocint = najmniejszywezel.Getczas() + road.GetLength();
                                        if (t.Getczas() > 0 && t.Getczas() > pomocint || t.Getczas() < 0)
                                        {
                                            t.Setczas(pomocint);
                                            t.SetpoprzIdloc(x.GetIdLoc());
                                        }
                                    }
                                }
                            }
                            else if (najmniejszywezel.GetIdLoc() == t.GetIdLoc())
                            {
                                t.Setdone(1);
                            }
                            if (pom.Getczas() < 0 && t.Getdone() != 1 && t.Getczas() != -1 || pom.Getczas() > t.Getczas() && t.Getdone() != 1 && t.Getczas() != -1 || pom.Getdone() == 1)
                            {
                                pom = t;
                            }
                        }
                        najmniejszywezel = pom;

                    }// koniec drugiego etapu dijkstry
                    foreach (Tablicadoliczenia t in table)
                    {
                        if (cel == t.GetIdLoc())
                        {
                            x.SetIdLoc(cel);
                            x.ChangeDuration(t.Getczas());
                        }
                    }
                }
            }
        }
    }
}
