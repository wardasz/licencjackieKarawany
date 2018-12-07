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
            TableArtInTown towarMiasto = Modele.ZnajdzTowarWMiescie(IDtowar, IDmiasto);
            TableArtInCaravan towarKarawana = Modele.ZnajdzTowarWKarawanie(IDtowar, IDkarawana);

            if (cena == -1) { return "Ten towar nie jest na sprzedarz"; }
            if (towarMiasto.GetNumber()<ile) { return "Chcesz kupić więcej towaru niż jest w mieście"; }
            int dostepnaMasa = pojemnosc - obciazenie;
            if (dostepnaMasa < ile) { return "Tyle towaru nie zmieści się w naszej karawanie"; }
            int kwota = ile * cena;
            if (kwota> Modele.getGold()) { return "Nie masz dość złota!"; }

            towarMiasto.SetNumber(towarMiasto.GetNumber()-ile);
            towarKarawana.SetNumber(towarKarawana.GetNumber() + ile);
            Modele.setGold(Modele.getGold() - kwota);
            return "done";
        }

        public static string sprzedaj(string IDkarawana, string IDmiasto, string IDtowar, int ile, int cena)
        {
            TableArtInTown towarMiasto = Modele.ZnajdzTowarWMiescie(IDtowar, IDmiasto);
            TableArtInCaravan towarKarawana = Modele.ZnajdzTowarWKarawanie(IDtowar, IDkarawana);

            if (towarKarawana.GetNumber() < ile) { return "Nie masz dość towaru na wozach"; }

            towarMiasto.SetNumber(towarMiasto.GetNumber() + ile);
            towarKarawana.SetNumber(towarKarawana.GetNumber() - ile);
            Modele.setGold(Modele.getGold() + cena * ile);
            return "done";         
        }
    }
}
