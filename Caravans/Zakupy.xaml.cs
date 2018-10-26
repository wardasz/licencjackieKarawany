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
    /// <summary>
    /// Логика взаимодействия для Zakupy.xaml
    /// </summary>
    public partial class Zakupy : Window
    {
        //ID karawany i miasta-puki co przypisane odgórnie, potem się zrobi by jakoś szukało tych danych
        private static string idk;
        private static string idm;

        //wsadza dane do powyższych zmiennych (włącznie z wywowałem funckji policzenia cen)
        private static ceny dane;
        private string kasa;

        //lista cen i ilości: IK-ilość w karawanie, IM-ilość w mieście, CK-cena kupna, CS-cena sprzedarzy

        private string tkanIK;
        private string tkanIM;
        private string tkanCK;
        private string tkanCS;

        private string winoIK;
        private string winoIM;
        private string winoCK;
        private string winoCS;

        private string bronIK;
        private string bronIM;
        private string bronCK;
        private string bronCS;

        private string chlebIK;
        private string chlebIM;
        private string chlebCK;
        private string chlebCS;

        private string drewIK;
        private string drewIM;
        private string drewCK;
        private string drewCS;

        private string jablIK;
        private string jablIM;
        private string jablCK;
        private string jablCS;

        private string miesoIK;
        private string miesoIM;
        private string miesoCK;
        private string miesoCS;

        private string perlIK;
        private string perlIM;
        private string perlCK;
        private string perlCS;

        private string skrIK;
        private string skrIM;
        private string skrCK;
        private string skrCS;

        private string alchIK;
        private string alchIM;
        private string alchCK;
        private string alchCS;

        private string przypIK;
        private string przypIM;
        private string przypCK;
        private string przypCS;

        public void zassaj()
        {
            idm = przekaznik.lok(idk);
            dane = new ceny(idm);
            kasa = przekaznik.DajKaseS();

            tkanIK = przekaznik.IleTowaru(idk, "TO03");
            tkanIM = dane.getIle("TO03");
            tkanCK = dane.getCenaKup("TO03");
            if (tkanCK == "-1") { tkanCK = "niemożliwe"; }
            tkanCS = dane.getCenaSp("TO03");

            winoIK = przekaznik.IleTowaru(idk, "TO09");
            winoIM = dane.getIle("TO09");
            winoCK = dane.getCenaKup("TO09");
            if (winoCK == "-1") { winoCK = "niemożliwe"; }
            winoCS = dane.getCenaSp("TO09");

            bronIK = przekaznik.IleTowaru(idk, "TO06");
            bronIM = dane.getIle("TO06");
            bronCK = dane.getCenaKup("TO06");
            if (bronCK == "-1") { bronCK = "niemożliwe"; }
            bronCS = dane.getCenaSp("TO06");

            chlebIK = przekaznik.IleTowaru(idk, "TO05");
            chlebIM = dane.getIle("TO05");
            chlebCK = dane.getCenaKup("TO05");
            if (chlebCK == "-1") { chlebCK = "niemożliwe"; }
            chlebCS = dane.getCenaSp("TO05");

            drewIK = przekaznik.IleTowaru(idk, "TO01");
            drewIM = dane.getIle("TO01");
            drewCK = dane.getCenaKup("TO01");
            if (drewCK == "-1") { drewCK = "niemożliwe"; }
            drewCS = dane.getCenaSp("TO01");

            jablIK = przekaznik.IleTowaru(idk, "TO02");
            jablIM = dane.getIle("TO02");
            jablCK = dane.getCenaKup("TO02");
            if (jablCK == "-1") { jablCK = "niemożliwe"; }
            jablCS = dane.getCenaSp("TO02");

            miesoIK = przekaznik.IleTowaru(idk, "TO04");
            miesoIM = dane.getIle("TO04");
            miesoCK = dane.getCenaKup("TO04");
            if (miesoCK == "-1") { miesoCK = "niemożliwe"; }
            miesoCS = dane.getCenaSp("TO04");

            perlIK = przekaznik.IleTowaru(idk, "TO07");
            perlIM = dane.getIle("TO07");
            perlCK = dane.getCenaKup("TO07");
            if (perlCK == "-1") { perlCK = "niemożliwe"; }
            perlCS = dane.getCenaSp("TO07");

            skrIK = przekaznik.IleTowaru(idk, "TO10");
            skrIM = dane.getIle("TO10");
            skrCK = dane.getCenaKup("TO10");
            if (skrCK == "-1") { skrCK = "niemożliwe"; }
            skrCS = dane.getCenaSp("TO10");

            alchIK = przekaznik.IleTowaru(idk, "TO11");
            alchIM = dane.getIle("TO11");
            alchCK = dane.getCenaKup("TO11");
            if (alchCK == "-1") { alchCK = "niemożliwe"; }
            alchCS = dane.getCenaSp("TO11");

            przypIK = przekaznik.IleTowaru(idk, "TO08");
            przypIM = dane.getIle("TO08");
            przypCK = dane.getCenaKup("TO08");
            if (przypCK == "-1") { przypCK = "niemożliwe"; }
            przypCS = dane.getCenaSp("TO08");


            iltkaninatour.Text = tkanIM;
            iltkaninawag.Text = tkanIK;
            cenatkanina.Text = tkanCK;
            sptkanina.Text = tkanCS;
            ilwinowag.Text = winoIK;
            cenawino.Text = winoCK;
            spWino.Text = winoCS;
            ilwinotour.Text = winoIM;
            ilbronwag.Text = bronIK;
            cenabron.Text = bronCK;
            spbron.Text = bronCS;
            ilbrontour.Text = bronIM;
            ilchlebwag.Text = chlebIK;
            cenachleb.Text = chlebCK;
            spchleb.Text = chlebCS;
            ilchlebtour.Text = chlebIM;
            iltreewag.Text = drewIK;
            cenatree.Text = drewCK;
            spdrzewo.Text = drewCS;
            iltreetour.Text = drewIM;
            iljabwagt.Text = jablIK;
            cenahleb.Text = jablCK;
            spjab.Text = jablCS;
            iljabtour.Text = jablIM;
            ilmeatwag.Text = miesoIK;
            cenameate.Text = miesoCK;
            sptmieso.Text = miesoCS;
            ilmeattour.Text = miesoIM;
            ilperlawag.Text = perlIK;
            cenaperla1.Text = perlCK;
            spperla1.Text = perlCS;
            ilperlatour1.Text = perlIM;
            ilskorawag.Text = skrIK;
            cenaskora.Text = skrCK;
            spskora.Text = skrCS;
            ilskoratour.Text = skrIM;
            nowy1.Text = alchIK;
            cenanafta.Text = alchCK;
            spnafta.Text = alchCS;
            ilnaftatour.Text = alchIM;
            ilprzyprawywag.Text = przypIK;
            cenaprzyprawy.Text = przypCK;
            spprzyprawy.Text = przypCS;
            ilprzyprawytour.Text = przypIM;


        }


        //tworzenie dodatkowych zmiennych-obiektów odpowiedzialnych za wyświelanie danych
        public string KASA
        {
            get { return kasa; }
            set { kasa = value; }
        }

        public string ileTkanKar
        {
            get { return tkanIK; }
            set { tkanIK = value; }
        }

        public string ileWinoKar
        {
            get { return winoIK; }
            set { winoIK = value; }
        }

        public string ileBronKar
        {
            get { return bronIK; }
            set { bronIK = value; }
        }

        public string ileChlebKar
        {
            get { return chlebIK; }
            set { chlebIK = value; }
        }

        public string ileDrewKar
        {
            get { return drewIK; }
            set { drewIK = value; }
        }

        public string ileJablKar
        {
            get { return jablIK; }
            set { jablIK = value; }
        }

        public string ileMiesKar
        {
            get { return miesoIK; }
            set { miesoIK = value; }
        }

        public string ilePelrKar
        {
            get { return perlIK; }
            set { perlIK = value; }
        }

        public string ileSkorKar
        {
            get { return skrIK; }
            set { skrIK = value; }
        }

        public string ileAlchKar
        {
            get { return alchIK; }
            set { alchIK = value; }
        }

        public string ilePrzypKar
        {
            get { return przypIK; }
            set { przypIK = value; }
        }

        public string ileTkanMi
        {
            get { return tkanIM; }
            set { tkanIM = value; }
        }

        public string ileWinoMi
        {
            get { return winoIM; }
            set { winoIM = value; }
        }

        public string ileBronMi
        {
            get { return bronIM; }
            set { bronIM = value; }
        }

        public string ileChlebMi
        {
            get { return chlebIM; }
            set { chlebIM = value; }
        }

        public string ileDrewMi
        {
            get { return drewIM; }
            set { drewIM = value; }
        }

        public string ileJablMi
        {
            get { return jablIM; }
            set { jablIM = value; }
        }

        public string ileMiesMi
        {
            get { return miesoIM; }
            set { miesoIM = value; }
        }

        public string ilePerlMi
        {
            get { return perlIM; }
            set { perlIM = value; }
        }

        public string ileSkorMi
        {
            get { return skrIM; }
            set { skrIM = value; }
        }

        public string ileAlchMi
        {
            get { return alchIM; }
            set { alchIM = value; }
        }

        public string ilePrzypMi
        {
            get { return przypIM; }
            set { przypIM = value; }
        }

        public string cenaTkanSp
        {
            get { return tkanCS; }
            set { tkanCS = value; }
        }

        public string cenaWinoSp
        {
            get { return winoCS; }
            set { winoCS = value; }
        }

        public string cenaBronSp
        {
            get { return bronCS; }
            set { bronCS = value; }
        }

        public string cenaChlebSp
        {
            get { return chlebCS; }
            set { chlebCS = value; }
        }

        public string cenaDrewSp
        {
            get { return drewCS; }
            set { drewCS = value; }
        }

        public string cenaJablSp
        {
            get { return jablCS; }
            set { jablCS = value; }
        }

        public string cenaMiesSp
        {
            get { return miesoCS; }
            set { miesoCS = value; }
        }

        public string cenaPerlSp
        {
            get { return perlCS; }
            set { perlCS = value; }
        }

        public string cenaSkorSp
        {
            get { return skrCS; }
            set { skrCS = value; }
        }

        public string cenaAlchSp
        {
            get { return alchCS; }
            set { alchCS = value; }
        }

        public string cenaPrzypSp
        {
            get { return przypCS; }
            set { przypCS = value; }
        }

        public string cenaTkanKup
        {
            get { return tkanCK; }
            set { tkanCK = value; }
        }

        public string cenaWinoKup
        {
            get { return winoCK; }
            set { winoCK = value; }
        }

        public string cenaBronKup
        {
            get { return bronCK; }
            set { bronCK = value; }
        }

        public string cenaChlebKup
        {
            get { return chlebCK; }
            set { chlebCK = value; }
        }

        public string cenaDrewKup
        {
            get { return drewCK; }
            set { drewCK = value; }
        }

        public string cenaJablKup
        {
            get { return jablCK; }
            set { jablCK = value; }
        }

        public string cenaMiesKup
        {
            get { return miesoCK; }
            set { miesoCK = value; }
        }

        public string cenaPerlKup
        {
            get { return perlCK; }
            set { perlCK = value; }
        }

        public string cenaSkorKup
        {
            get { return skrCK; }
            set { skrCK = value; }
        }

        public string cenaAlchKup
        {
            get { return alchCK; }
            set { alchCK = value; }
        }

        public string cenaPrzypKup
        {
            get { return przypCK; }
            set { przypCK = value; }
        }
        

        //ważne-inicjalizacja jeśli texbox ma wyświetlać coś co nie jest z góry przypisane, trzeba go tu zainicjalizować
        public Zakupy(string a)
        {
            idk = a;
            InitializeComponent();           
            nowy1.DataContext = this;
            zassaj();
        }

        //w te funkcje należy wkleić kod od kamila
        //WAŻNE-przed faktyczną wymianą należy sprawdzić czy ilość towaru i kasa sie zgadzają-by nie było ujemnych towarów w mieście
        //Muszą także zmieniać wyświetlana ilość towaru (nie wiem czy zmiana w bazie danych starczy-być może trzeba dodatkowo tu zmienić wartości w liście cen i ilości)
        private void sprzedaz(string IDkarawana, string IDmiasto, string IDtowar, int ile, int cena) {
            string mess = handel.sprzedaj(IDkarawana, IDmiasto, IDtowar, ile, cena);
            if (mess == "done")
            {
                zassaj();
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
                zassaj();
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
            int cena = Convert.ToInt32(tkanCS);
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
            if (tkanCK == "niemożliwe")
            {
                cena = -1;
            }
            else
            {
                cena = Convert.ToInt32(tkanCK);
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
            int cena = Convert.ToInt32(winoCS);
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
            if (winoCK == "niemożliwe")
            {
                cena = -1;
            }
            else
            {
                cena = Convert.ToInt32(winoCK);
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
            int cena = Convert.ToInt32(bronCS);
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
            if (bronCK == "niemożliwe")
            {
                cena = -1;
            }
            else
            {
                cena = Convert.ToInt32(bronCK);
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
            int cena = Convert.ToInt32(chlebCS);
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
            if (chlebCK == "niemożliwe")
            {
                cena = -1;
            }
            else
            {
                cena = Convert.ToInt32(chlebCK);
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
            int cena = Convert.ToInt32(drewCS);
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
            if (drewCK == "niemożliwe")
            {
                cena = -1;
            }
            else
            {
                cena = Convert.ToInt32(drewCK);
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
            int cena = Convert.ToInt32(jablCS);
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
            if (jablCK == "niemożliwe")
            {
                cena = -1;
            }
            else
            {
                cena = Convert.ToInt32(jablCK);
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
            int cena = Convert.ToInt32(miesoCS);
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
            if (miesoCK == "niemożliwe")
            {
                cena = -1;
            }
            else
            {
                cena = Convert.ToInt32(miesoCK);
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
            int cena = Convert.ToInt32(perlCS);
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
            if (perlCK == "niemożliwe")
            {
                cena = -1;
            }
            else
            {
                cena = Convert.ToInt32(perlCK);
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
            int cena = Convert.ToInt32(skrCS);
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
            if (skrCK == "niemożliwe")
            {
                cena = -1;
            }
            else
            {
                cena = Convert.ToInt32(skrCK);
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
            int cena = Convert.ToInt32(alchCS);
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
            if (alchCK == "niemożliwe")
            {
                cena = -1;
            }
            else
            {
                cena = Convert.ToInt32(alchCK);
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
            int cena = Convert.ToInt32(przypCS);
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
            if (przypCK == "niemożliwe")
            {
                cena = -1;
            }
            else
            {
                cena = Convert.ToInt32(przypCK);
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
