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

namespace Caravans
{
    /// <summary>
    /// Логика взаимодействия для WaggonShop.xaml
    /// </summary>
    public partial class WaggonShop : Window
    {       
        public static string idk;
        public static List<string> karawany;
        
        public static string tkanIK;
        public static string winoIK;
        public static string bronIK;
        public static string chlebIK;
        public static string drewIK;
        public static string jablIK;
        public static string miesoIK;
        public static string perlIK;
        public static string skrIK;
        public static string alchIK;
        public static string przypIK;
        public static string pojemnosc;
        public static string obciozenie;

        public void zassaj()
        {
            karawany = przekaznik.dajKarawany();
        
            tkanIK = przekaznik.IleTowaru(idk, "TO03");
            winoIK = przekaznik.IleTowaru(idk, "TO09");
            bronIK = przekaznik.IleTowaru(idk, "TO06");
            chlebIK = przekaznik.IleTowaru(idk, "TO05");
            drewIK = przekaznik.IleTowaru(idk, "TO01");
            jablIK = przekaznik.IleTowaru(idk, "TO02");
            miesoIK = przekaznik.IleTowaru(idk, "TO04");
            perlIK = przekaznik.IleTowaru(idk, "TO07");
            skrIK = przekaznik.IleTowaru(idk, "TO10");
            alchIK = przekaznik.IleTowaru(idk, "TO11");
            przypIK = przekaznik.IleTowaru(idk, "TO08");
            pojemnosc = przekaznik.PoliczPojemnosc(idk).ToString();
            obciozenie = przekaznik.PoliczObciozenie(idk).ToString();
        }



        public string ileObciozenia
        {
            get { return obciozenie; }
            set { obciozenie = value; }
        }

        public string ilePojemnosci
        {
            get { return pojemnosc; }
            set { pojemnosc = value; }
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

        string lokal1 = przekaznik.lokalizuj(idk);
        public string LOK
        {
            get { return lokal1; }
            set { lokal1 = value; }
        }

        public WaggonShop()
        {
            idk = "KA01";
            zassaj();
            InitializeComponent();
            lokal.DataContext = this;
            iljabtour.DataContext = this;
            iltreetour.DataContext = this;
            ilmeattour.DataContext = this;
            ilchlebtour.DataContext = this;
            ilbrontour.DataContext = this;
            ilwinotour.DataContext = this;
            iltkaninatour.DataContext = this;
            ilperlatour.DataContext = this;
            ilskoratour.DataContext = this;
            ilsrodtour.DataContext = this;
            ilprzyprawytour.DataContext = this;
            textBlock.DataContext = this;
            textBlock1.DataContext = this;
            listunia.DataContext = this;

            listunia.Items.Clear();

            foreach (string kar in karawany)
            {
                string wynik = "Karawana nr. " + kar.Remove(0, 2);
                listunia.Items.Add(wynik);
            }


            int jazda = przekaznik.CzasPodrozy(idk);
            if (jazda == 0)
            {
                shop.IsEnabled = true;
                podroz.IsEnabled = true;
                warsztat.IsEnabled = true;
                karczma.IsEnabled = true;
            }
            else
            {
                shop.IsEnabled = false;
                podroz.IsEnabled = false;
                warsztat.IsEnabled = false;
                karczma.IsEnabled = false;
            }
        }

        private void ExitW_Click(object sender, RoutedEventArgs e) => Close();
     

        private void Shop_Click(object sender, RoutedEventArgs e)
        {
            Zakupy za = new Zakupy(idk);
            za.Show();        
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            string idm = przekaznik.lok(idk);
            MiastoTour wa = new MiastoTour(idm);
            wa.Show();
        }
        private void Podroz_Click(object sender, RoutedEventArgs e)
        {
            Boolean a = przekaznik.czyMoznaPodrozowac(idk);
            if (a == false)
            {
                Errors er = new Errors("W twojej karawanie jest za dużo wozów a za mało ludzi by wyruszyć w podróż.");
                er.Show();
            }
            else
            {
                Podroz po = new Podroz(idk);
                po.Show();
            }
        }       
        private void Workshop_Click(object sender, RoutedEventArgs e)
        {
            Warsztat bw = new Warsztat(idk);
            bw.Show();
        }

        public void odswiez()
        {
            string jablka = przekaznik.IleTowaru(idk, "TO02");
            string drewno = przekaznik.IleTowaru(idk, "TO01");
            string mieso = przekaznik.IleTowaru(idk, "TO04");
            string chleb = przekaznik.IleTowaru(idk, "TO05");
            string bron = przekaznik.IleTowaru(idk, "TO06");
            string wino = przekaznik.IleTowaru(idk, "TO09");
            string tkanina = przekaznik.IleTowaru(idk, "TO03");
            string perla = przekaznik.IleTowaru(idk, "TO07");
            string skora = przekaznik.IleTowaru(idk, "TO10");
            string przyprawy = przekaznik.IleTowaru(idk, "TO08");
            string alchemia = przekaznik.IleTowaru(idk, "TO11");
            string obc = przekaznik.PoliczObciozenie(idk).ToString();
            string poj = przekaznik.PoliczPojemnosc(idk).ToString();
            string miejsce = przekaznik.lokalizuj(idk);

            iljabtour.Text = jablka;
            iltreetour.Text = drewno;
            ilmeattour.Text = mieso;
            ilchlebtour.Text = chleb;
            ilbrontour.Text = bron;
            ilwinotour.Text = wino;
            iltkaninatour.Text = tkanina;
            ilperlatour.Text = perla;
            ilskoratour.Text = skora;
            ilsrodtour.Text = alchemia;
            ilprzyprawytour.Text = przyprawy;
            textBlock.Text = obc;
            textBlock1.Text = poj;
            lokal.Text = miejsce;

            int jazda = przekaznik.CzasPodrozy(idk);
            if (jazda == 0)
            {
                shop.IsEnabled = true;
                podroz.IsEnabled = true;
                warsztat.IsEnabled = true;
                karczma.IsEnabled = true;
            }
            else
            {
                shop.IsEnabled = false;
                podroz.IsEnabled = false;
                warsztat.IsEnabled = false;
                karczma.IsEnabled = false;
            }
        }

        private void listunia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string txt = listunia.SelectedItem.ToString();
            txt = txt.Remove(0, 13);
            txt = "KA" + txt;
            idk = txt;          
            odswiez();           
        }      
    }
}


