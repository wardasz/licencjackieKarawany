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

namespace Caravans
{
    /// <summary>
    /// Логика взаимодействия для Errors.xaml
    /// </summary>
    public partial class Errors : Window
    {
        string mes;
        string title;
        public Errors(string a)
        {
            mes = a;
            title = "Pomyłka!";
            InitializeComponent();
            wiadomosc.DataContext = this;
            tytul.DataContext = this;
        }

        public Errors(string a, string b)
        {
            title = a;
            mes = b;
            InitializeComponent();
            wiadomosc.DataContext = this;
            tytul.DataContext = this;
        }

        public string MES
        {
            get { return mes; }
            set { mes = value; }
        }

        public string TIT
        {
            get { return title; }
            set { title = value; }
        }

        private void Exiterror_Click(object sender, RoutedEventArgs e) => Close();


    }
}
