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
        
        public Zakupy(string a)
        {
            idk = a;
            idm = przekaznik.lok(idk);
            InitializeComponent();       
            odswiez();
        }

        public void odswiez()
        {
            odswiezWino();
            odswiezAlchemie();
            odswiezBron();
            odswiezChleb();
            odswiezDrewno();
            odswiezJablko();
            odswiezMieso();
            odswiezPerle();
            odswiezPrzyprawe();
            odswiezSkory();
            odswiezTkanine();
        }

        public void odswiezDrewno()
        {
            drewnoKarawana.Text = przekaznik.IleTowaruKarawana(idk, "TO01").ToString();
            drewnoMiasto.Text = przekaznik.IleTowaruMiasto(idm, "TO01").ToString();
            tow tmp = new tow("TO01", idm);
            tmp.policzCena();
            drewnoSprzedarz.Text = tmp.DajCeneSp().ToString();
            int x = tmp.DajCeneKup();
            if (x == -1)
            {
                drewnoKupno.Text = "niemożliwe";
            }
            else
            {
                drewnoKupno.Text = x.ToString();
            }
        }
        public void odswiezMieso()
        {
            miesoKarawana.Text = przekaznik.IleTowaruKarawana(idk, "TO04").ToString();
            miesoMiasto.Text = przekaznik.IleTowaruMiasto(idm, "TO04").ToString();
            tow tmp = new tow("TO04", idm);
            tmp.policzCena();
            miesoSprzedarz.Text = tmp.DajCeneSp().ToString();
            int x = tmp.DajCeneKup();
            if (x == -1)
            {
                miesoKupno.Text = "niemożliwe";
            }
            else
            {
                miesoKupno.Text = x.ToString();
            }
        }
        public void odswiezChleb()
        {
            chlebKarawana.Text = przekaznik.IleTowaruKarawana(idk, "TO05").ToString();
            chlebMiasto.Text = przekaznik.IleTowaruMiasto(idm, "TO05").ToString();
            tow tmp = new tow("TO05", idm);
            tmp.policzCena();
            chlebSprzedarz.Text = tmp.DajCeneSp().ToString();
            int x = tmp.DajCeneKup();
            if (x == -1)
            {
                chlebKupno.Text = "niemożliwe";
            }
            else
            {
                chlebKupno.Text = x.ToString();
            }
        }
        public void odswiezJablko()
        {
            jablkoKarawana.Text = przekaznik.IleTowaruKarawana(idk, "TO02").ToString();
            jablkoMiasto.Text = przekaznik.IleTowaruMiasto(idm, "TO02").ToString();
            tow tmp = new tow("TO02", idm);
            tmp.policzCena();
            jablkoSprzedarz.Text = tmp.DajCeneSp().ToString();
            int x = tmp.DajCeneKup();
            if (x == -1)
            {
                jablkoKupno.Text = "niemożliwe";
            }
            else
            {
                jablkoKupno.Text = x.ToString();
            }
        }
        public void odswiezBron()
        {
            bronKarawana.Text = przekaznik.IleTowaruKarawana(idk, "TO06").ToString();
            bronMiasto.Text = przekaznik.IleTowaruMiasto(idm, "TO06").ToString();
            tow tmp = new tow("TO06", idm);
            tmp.policzCena();
            bronSprzedarz.Text = tmp.DajCeneSp().ToString();
            int x = tmp.DajCeneKup();
            if (x == -1)
            {
                bronKupno.Text = "niemożliwe";
            }
            else
            {
                bronKupno.Text = x.ToString();
            }
        }
        public void odswiezWino()
        {
            winoKarawana.Text = przekaznik.IleTowaruKarawana(idk, "TO09").ToString();
            winoMiasto.Text = przekaznik.IleTowaruMiasto(idm, "TO09").ToString();
            tow tmp = new tow("TO09", idm);
            tmp.policzCena();
            winoSprzedarz.Text = tmp.DajCeneSp().ToString();
            int x = tmp.DajCeneKup();
            if (x == -1)
            {
                winoKupno.Text = "niemożliwe";
            }
            else
            {
                winoKupno.Text = x.ToString();
            }
        }
        public void odswiezAlchemie()
        {
            alchemiaKarawana.Text = przekaznik.IleTowaruKarawana(idk, "TO11").ToString();
            alchemiaMiasto.Text = przekaznik.IleTowaruMiasto(idm, "TO11").ToString();
            tow tmp = new tow("TO11", idm);
            tmp.policzCena();
            alchemiaSprzedarz.Text = tmp.DajCeneSp().ToString();
            int x = tmp.DajCeneKup();
            if (x == -1)
            {
                alchemiaKupno.Text = "niemożliwe";
            }
            else
            {
                alchemiaKupno.Text = x.ToString();
            }

        }
        public void odswiezPrzyprawe()
        {
            przyprawyKarawana.Text = przekaznik.IleTowaruKarawana(idk, "TO08").ToString();
            przyprawyMiasto.Text = przekaznik.IleTowaruMiasto(idm, "TO08").ToString();
            tow tmp = new tow("TO08", idm);
            tmp.policzCena();
            przyprawySprzedarz.Text = tmp.DajCeneSp().ToString();
            int x = tmp.DajCeneKup();
            if (x == -1)
            {
                przyprawyKupno.Text = "niemożliwe";
            }
            else
            {
                przyprawyKupno.Text = x.ToString();
            }
            
            
        }
        public void odswiezTkanine()
        {
            tkaninaKarawana.Text = przekaznik.IleTowaruKarawana(idk, "TO03").ToString();
            tkaninaMiasto.Text = przekaznik.IleTowaruMiasto(idm, "TO03").ToString();
            tow tmp = new tow("TO03", idm);
            tmp.policzCena();
            tkaninaSprzedarz.Text = tmp.DajCeneSp().ToString();
            int x = tmp.DajCeneKup();
            if (x == -1)
            {
                tkaninaKupno.Text = "niemożliwe";
            }
            else
            {
                tkaninaKupno.Text = x.ToString();
            }
        }
        public void odswiezSkory()
        {
            skoraKarawana.Text = przekaznik.IleTowaruKarawana(idk, "TO10").ToString();
            skoraMiasto.Text = przekaznik.IleTowaruMiasto(idm, "TO10").ToString();
            tow tmp = new tow("TO10", idm);
            tmp.policzCena();
            skoraSprzedarz.Text = tmp.DajCeneSp().ToString();
            int x = tmp.DajCeneKup();
            if (x == -1)
            {
                skoraKupno.Text = "niemożliwe";
            }
            else
            {
                skoraKupno.Text = x.ToString();
            }
        }
        public void odswiezPerle()
        {
            perlaKarawana.Text = przekaznik.IleTowaruKarawana(idk, "TO07").ToString();
            perlaMiasto.Text = przekaznik.IleTowaruMiasto(idm, "TO07").ToString();
            tow tmp = new tow("TO07", idm);
            tmp.policzCena();
            perlaSprzedarz.Text = tmp.DajCeneSp().ToString();
            int x = tmp.DajCeneKup();
            if (x == -1)
            {
                perlaKupno.Text = "niemożliwe";
            }
            else
            {
                perlaKupno.Text = x.ToString();
            }
        }

        private bool sprzedaz(string IDkarawana, string IDmiasto, string IDtowar, int ile, int cena) {
            string mess = handel.sprzedaj(IDkarawana, IDmiasto, IDtowar, ile, cena);
            if (mess == "done")
            {
                MainWindow.odzwierzGlowne();
                return true;
            }
            else
            {
                Errors er = new Errors(mess);
                er.Show();
                return false;
            }
        }
        private bool kupowanie(string IDkarawana, string IDmiasto, string IDtowar, int ile, int cena) {
            string mess = handel.kup(IDkarawana, IDmiasto, IDtowar, ile, cena);
            if (mess == "done")
            {
                MainWindow.odzwierzGlowne();
                return true;
            }
            else
            {
                Errors er = new Errors(mess);
                er.Show();
                return false;
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
            bool czy = sprzedaz(idk, idm, "TO03", ile, cena);
            if (czy == true) { odswiezTkanine(); }
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
            bool czy = kupowanie(idk, idm, "TO03", ile, cena);
            if (czy == true) { odswiezTkanine(); }
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
            bool czy = sprzedaz(idk, idm, "TO09", ile, cena);
            if (czy == true) { odswiezWino(); }
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
            bool czy = kupowanie(idk, idm, "TO09", ile, cena);
            if (czy == true) { odswiezWino(); }
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
            bool czy = sprzedaz(idk, idm, "TO06", ile, cena);
            if (czy == true) { odswiezBron(); }
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
            bool czy = kupowanie(idk, idm, "TO06", ile, cena);
            if (czy == true) { odswiezBron(); }
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
            bool czy = sprzedaz(idk, idm, "TO05", ile, cena);
            if (czy == true) { odswiezChleb(); }
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
            bool czy = kupowanie(idk, idm, "TO05", ile, cena);
            if (czy == true) { odswiezChleb(); }
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
            bool czy = sprzedaz(idk, idm, "TO01", ile, cena);
            if (czy == true) { odswiezDrewno(); }
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
            bool czy = kupowanie(idk, idm, "TO01", ile, cena);
            if (czy == true) { odswiezDrewno(); }
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
            bool czy = sprzedaz(idk, idm, "TO02", ile, cena);
            if (czy == true) { odswiezJablko(); }
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
            bool czy = kupowanie(idk, idm, "TO02", ile, cena);
            if (czy == true) { odswiezJablko(); }
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
            bool czy = sprzedaz(idk, idm, "TO04", ile, cena);
            if (czy == true) { odswiezMieso(); }
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
            bool czy = kupowanie(idk, idm, "TO04", ile, cena);
            if (czy == true) { odswiezMieso(); }
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
            bool czy = sprzedaz(idk, idm, "TO07", ile, cena);
            if (czy == true) { odswiezPerle(); }
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
            bool czy = kupowanie(idk, idm, "TO07", ile, cena);
            if (czy == true) { odswiezPerle(); }
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
            bool czy = sprzedaz(idk, idm, "TO10", ile, cena);
            if (czy == true) { odswiezSkory(); }
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
            bool czy = kupowanie(idk, idm, "TO10", ile, cena);
            if (czy == true) { odswiezSkory(); }
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
            bool czy = sprzedaz(idk, idm, "TO11", ile, cena);
            if (czy == true) { odswiezAlchemie(); }
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
            bool czy = kupowanie(idk, idm, "TO11", ile, cena);
            if (czy == true) { odswiezAlchemie(); }
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
            bool czy = sprzedaz(idk, idm, "TO08", ile, cena);
            if (czy == true) { odswiezPrzyprawe(); }
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
            bool czy = kupowanie(idk, idm, "TO08", ile, cena);
            if (czy == true) { odswiezPrzyprawe(); }
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
