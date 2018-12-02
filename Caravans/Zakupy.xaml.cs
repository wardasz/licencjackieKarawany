using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Caravans.matma;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;


namespace Caravans
{
    public partial class Zakupy : Window
    {
        private static string idk;
        private static string idm;

        private static ceny dane;
        
        public Zakupy(string a)
        {
            idk = a;
            InitializeComponent();       
            odswiez();
        }

        public void odswiez()
        {
            idm = przekaznik.lok(idk);
            dane = new ceny(idm);
            string tmp;

            tkaninaKarawana.Text = przekaznik.IleTowaru(idk, "TO03");
            tkaninaMiasto.Text = dane.getIle("TO03");
            tmp = dane.getCenaKup("TO03");
            if (tmp == "-1") { tmp = "niemożliwe"; }
            tkaninaKupno.Text = tmp;
            tkaninaSprzedarz.Text = dane.getCenaSp("TO03");

            winoKarawana.Text = przekaznik.IleTowaru(idk, "TO09");
            winoMiasto.Text = dane.getIle("TO09");
            tmp = dane.getCenaKup("TO09");
            if (tmp == "-1") { tmp = "niemożliwe"; }
            winoKupno.Text = tmp;
            winoSprzedarz.Text = dane.getCenaSp("TO09");

            bronKarawana.Text = przekaznik.IleTowaru(idk, "TO06");
            bronMiasto.Text = dane.getIle("TO06");
            tmp = dane.getCenaKup("TO06");
            if (tmp == "-1") { tmp = "niemożliwe"; }
            bronKupno.Text = tmp;
            bronSprzedarz.Text = dane.getCenaSp("TO06");

            chlebKarawana.Text = przekaznik.IleTowaru(idk, "TO05");
            chlebMiasto.Text = dane.getIle("TO05");
            tmp = dane.getCenaKup("TO05");
            if (tmp == "-1") { tmp = "niemożliwe"; }
            chlebKupno.Text = tmp;
            chlebSprzedarz.Text = dane.getCenaSp("TO05");

            drewnoKarawana.Text = przekaznik.IleTowaru(idk, "TO01");
            drewnoMiasto.Text = dane.getIle("TO01");
            tmp = dane.getCenaKup("TO01");
            if (tmp == "-1") { tmp = "niemożliwe"; }
            drewnoKupno.Text = tmp;
            drewnoSprzedarz.Text = dane.getCenaSp("TO01");

            jablkoKarawana.Text = przekaznik.IleTowaru(idk, "TO02");
            jablkoMiasto.Text = dane.getIle("TO02");
            tmp = dane.getCenaKup("TO02");
            if (tmp == "-1") { tmp = "niemożliwe"; }
            jablkoKupno.Text = tmp;
            jablkoSprzedarz.Text = dane.getCenaSp("TO02");

            miesoKarawana.Text = przekaznik.IleTowaru(idk, "TO04");
            miesoMiasto.Text = dane.getIle("TO04");
            tmp = dane.getCenaKup("TO04");
            if (tmp == "-1") { tmp = "niemożliwe"; }
            miesoKupno.Text = tmp;
            miesoSprzedarz.Text = dane.getCenaSp("TO04");

            perlaKarawana.Text = przekaznik.IleTowaru(idk, "TO07");
            perlaMiasto.Text = dane.getIle("TO07");
            tmp = dane.getCenaKup("TO07");
            if (tmp == "-1") { tmp = "niemożliwe"; }
            perlaKupno.Text = tmp;
            perlaSprzedarz.Text = dane.getCenaSp("TO07");

            skoraKarawana.Text = przekaznik.IleTowaru(idk, "TO10");
            skoraMiasto.Text = dane.getIle("TO10");
            tmp = dane.getCenaKup("TO10");
            if (tmp == "-1") { tmp = "niemożliwe"; }
            skoraKupno.Text = tmp;
            skoraSprzedarz.Text = dane.getCenaSp("TO10");

            alchemiaKarawana.Text = przekaznik.IleTowaru(idk, "TO11");
            alchemiaMiasto.Text = dane.getIle("TO11");
            tmp = dane.getCenaKup("TO11");
            if (tmp == "-1") { tmp = "niemożliwe"; }
            alchemiaKupno.Text = tmp;
            alchemiaSprzedarz.Text = dane.getCenaSp("TO11");

            przyprawyKarawana.Text = przekaznik.IleTowaru(idk, "TO08");
            przyprawyMiasto.Text = dane.getIle("TO08");
            tmp = dane.getCenaKup("TO08");
            if (tmp == "-1") { tmp = "niemożliwe"; }
            przyprawyKupno.Text = tmp;
            przyprawySprzedarz.Text = dane.getCenaSp("TO08");
            
        }


        private void sprzedaz(string IDkarawana, string IDmiasto, string IDtowar, int ile, int cena) {
            string mess = handel.sprzedaj(IDkarawana, IDmiasto, IDtowar, ile, cena);
            if (mess == "done")
            {
                odswiez();
                MainWindow.odzwierzGlowne();
            }
            else
            {
                Errors er = new Errors(mess);
                er.Show();
            }
        }
        private void kupowanie(string IDkarawana, string IDmiasto, string IDtowar, int ile, int cena) {
            string mess = handel.kup(IDkarawana, IDmiasto, IDtowar, ile, cena);
            if (mess == "done")
            {
                odswiez();
                MainWindow.odzwierzGlowne();
            }
            else
            {
                Errors er = new Errors(mess);
                er.Show();
            }
        }
        private void exitZ_Click(object sender, RoutedEventArgs e) //zamknięcie okna
        {
            Close();
            GamesWindow.odswiezKarawane();           
        }


        //funkcje obsługujące przyciski
        private void buttonT1_Click(object sender, RoutedEventArgs e)//tkanina sprzedaj
        {
            int ile = Convert.ToInt32(tkan.Text);
            int cena = Convert.ToInt32(tkaninaSprzedarz.Text);
            sprzedaz(idk, idm, "TO03", ile, cena);
        }

        private void buttonT2_Click(object sender, RoutedEventArgs e)//tkanina -
        {
            int x;
            x = Convert.ToInt32(tkan.Text);
            if (x > 0) { x--; }
            tkan.Text = x.ToString();
        }

        private void buttonT3_Click(object sender, RoutedEventArgs e)//tkanina kup
        {
            int ile = Convert.ToInt32(tkan.Text);
            int cena;
            string tmp = tkaninaKupno.Text;
            if (tmp == "niemożliwe")
            {
                cena = -1;
            }
            else
            {
                cena = Convert.ToInt32(tmp);
            }
            kupowanie(idk, idm, "TO03", ile, cena);
        }

        private void buttonT4_Click(object sender, RoutedEventArgs e)//tkanina +
        {
            int x;
            x = Convert.ToInt32(tkan.Text);
            x++;
            tkan.Text = x.ToString();
        }

        private void buttonW1_Click(object sender, RoutedEventArgs e)//wino sprzedaj
        {
            int ile = Convert.ToInt32(wino.Text);
            int cena = Convert.ToInt32(winoSprzedarz.Text);
            sprzedaz(idk, idm, "TO09", ile, cena);
        }

        private void buttonW2_Click(object sender, RoutedEventArgs e)//wino -
        {
            int x;
            x = Convert.ToInt32(wino.Text);
            if (x > 0) { x--; }
            wino.Text = x.ToString();
        }

        private void buttonW3_Click(object sender, RoutedEventArgs e)//wino kup
        {
            int ile = Convert.ToInt32(wino.Text);
            int cena;
            string tmp = winoKupno.Text;
            if (tmp == "niemożliwe")
            {
                cena = -1;
            }
            else
            {
                cena = Convert.ToInt32(tmp);
            }
            kupowanie(idk, idm, "TO09", ile, cena);
        }

        private void buttonW4_Click(object sender, RoutedEventArgs e)//wino +
        {
            int x;
            x = Convert.ToInt32(wino.Text);
            x++;
            wino.Text = x.ToString();
        }

        private void buttonB1_Click(object sender, RoutedEventArgs e)//bron sprzedaj
        {
            int ile = Convert.ToInt32(bron.Text);
            int cena = Convert.ToInt32(bronSprzedarz.Text);
            sprzedaz(idk, idm, "TO06", ile, cena);
        }

        private void buttonB2_Click(object sender, RoutedEventArgs e)//bron -
        {
            int x;
            x = Convert.ToInt32(bron.Text);
            if (x > 0) { x--; }
            bron.Text = x.ToString();
        }

        private void buttonB3_Click(object sender, RoutedEventArgs e)//bron kup
        {
            int ile = Convert.ToInt32(bron.Text);
            int cena;
            string tmp = bronKupno.Text;
            if (tmp == "niemożliwe")
            {
                cena = -1;
            }
            else
            {
                cena = Convert.ToInt32(tmp);
            }
            kupowanie(idk, idm, "TO06", ile, cena);
        }

        private void buttonB4_Click(object sender, RoutedEventArgs e)//bron +
        {
            int x;
            x = Convert.ToInt32(bron.Text);
            x++;
            bron.Text = x.ToString();
        }

        private void buttonC1_Click(object sender, RoutedEventArgs e)//chleb sprzedaj
        {
            int ile = Convert.ToInt32(hleb.Text);
            int cena = Convert.ToInt32(chlebSprzedarz.Text);
            sprzedaz(idk, idm, "TO05", ile, cena);
        }

        private void buttonC2_Click(object sender, RoutedEventArgs e)//chleb -
        {
            int x;
            x = Convert.ToInt32(hleb.Text);
            if (x > 0) { x--; }
            hleb.Text = x.ToString();
        }

        private void buttonC3_Click(object sender, RoutedEventArgs e)//chleb kup
        {
            int ile = Convert.ToInt32(hleb.Text);
            int cena;
            string tmp = chlebKupno.Text;
            if (tmp == "niemożliwe")
            {
                cena = -1;
            }
            else
            {
                cena = Convert.ToInt32(tmp);
            }
            kupowanie(idk, idm, "TO05", ile, cena);
        }

        private void buttonC4_Click(object sender, RoutedEventArgs e)//chleb +
        {
            int x;
            x = Convert.ToInt32(hleb.Text);
            x++;
            hleb.Text = x.ToString();
        }

        private void buttonD1_Click(object sender, RoutedEventArgs e)//drewno sprzedaj
        {
            int ile = Convert.ToInt32(brondrz.Text);
            int cena = Convert.ToInt32(drewnoSprzedarz.Text);
            sprzedaz(idk, idm, "TO01", ile, cena);
        }

        private void buttonD2_Click(object sender, RoutedEventArgs e)//drewno -
        {
            int x;
            x = Convert.ToInt32(brondrz.Text);
            if (x > 0) { x--; }
            brondrz.Text = x.ToString();
        }

        private void buttonD3_Click(object sender, RoutedEventArgs e)//drewno kup
        {
            int ile = Convert.ToInt32(brondrz.Text);
            int cena;
            string tmp = drewnoKupno.Text;
            if (tmp == "niemożliwe")
            {
                cena = -1;
            }
            else
            {
                cena = Convert.ToInt32(tmp);
            }
            kupowanie(idk, idm, "TO01", ile, cena);
        }

        private void buttonD4_Click(object sender, RoutedEventArgs e)//drewno +
        {
            int x;
            x = Convert.ToInt32(brondrz.Text);
            x++;
            brondrz.Text = x.ToString();
        }

        private void buttonJ1_Click(object sender, RoutedEventArgs e)//jabłko sprzedaj
        {
            int ile = Convert.ToInt32(jabl.Text);
            int cena = Convert.ToInt32(jablkoSprzedarz.Text);
            sprzedaz(idk, idm, "TO02", ile, cena);
        }

        private void buttonJ2_Click(object sender, RoutedEventArgs e)//jabłko -
        {
            int x;
            x = Convert.ToInt32(jabl.Text);
            if (x > 0) { x--; }
            jabl.Text = x.ToString();
        }

        private void buttonJ3_Click(object sender, RoutedEventArgs e)//jabłko kup
        {
            int ile = Convert.ToInt32(jabl.Text);
            int cena;
            string tmp = jablkoKupno.Text;
            if (tmp == "niemożliwe")
            {
                cena = -1;
            }
            else
            {
                cena = Convert.ToInt32(tmp);
            }
            kupowanie(idk, idm, "TO02", ile, cena);
        }

        private void buttonJ4_Click(object sender, RoutedEventArgs e)//jabłko +
        {
            int x;
            x = Convert.ToInt32(jabl.Text);
            x++;
            jabl.Text = x.ToString();
        }

        private void buttonM1_Click(object sender, RoutedEventArgs e)//mięso sprzedaj
        {
            int ile = Convert.ToInt32(mies.Text);
            int cena = Convert.ToInt32(miesoSprzedarz.Text);
            sprzedaz(idk, idm, "TO04", ile, cena);
        }

        private void buttonM2_Click(object sender, RoutedEventArgs e)//mięso -
        {
            int x;
            x = Convert.ToInt32(mies.Text);
            if (x > 0) { x--; }
            mies.Text = x.ToString();
        }

        private void buttonM3_Click(object sender, RoutedEventArgs e)//mięso kup
        {
            int ile = Convert.ToInt32(mies.Text);
            int cena;
            string tmp = miesoKupno.Text;
            if (tmp == "niemożliwe")
            {
                cena = -1;
            }
            else
            {
                cena = Convert.ToInt32(tmp);
            }
            kupowanie(idk, idm, "TO04", ile, cena);
        }

        private void buttonM4_Click(object sender, RoutedEventArgs e)//mięso +
        {
            int x;
            x = Convert.ToInt32(mies.Text);
            x++;
            mies.Text = x.ToString();
        }

        private void buttonP1_Click(object sender, RoutedEventArgs e)//perła sprzedaj
        {
            int ile = Convert.ToInt32(perl.Text);
            int cena = Convert.ToInt32(perlaSprzedarz.Text);
            sprzedaz(idk, idm, "TO07", ile, cena);
        }

        private void buttonP2_Click(object sender, RoutedEventArgs e)//perła -
        {
            int x;
            x = Convert.ToInt32(perl.Text);
            if (x > 0) { x--; }
            perl.Text = x.ToString();
        }

        private void buttonP3_Click(object sender, RoutedEventArgs e)//perła kup
        {
            int ile = Convert.ToInt32(perl.Text);
            int cena;
            string tmp = perlaKupno.Text;
            if (tmp == "niemożliwe")
            {
                cena = -1;
            }
            else
            {
                cena = Convert.ToInt32(tmp);
            }
            kupowanie(idk, idm, "TO07", ile, cena);
        }

        private void buttonP4_Click(object sender, RoutedEventArgs e)//perła +
        {
            int x;
            x = Convert.ToInt32(perl.Text);
            x++;
            perl.Text = x.ToString();
        }

        private void buttonS1_Click(object sender, RoutedEventArgs e)//skóra sprzedaj
        {
            int ile = Convert.ToInt32(skur.Text);
            int cena = Convert.ToInt32(skoraSprzedarz.Text);
            sprzedaz(idk, idm, "TO10", ile, cena);
        }

        private void buttonS2_Click(object sender, RoutedEventArgs e)//skóra -
        {
            int x;
            x = Convert.ToInt32(skur.Text);
            if (x > 0) { x--; }
            skur.Text = x.ToString();
        }

        private void buttonS3_Click(object sender, RoutedEventArgs e)//skóra kup
        {
            int ile = Convert.ToInt32(skur.Text);
            int cena;
            string tmp = skoraKupno.Text;
            if (tmp == "niemożliwe")
            {
                cena = -1;
            }
            else
            {
                cena = Convert.ToInt32(tmp);
            }
            kupowanie(idk, idm, "TO10", ile, cena);
        }

        private void buttonS4_Click(object sender, RoutedEventArgs e)//skóra +
        {
            int x;
            x = Convert.ToInt32(skur.Text);
            x++;
            skur.Text = x.ToString();
        }

        private void buttonA1_Click(object sender, RoutedEventArgs e)//alchemia sprzedaj
        {
            int ile = Convert.ToInt32(srodki.Text);
            int cena = Convert.ToInt32(alchemiaSprzedarz.Text);
            sprzedaz(idk, idm, "TO11", ile, cena);
        }

        private void buttonA2_Click(object sender, RoutedEventArgs e)//alchemia -
        {
            int x;
            x = Convert.ToInt32(srodki.Text);
            if (x > 0) { x--; }
            srodki.Text = x.ToString();
        }

        private void buttonA3_Click(object sender, RoutedEventArgs e)//alchemia kup
        {
            int ile = Convert.ToInt32(srodki.Text);
            int cena;
            string tmp = alchemiaKupno.Text;
            if (tmp == "niemożliwe")
            {
                cena = -1;
            }
            else
            {
                cena = Convert.ToInt32(tmp);
            }
            kupowanie(idk, idm, "TO11", ile, cena);
        }

        private void buttonA4_Click(object sender, RoutedEventArgs e)//alchemia +
        {
            int x;
            x = Convert.ToInt32(srodki.Text);
            x++;
            srodki.Text = x.ToString();
        }

        private void buttonX1_Click(object sender, RoutedEventArgs e)//przyprawy sprzedaj
        {
            int ile = Convert.ToInt32(przyp.Text);
            int cena = Convert.ToInt32(przyprawySprzedarz.Text);
            sprzedaz(idk, idm, "TO08", ile, cena);
        }

        private void buttonX2_Click(object sender, RoutedEventArgs e)//przyprawy -
        {
            int x;
            x = Convert.ToInt32(przyp.Text);
            if (x > 0) { x--; }
            przyp.Text = x.ToString();
        }

        private void buttonX3_Click(object sender, RoutedEventArgs e)//przyprawy kup
        {
            int ile = Convert.ToInt32(przyp.Text);
            int cena;
            string tmp = przyprawyKupno.Text;
            if (tmp == "niemożliwe")
            {
                cena = -1;
            }
            else
            {
                cena = Convert.ToInt32(tmp);
            }
            kupowanie(idk, idm, "TO08", ile, cena);
        }

        private void buttonX4_Click(object sender, RoutedEventArgs e)//przyprawy +
        {
            int x;
            x = Convert.ToInt32(przyp.Text);
            x++;
            przyp.Text = x.ToString();
        }

        
    }

}
