using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caravans.model;

namespace Caravans.matma
{
    public static class warsztat
    {
        public static Boolean kupWoz(string id)
        {
            int kasa = Modele.getGold();
            int x;
            if (kasa >= 200)
            {
                foreach(TableCaravan kar in Modele.tableCaravan)
                {
                    if (kar.GetId() == id)
                    {
                        x = kar.GetWagons();
                        x++;
                        kar.SetWagons(x);
                    }
                }
                x = Modele.getGold();
                x = x - 200;
                Modele.setGold(x);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void najmijPomoc(string id)
        {
            foreach (TableCaravan kar in Modele.tableCaravan)
            {
                if (kar.GetId() == id)
                {
                    int x = kar.GetMinions();
                    x++;
                    kar.SetMinions(x);
                }
            }
        }

        public static void najmijOchrone(string id)
        {
            foreach (TableCaravan kar in Modele.tableCaravan)
            {
                if (kar.GetId() == id)
                {
                    int x = kar.GetGuard();
                    x++;
                    kar.SetGuard(x);
                }
            }
        }

        public static Boolean zwolnijPomoc(string id)
        {
            foreach (TableCaravan kar in Modele.tableCaravan)
            {
                if (kar.GetId() == id)
                {
                    if (kar.GetMinions() > 0)
                    {
                        int x = kar.GetMinions();
                        x--;
                        kar.SetMinions(x);
                        return true;
                    }                   
                }
            }
            return false;
        }

        public static Boolean zwolnijOchrone(string id)
        {
            foreach (TableCaravan kar in Modele.tableCaravan)
            {
                if (kar.GetId() == id)
                {
                    if (kar.GetGuard()>0) {
                        int x = kar.GetGuard();
                        x--;
                        kar.SetGuard(x);
                        return true;
                    }
                }
            }
            return false;
        }

        public static Boolean nowaKarawana (string id)
        {
            if (Modele.getGold() < 500) return false;
            int x = Modele.getGold();
            x = x - 500;
            Modele.setGold(x);
            int a = Modele.tableCaravan.Count();
            a++;
            string idk = "";
            if (a < 10)
            {
                idk = "KA0" + a.ToString();
            }
            else
            {
                idk = "KA" + a.ToString();
            }
            string idl = "";
            foreach(TableCaravan kar in Modele.tableCaravan)
            {
                if (kar.GetId() == id) idl = kar.GetIdLoc();
            }
            Modele.dodajKarawane(idk, idl);

            return true;
        }
    }
}
