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

        public Warsztat(string a)
        {
            id = a;
            InitializeComponent();
            odswiez();
        }

        public void odswiez()
        {
            int w = przekaznik.dajWozy(id);
            ileWozow.Text = w.ToString();
            w = w * 2;
            w--;
            ileLudzi.Text = w.ToString();
            ilePojemnosc.Text = przekaznik.PoliczPojemnosc(id).ToString();
            ileOchrony.Text = przekaznik.dajOchrone(id).ToString();
            ilePomocnikow.Text = przekaznik.dajPomagierow(id).ToString();
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
            odswiez();
            MainWindow.odzwierzGlowne();
        }

        private void button3_Click(object sender, RoutedEventArgs e)  //najmij pomocnika
        {
            warsztat.najmijPomoc(id);
            odswiez();
        }

        private void button6_Click(object sender, RoutedEventArgs e) //zwolnij pomocnika
        {
            Boolean a = warsztat.zwolnijPomoc(id);
            if (a == false)
            {
                Errors er = new Errors("Nie masz pomocników do zwolnienia");
                er.Show();
            }
            odswiez();
        }

        private void button7_Click(object sender, RoutedEventArgs e) //najmij najemnika
        {
            warsztat.najmijOchrone(id);
            odswiez();
        }

        private void button8_Click(object sender, RoutedEventArgs e)  //zwolnij najemnika
        {
            Boolean a = warsztat.zwolnijOchrone(id);
            if (a == false)
            {
                Errors er = new Errors("Nie masz najemników do zwolnienia");
                er.Show();
            }
            odswiez();
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
