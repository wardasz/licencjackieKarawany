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

    public partial class Podroz : Window
    {
        string idk;
        string idm;
        public Podroz(string a)
        {
            idk = a;
            idm = przekaznik.lok(idk);
            InitializeComponent();
        }
        private void exitP_Click(object sender, RoutedEventArgs e) => Close();

        private void Btourilguard_Click(object sender, RoutedEventArgs e)
        {
            if (idm == "MI01")
            {
                Errors er = new Errors("Jesteś w tym mieście");
                er.Show();
            }
            else
            {
                podroz.podrozdo("MI01", idk);
                Close();
                GamesWindow.z1();
            }
        }
        private void BEdgetown_Click(object sender, RoutedEventArgs e)
        {
            if (idm == "MI02")
            {
                Errors er = new Errors("Jesteś w tym mieście");
                er.Show();
            }
            else
            {
                podroz.podrozdo("MI02", idk);
                Close();
                GamesWindow.z1();
            }
        }
        private void BRivercross_Click(object sender, RoutedEventArgs e)
        {
            if (idm == "MI03")
            {
                Errors er = new Errors("Jesteś w tym mieście");
                er.Show();
            }
            else
            {
                podroz.podrozdo("MI03", idk);
                Close();
                GamesWindow.z1();
            }
        }
        private void BSinTog_Click(object sender, RoutedEventArgs e)
        {
            if (idm == "MI04")
            {
                Errors er = new Errors("Jesteś w tym mieście");
                er.Show();
            }
            else
            {
                podroz.podrozdo("MI04", idk);
                Close();
                GamesWindow.z1();
            }
        }
        private void BPortfolk_Click(object sender, RoutedEventArgs e)
        {
            if (idm == "MI05")
            {
                Errors er = new Errors("Jesteś w tym mieście");
                er.Show();
            }
            else
            {
                podroz.podrozdo("MI05", idk);
                Close();
                GamesWindow.z1();
            }
        }
        private void BMountainroot_Click(object sender, RoutedEventArgs e)
        {
            if (idm == "MI06")
            {
                Errors er = new Errors("Jesteś w tym mieście");
                er.Show();
            }
            else
            {
                podroz.podrozdo("MI06", idk);
                Close();
                GamesWindow.z1();
            }
        }
        private void BBottomStream_Click(object sender, RoutedEventArgs e)
        {
            if (idm == "MI07")
            {
                Errors er = new Errors("Jesteś w tym mieście");
                er.Show();
            }
            else
            {
                podroz.podrozdo("MI07", idk);
                Close();
                GamesWindow.z1();
            }
        }
        private void BBlackyardt_Click(object sender, RoutedEventArgs e)
        {
            if (idm == "MI08")
            {
                Errors er = new Errors("Jesteś w tym mieście");
                er.Show();
            }
            else
            {
                podroz.podrozdo("MI08", idk);
                Close();
                GamesWindow.z1();
            }
        }
        private void BLakeshiret_Click(object sender, RoutedEventArgs e)
        {
            if (idm == "MI09")
            {
                Errors er = new Errors("Jesteś w tym mieście");
                er.Show();
            }
            else
            {
                podroz.podrozdo("MI09", idk);
                Close();
                GamesWindow.z1();
            }
        }
        private void BLothrant_Click(object sender, RoutedEventArgs e)
        {
            if (idm == "MI10")
            {
                Errors er = new Errors("Jesteś w tym mieście");
                er.Show();
            }
            else
            {
                podroz.podrozdo("MI10", idk);
                Close();
                GamesWindow.z1();
            }
        }
        private void BWaterclaw_Click(object sender, RoutedEventArgs e)
        {
            if (idm == "MI11")
            {
                Errors er = new Errors("Jesteś w tym mieście");
                er.Show();
            }
            else
            {
                podroz.podrozdo("MI11", idk);
                Close();
                GamesWindow.z1();
            }
        }
        private void BHightown_Click(object sender, RoutedEventArgs e)
        {
            if (idm == "MI12")
            {
                Errors er = new Errors("Jesteś w tym mieście");
                er.Show();
            }
            else
            {
                podroz.podrozdo("MI12", idk);
                Close();
                GamesWindow.z1();
            }
        }
    }
}
