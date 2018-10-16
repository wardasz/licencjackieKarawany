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
    /// Логика взаимодействия для Warsztat.xaml
    /// </summary>
    public partial class Warsztat : Window
    {
        string id;
        string wozy="x";
        string pojemnosc="x";
        string ludzie="x";
        string ochrona="x";
        string pomoc="x";

        public Warsztat(string a)
        {
            id = a;
            InitializeComponent();
            ileWozow.DataContext = this;
            ilePojemnosc.DataContext = this;
            ileLudzi.DataContext = this;
            ilePomocnikow.DataContext = this;
            ileOchrony.DataContext = this;
            zassaj();
        }

        public void zassaj()
        {
            int w = przekaznik.dajWozy(id);
            wozy = w.ToString();
            w = w * 2;
            w--;
            ludzie = w.ToString();
            pojemnosc = przekaznik.PoliczPojemnosc(id).ToString();
            ochrona = przekaznik.dajOchrone(id).ToString();
            pomoc = przekaznik.dajPomagierow(id).ToString();

            ileWozow.Text = wozy;
            ilePojemnosc.Text = pojemnosc;
            ileLudzi.Text = ludzie;
            ileOchrony.Text = ochrona;
            ilePomocnikow.Text = pomoc;
        }


        public string WOZY
        {
            get { return wozy; }
            set { wozy = value; }
        }

        public string POJEMNOSC
        {
            get { return pojemnosc; }
            set { pojemnosc = value; }
        }

        public string LUDZIE
        {
            get { return ludzie; }
            set { ludzie = value; }
        }

        public string OCHRONA
        {
            get { return ochrona; }
            set { ochrona = value; }
        }

        public string POMOC
        {
            get { return pomoc; }
            set { pomoc = value; }
        }

        private void ExitWarsztat_Click(object sender, RoutedEventArgs e) => Close();

        private void button_Click(object sender, RoutedEventArgs e) //kup wóz
        {
            Boolean a = warsztat.kupWoz(id);
            if (a == false)
            {
                Errors er = new Errors("Nie stać cię na zakup wozu");
                er.Show();
            }
            zassaj();
            MainWindow.odzwierzGlowne();
        }

        private void button3_Click(object sender, RoutedEventArgs e)  //najmij pomocnika
        {
            warsztat.najmijPomoc(id);
            zassaj();
        }

        private void button6_Click(object sender, RoutedEventArgs e) //zwolnij pomocnika
        {
            Boolean a = warsztat.zwolnijPomoc(id);
            if (a == false)
            {
                Errors er = new Errors("Nie masz pomocników do zwolnienia");
                er.Show();
            }
            zassaj();
        }

        private void button7_Click(object sender, RoutedEventArgs e) //najmij najemnika
        {
            warsztat.najmijOchrone(id);
            zassaj();
        }

        private void button8_Click(object sender, RoutedEventArgs e)  //zwolnij najemnika
        {
            Boolean a = warsztat.zwolnijOchrone(id);
            if (a == false)
            {
                Errors er = new Errors("Nie masz najemników do zwolnienia");
                er.Show();
            }
            zassaj();
        }

        private void nowa(object sender, RoutedEventArgs e) //nowa karawana
        {
            Boolean czy = warsztat.nowaKarawana(id);
            if (czy == true)
            {
                Close();
                MainWindow.odzwierzGlowne();
                GamesWindow.z1();
            }
            else
            {
                Errors er = new Errors("Nie stać cię na nową karawanę");
                er.Show();
            }
        }
    }
}
