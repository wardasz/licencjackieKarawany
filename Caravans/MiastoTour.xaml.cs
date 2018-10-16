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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;
using Caravans.matma;

namespace Caravans
{
   
    /// <summary>
    /// Логика взаимодействия для MiastoTour.xaml
    /// </summary>
    public partial class MiastoTour : Window
    {
        private string id;
        private string name = "";
        private string infojablka = "";
        private string infodrewno = "";
        private string infomieso = "";
        private string infochleb = "";
        private string infobron = "";
        private string infowino = "";
        private string infotkanina = "";
        private string infoperla = "";
        private string infoskora = "";
        private string infoalchemia = "";
        private string infoprzyprawy = "";
        private string ludzie = "";
        private string wojsko = "";
        private string zarcie = "";
        private string kasa = "";
        private string ewenty = "";

        public string NAZWA
        {
            get { return name; }
            set { name = value; }
        }

        public string JABLKA
        {
            get { return infojablka; }
            set { infojablka = value; }
        }

        public string DREWNO
        {
            get { return infodrewno; }
            set { infodrewno = value; }
        }

        public string MIESO
        {
            get { return infomieso; }
            set { infomieso = value; }
        }

        public string CHLEB
        {
            get { return infochleb; }
            set { infochleb = value; }
        }

        public string BRON
        {
            get { return infobron; }
            set { infobron = value; }
        }

        public string WINO
        {
            get { return infowino; }
            set { infowino = value; }
        }

        public string TKANINA
        {
            get { return infotkanina; }
            set { infotkanina = value; }
        }

        public string PERLA
        {
            get { return infoperla; }
            set { infoperla = value; }
        }

        public string SKORA
        {
            get { return infoskora; }
            set { infoskora = value; }
        }

        public string ALCHEMIA
        {
            get { return infoalchemia; }
            set { infoalchemia = value; }
        }

        public string PRZYPRAWY
        {
            get { return infoprzyprawy; }
            set { infoprzyprawy = value; }
        }

        public string POPULACJA
        {
            get { return ludzie; }
            set { ludzie = value; }
        }

        public string ZYWNOSC
        {
            get { return zarcie; }
            set { zarcie = value; }
        }

        public string OBRONNOSC
        {
            get { return wojsko; }
            set { wojsko = value; }
        }

        public string MAJETNOSC
        {
            get { return kasa; }
            set { kasa = value; }
        }

        public string STANY
        {
            get { return ewenty; }
            set { ewenty = value; }
        }


        public MiastoTour(string a)
        {
            id = a;
            zassaj();
            InitializeComponent();
            nazwa.DataContext = this;
            jablka.DataContext = this;
            drewno.DataContext = this;
            mieso.DataContext = this;
            chleb.DataContext = this;
            bron.DataContext = this;
            wino.DataContext = this;
            tkanina.DataContext = this;
            perla.DataContext = this;
            skora.DataContext = this;
            alchemia.DataContext = this;
            przyprawy.DataContext = this;
            populacja.DataContext = this;
            zywnosc.DataContext = this;
            obronnosc.DataContext = this;
            majetnosc.DataContext = this;
            stany.DataContext = this;

        }

        private void zassaj()
        {
            name = przekaznik.dajNazwe(id);
            int pop = przekaznik.DajPopulacje(id);
            ludzie = pop.ToString();
            infojablka = przekaznik.dajInfo("TO02", id, pop);
            infodrewno = przekaznik.dajInfo("TO01", id, pop);
            infomieso = przekaznik.dajInfo("TO04", id, pop);
            infochleb = przekaznik.dajInfo("TO05", id, pop);
            infobron = przekaznik.dajInfo("TO06", id, pop);
            infowino = przekaznik.dajInfo("TO09", id, pop);
            infotkanina = przekaznik.dajInfo("TO03", id, pop);
            infoperla = przekaznik.dajInfo("TO07", id, pop);
            infoskora = przekaznik.dajInfo("TO10", id, pop);
            infoalchemia = przekaznik.dajInfo("TO11", id, pop);
            infoprzyprawy = przekaznik.dajInfo("TO08", id, pop);
            wojsko = przekaznik.dajWojo(id);
            zarcie = przekaznik.dajZarcie(id);
            kasa = przekaznik.dajBogactwo(id);
            ewenty = przekaznik.dajStany(id);

    }

        private void ExitM_Click(object sender, RoutedEventArgs e) => Close();


    }

}
