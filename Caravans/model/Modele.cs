using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Caravans.model
{
    public class Modele
    {

        static SQLreq SQLTest = new SQLreq();

        public static List<TableLoc> tableLoc = new List<TableLoc>();
        public static List<TableArticle> tableArticle = new List<TableArticle>();
        public static List<TableState> tableState = new List<TableState>();
        public static List<TableRoad> tableRoad = new List<TableRoad>();
        public static List<TableTown> tableTown = new List<TableTown>();
        public static List<TableTownState> tableTownState = new List<TableTownState>();
        public static List<TableCaravan> tableCaravan = new List<TableCaravan>();
        public static List<TableArtInCaravan> tableArtInCaravan = new List<TableArtInCaravan>();
        public static List<TableArtInTown> tableArtInTown = new List<TableArtInTown>();


        private static int gold;
        private static int time;

        internal Modele()
        {
        }

        public static void Load()
        {
            tableLoc.Clear();
            tableArticle.Clear();
            tableState.Clear();
            tableRoad.Clear();
            tableTown.Clear();
            tableTownState.Clear();
            tableCaravan.Clear();
            tableArtInTown.Clear();
            tableArtInCaravan.Clear();

            ReadResources();

            ReadListLocation();
            ReadListArticle();
            ReadListState();
            ReadListRoad();
            ReadListTown();

            ReadListCaravan();
            ReadListTownState();
            ReadListArtInCaravan();
            ReadListArtInTown();
        }
        public static void Repop()
        {
            tableLoc.Clear();
            tableArticle.Clear();
            tableState.Clear();
            tableRoad.Clear();
            tableTown.Clear();
            tableTownState.Clear();
            tableCaravan.Clear();
            tableArtInTown.Clear();
            tableArtInCaravan.Clear();

            gold = 5000;
            time = 0;

            ReadArticle_NG();
            ReadState_NG();
            ReadLocs_NG();
            ReadCaravan_NG();
            ReadRoads_NG();
            ReadTown_NG();
            ReadArt_in_caravan_NG();
            ReadArt_in_town_NG();
        }
        public static void Save()
        {
            UpdateListArticle();
            UpdateListArtInTown();
            UpdateListTownState();
            UpdateListCaravan();
            UpdateListTown();
            UpdateListArtInCaravan();
            UpdateResources();
        }


        public static int getGold()
        {
            return gold;
        }
        public static void setGold(int a)
        {
            gold = a;
        }
        public static int getTime()
        {
            return time;
        }

        public static void setTime(int a)
        {
            time = a;
        }

        public static TableLoc ZnajdzLokacje(string id)
        {
            TableLoc lokacja = tableLoc.Select(n => n).Where(x => x.GetId() == id).FirstOrDefault();
            return lokacja;
        }

        public static TableArticle ZnajdzTowar(string id)
        {
            TableArticle towar = tableArticle.Select(n => n).Where(x => x.GetId() == id).FirstOrDefault();
            return towar;
        }

        public static TableState ZnajdzStan(string id)
        {
            TableState stan = tableState.Select(n => n).Where(x => x.GetId() == id).FirstOrDefault();
            return stan;
        }

        public static TableRoad ZnajdzDroge(string id)
        {
            TableRoad droga = tableRoad.Select(n => n).Where(x => x.GetId() == id).FirstOrDefault();
            return droga;
        }

        public static TableRoad ZnajdzDroge(string id1, string id2)
        {
            TableRoad droga = tableRoad.Select(n => n).Where(x => (x.GetIdLoc_1() == id1 && x.GetIdLoc_2() == id2) || (x.GetIdLoc_1() == id2 && x.GetIdLoc_2() == id1)).FirstOrDefault();
            return droga;
        }

        public static TableTown ZnajdzMiasto(string id)
        {
            TableTown miasto = tableTown.Select(n => n).Where(x => x.GetId() == id).FirstOrDefault();
            return miasto;
        }

        public static TableTownState ZnajdzStanMiasta(string idm, string ids)
        {
            TableTownState stan = tableTownState.Select(n => n).Where(x => x.GetId() == idm && x.GetIdState()==ids).FirstOrDefault();
            return stan;
        }

        public static TableCaravan ZnajdzKarawane(string id)
        {
            TableCaravan karawana = tableCaravan.Select(n => n).Where(x => x.GetId() == id).FirstOrDefault();
            return karawana;
        }

        public static TableArtInCaravan ZnajdzTowarWKarawanie(string idt, string idk)
        {
            TableArtInCaravan towar = tableArtInCaravan.Select(n => n).Where(x => x.GetId() == idk && x.GetIdArticle()==idt).FirstOrDefault();
            return towar;
        }

        public static TableArtInTown ZnajdzTowarWMiescie(string idt, string idm)
        {
            TableArtInTown towar = tableArtInTown.Select(n => n).Where(x => x.GetId() == idm && x.GetIdArticle()==idt).FirstOrDefault();
            return towar;
        }


        public static void dodajKarawane(string a, string b)
        {
            TableCaravan nowa = new TableCaravan(a, b, 1, 0, 0, 1);
            tableCaravan.Add(nowa);
            TableArtInCaravan nowy = new TableArtInCaravan(a, "TO01", 0);
            tableArtInCaravan.Add(nowy);
            nowy = new TableArtInCaravan(a, "TO01", 0);
            tableArtInCaravan.Add(nowy);
            nowy = new TableArtInCaravan(a, "TO02", 0);
            tableArtInCaravan.Add(nowy);
            nowy = new TableArtInCaravan(a, "TO03", 0);
            tableArtInCaravan.Add(nowy);
            nowy = new TableArtInCaravan(a, "TO04", 0);
            tableArtInCaravan.Add(nowy);
            nowy = new TableArtInCaravan(a, "TO05", 0);
            tableArtInCaravan.Add(nowy);
            nowy = new TableArtInCaravan(a, "TO06", 0);
            tableArtInCaravan.Add(nowy);
            nowy = new TableArtInCaravan(a, "TO07", 0);
            tableArtInCaravan.Add(nowy);
            nowy = new TableArtInCaravan(a, "TO08", 0);
            tableArtInCaravan.Add(nowy);
            nowy = new TableArtInCaravan(a, "TO09", 0);
            tableArtInCaravan.Add(nowy);
            nowy = new TableArtInCaravan(a, "TO10", 0);
            tableArtInCaravan.Add(nowy);
            nowy = new TableArtInCaravan(a, "TO11", 0);
            tableArtInCaravan.Add(nowy);
        }

        public static void KoniecStanu(string ids, string idm)
        {
            foreach (TableTownState stan in tableTownState)
            {
                string ids2 = stan.GetIdState();
                string idm2 = stan.GetId();
                if (ids == ids2 && idm == idm2)
                {
                    tableTownState.Remove(stan);
                    break;
                }
            }
        }

        public static Boolean NowyStan(string ids, string idm, int czas)
        {
            Boolean flaga = false;
            string ids2;
            string idm2;
            foreach (TableTownState stan in tableTownState)
            {
                idm2 = stan.GetId();
                ids2 = stan.GetIdState();
                if(idm2==idm && ids2 == ids)
                {
                    flaga = true;
                    stan.SetDuration(czas);
                }
            }
            if (flaga == false)
            {
                TableTownState nowy = new TableTownState(idm, ids, czas);
                tableTownState.Add(nowy);
            }
            return flaga;
        }


        //Wczytywanie danych do Modelu
        internal static void ReadResources()
        {
            int Gold = 0;
            int Turn = 0;
            SQLTest.ReadResourcesToMod(out Gold, out Turn);
            setGold(Gold);
            setTime(Turn);
        }
        internal static void ReadListLocation()
        {
            SQLTest.ReadLocsToMod(tableLoc);
        }
        internal static void ReadListArticle()
        {
            SQLTest.ReadArticleToMod(tableArticle);
        }
        internal static void ReadListState()
        {
            SQLTest.ReadStateToMod(tableState);
        }
        internal static void ReadListRoad()
        {
            SQLTest.ReadRoadsToMod(tableRoad);
        }
        internal static void ReadListTown()
        {
            SQLTest.ReadTownToMod(tableTown);
        }
        internal static void ReadListTownState()
        {
            SQLTest.ReadTownStateToMod(tableTownState);
        }
        internal static void ReadListCaravan()
        {
            SQLTest.ReadCaravanToMod(tableCaravan);
        }
        internal static void ReadListArtInCaravan()
        {
            SQLTest.ReadArtInCaravanToMod(tableArtInCaravan);
        }
        internal static void ReadListArtInTown()
        {
            SQLTest.ReadArtInTownToMod(tableArtInTown);
        }

        //Czytanie danych do nowej Gry
        internal static void ReadLocs_NG()
        {
            string path = @"..\..\NewGame_data\Locs_data.txt";
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.Peek() >= 0)
                    {
                        string Line = sr.ReadLine();
                        String[] elem = Line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        tableLoc.Add(new TableLoc(elem[0], elem[1]));
                    }
                }
            }
            catch (Exception e)
            {
            }
        }
        internal static void ReadArticle_NG()
        {
            string path = @"..\..\NewGame_data\Article_data.txt";
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.Peek() >= 0)
                    {
                        string Line = sr.ReadLine();
                        String[] elem = Line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        tableArticle.Add(new TableArticle(elem[0], elem[1], Convert.ToInt32(elem[2]), Convert.ToInt32(elem[3]), Convert.ToInt32(elem[4])));
                    }
                }
            }
            catch (Exception e)
            {
            }
        }
        internal static void ReadState_NG()
        {
            string path = @"..\..\NewGame_data\State_data.txt";
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.Peek() >= 0)
                    {
                        string Line = sr.ReadLine();
                        String[] elem = Line.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                        tableState.Add(new TableState(elem[0], elem[1], elem[2]));
                    }
                }
            }
            catch (Exception e)
            {
            }
        }
        internal static void ReadRoads_NG()
        {
            string path = @"..\..\NewGame_data\Roads_data.txt";
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.Peek() >= 0)
                    {
                        string Line = sr.ReadLine();
                        String[] elem = Line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        tableRoad.Add(new TableRoad(elem[0], elem[1], elem[2], Convert.ToInt32(elem[3]), Convert.ToInt32(elem[4])));
                    }
                }
            }
            catch (Exception e)
            {
            }
        }
        internal static void ReadTown_NG()
        {
            string path = @"..\..\NewGame_data\Town_data.txt";
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.Peek() >= 0)
                    {
                        string Line = sr.ReadLine();
                        String[] elem = Line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        tableTown.Add(new TableTown(elem[0], elem[1], Convert.ToInt32(elem[2]), elem[3], Convert.ToInt32(elem[4]), Convert.ToInt32(elem[5]), Convert.ToInt32(elem[6])));
                    }
                }
            }
            catch (Exception e)
            {
            }
        }
        internal static void ReadCaravan_NG()
        {
            tableCaravan.Add(new TableCaravan("KA01", "LO10", 1, 0, 0, 0));
        }
        internal static void ReadArt_in_caravan_NG()
        {
            string path = @"..\..\NewGame_data\Art_In_Caravan_data.txt";
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.Peek() >= 0)
                    {
                        string Line = sr.ReadLine();
                        String[] elem = Line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        tableArtInCaravan.Add(new TableArtInCaravan(elem[0], elem[1], Convert.ToInt32(elem[2])));
                    }
                }
            }
            catch (Exception e)
            {
            }
        }
        internal static void ReadArt_in_town_NG()
        {
            string path = @"..\..\NewGame_data\Art_In_Town_data.txt";
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.Peek() >= 0)
                    {
                        string Line = sr.ReadLine();
                        String[] elem = Line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        tableArtInTown.Add(new TableArtInTown(elem[0], elem[1], Convert.ToInt32(elem[2]), Convert.ToInt32(elem[3]), Convert.ToInt32(elem[4])));
                    }
                }
            }
            catch (Exception e)
            {
            }
        }    

        public static void UpdateListArticle()
        {
            foreach (var art in tableArticle)
            {
                SQLTest.UpdateArticle(art);
            }
        }
        public static void UpdateListArtInTown()
        {
            foreach (var art in tableArtInTown)
            {
                SQLTest.UpdateArtInTown(art);
            }
        }
        public static void UpdateListTownState()
        {
            SQLTest.TruncateTownState();
            foreach (var ts in tableTownState)
            {
                SQLTest.UpdateTownState(ts);
            }
        }
        public static void UpdateListCaravan()
        {
            SQLTest.TruncateCaravan();
            foreach (var caravan in tableCaravan)
            {
                SQLTest.UpdateCaravan(caravan);
            }
        }
        public static void UpdateListTown()
        {
            foreach (var town in tableTown)
            {
                SQLTest.UpdateTown(town);
            }
        }
        public static void UpdateListArtInCaravan()
        {
            SQLTest.TruncateArtInCaravan();
            foreach (var art in tableArtInCaravan)
            {
                SQLTest.UpdateArtInCaravan(art);
            }
        }
        public static void UpdateResources()
        {
            SQLTest.UpdateResources(getGold(), getTime());
        }
    }
}
