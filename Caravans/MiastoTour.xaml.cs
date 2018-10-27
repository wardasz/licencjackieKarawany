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

        
        

        public MiastoTour(string a)
        {
            InitializeComponent(); 
            id = a;
            zassaj();
        }

        private void zassaj()
        {
            nazwaPole.Text = przekaznik.dajNazwe(id);
            int pop = przekaznik.DajPopulacje(id);
            populacjaPole.Text = pop.ToString();
            jablkaPole.Text = przekaznik.dajInfo("TO02", id, pop);
            drewnoPole.Text = przekaznik.dajInfo("TO01", id, pop);
            miesoPole.Text = przekaznik.dajInfo("TO04", id, pop);
            chlebPole.Text = przekaznik.dajInfo("TO05", id, pop);
            bronPole.Text = przekaznik.dajInfo("TO06", id, pop);
            winoPole.Text = przekaznik.dajInfo("TO09", id, pop);
            tkaninaPole.Text = przekaznik.dajInfo("TO03", id, pop);
            perlaPole.Text = przekaznik.dajInfo("TO07", id, pop);
            skoraPole.Text = przekaznik.dajInfo("TO10", id, pop);
            alchemiaPole.Text = przekaznik.dajInfo("TO11", id, pop);
            przyprawyPole.Text = przekaznik.dajInfo("TO08", id, pop);
            obronnoscPole.Text = przekaznik.dajWojo(id);
            zywnoscPole.Text = przekaznik.dajZarcie(id);
            majetnoscPole.Text = przekaznik.dajBogactwo(id);
            stanyPole.Text = przekaznik.dajStany(id);

    }

        private void ExitM_Click(object sender, RoutedEventArgs e) => Close();


    }

}
