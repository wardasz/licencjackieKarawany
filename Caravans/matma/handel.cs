using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caravans.model;

namespace Caravans.matma
{
    class handel
    {

        public static string kup(string IDkarawana, string IDmiasto, string IDtowar, int ile, int cena)
        {
            if (ile > 0 && cena > 0)
            {
                if (cena * ile <= Modele.getGold())
                {
                    foreach (TableArtInCaravan y in Modele.tableArtInCaravan)
                    {
                        if (y.GetIdArticle() == IDtowar && y.GetId() == IDkarawana)
                        {
                            foreach (TableArtInTown z in Modele.tableArtInTown)
                            {
                                if (z.GetId() == IDmiasto && z.GetIdArticle() == IDtowar)
                                {
                                    int pojemnosc = przekaznik.PoliczPojemnosc(IDkarawana);
                                    int obciazenie = przekaznik.PoliczObciozenie(IDkarawana);
                                    if (pojemnosc >= obciazenie+ile)
                                    {
                                        if (ile <= z.GetNumber())
                                        {
                                            Modele.setGold(Modele.getGold() - cena * ile);
                                            y.SetNumber(y.GetNumber() + ile);
                                            z.SetNumber(z.GetNumber() - ile);
                                        }
                                        else
                                        {
                                            return "Brak/za mało towaru w miescie!"; //gdy sie prosi o wiecej niz w miescie jest dostepne
                                        }
                                    }
                                    else
                                    {
                                        return "Zbyt mała pojemnosc karawany!";
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    return "Za mało złota!";
                }
            }
            else
            {
                return "Ten towar nie jest na sprzedaż";// gdy towar ma status niemozliwe
            }
            return "done";
        }

        public static string sprzedaj(string IDkarawana, string IDmiasto, string IDtowar, int ile, int cena)
        {
            if (ile > 0)
            {
                foreach (TableArtInCaravan y in Modele.tableArtInCaravan)
                {
                    if (y.GetIdArticle() == IDtowar && y.GetId() == IDkarawana)
                    {
                        if (ile <= y.GetNumber())
                        {
                            foreach (TableArtInTown z in Modele.tableArtInTown)
                            {
                                if (z.GetId() == IDmiasto && z.GetIdArticle() == IDtowar)
                                {
                                    Modele.setGold(Modele.getGold() + cena * ile);
                                    y.SetNumber(y.GetNumber() - ile);
                                    z.SetNumber(z.GetNumber() + ile);
                                }
                            }
                        }
                        else
                        {
                            return "Niewystarczajaca ilosc towaru w karawanie!";
                        }
                    }
                }              
            }
            return "done";
        }
    }
}
