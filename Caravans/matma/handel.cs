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
            int pojemnosc = przekaznik.PoliczPojemnosc(IDkarawana);
            int obciazenie = przekaznik.PoliczObciozenie(IDkarawana);
            int ileWMiescie = 0;
            foreach (TableArtInTown towar in Modele.tableArtInTown)
            {
                if (towar.GetId() == IDmiasto && towar.GetIdArticle() == IDtowar)
                {
                    ileWMiescie = towar.GetNumber();
                }
            }

            if (cena == -1) { return "Ten towar nie jest na sprzedarz"; }
            if (ileWMiescie<ile) { return "Chcesz kupić więcej towaru niż jest w mieście"; }
            int dostepnaMasa = pojemnosc - obciazenie;
            if (dostepnaMasa < ile) { return "Tyle towaru nie zmieści się w naszej karawanie"; }
            int kwota = ile * cena;
            if (kwota> Modele.getGold()) { return "Nie masz dość złota!"; }

            foreach (TableArtInTown towar in Modele.tableArtInTown)
            {
                if (towar.GetId() == IDmiasto && towar.GetIdArticle() == IDtowar)
                {
                    towar.SetNumber(towar.GetNumber() - ile);
                }
            }
            foreach (TableArtInCaravan towar in Modele.tableArtInCaravan)
            {
                if(towar.GetIdArticle() == IDtowar && towar.GetId() == IDkarawana)
                {
                    towar.SetNumber(towar.GetNumber() + ile);
                }
            }
            Modele.setGold(Modele.getGold() - kwota);
            return "done";
        }

        public static string sprzedaj(string IDkarawana, string IDmiasto, string IDtowar, int ile, int cena)
        {
            int ileWKarawanie = 0;
            foreach (TableArtInCaravan towar in Modele.tableArtInCaravan)
            {
                if (towar.GetIdArticle() == IDtowar && towar.GetId() == IDkarawana) {
                    ileWKarawanie = towar.GetNumber();
                }
            }

            if (ileWKarawanie < ile) { return "Nie masz dość towaru na wozach"; }

            foreach (TableArtInCaravan towar in Modele.tableArtInCaravan)
            {
                if (towar.GetIdArticle() == IDtowar && towar.GetId() == IDkarawana)
                {
                    towar.SetNumber(towar.GetNumber()-ile);
                }
            }
            foreach (TableArtInTown towar in Modele.tableArtInTown)
            {
                if (towar.GetId() == IDmiasto && towar.GetIdArticle() == IDtowar)
                {
                    towar.SetNumber(towar.GetNumber() - ile);
                }
            }
            Modele.setGold(Modele.getGold() + cena * ile);
            return "done";         
        }
    }
}
