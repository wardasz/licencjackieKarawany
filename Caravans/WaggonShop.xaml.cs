﻿using System;
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


        public WaggonShop()
        {
            InitializeComponent();
            idk = "KA01";
            odswiez();

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
            karawany = przekaznik.dajKarawany();
            tkaninaPole.Text = przekaznik.IleTowaruKarawana(idk, "TO03").ToString();
            winoPole.Text = przekaznik.IleTowaruKarawana(idk, "TO09").ToString();
            bronPole.Text = przekaznik.IleTowaruKarawana(idk, "TO06").ToString();
            chlebPole.Text = przekaznik.IleTowaruKarawana(idk, "TO05").ToString();
            drewnoPole.Text = przekaznik.IleTowaruKarawana(idk, "TO01").ToString();
            jablkaPole.Text = przekaznik.IleTowaruKarawana(idk, "TO02").ToString();
            miesoPole.Text = przekaznik.IleTowaruKarawana(idk, "TO04").ToString();
            perlaPole.Text = przekaznik.IleTowaruKarawana(idk, "TO07").ToString();
            skoraPole.Text = przekaznik.IleTowaruKarawana(idk, "TO10").ToString();
            alchemiaPole.Text = przekaznik.IleTowaruKarawana(idk, "TO11").ToString();
            przyprawyPole.Text = przekaznik.IleTowaruKarawana(idk, "TO08").ToString();
            obciozenieMaxPole.Text = przekaznik.PoliczPojemnosc(idk).ToString();
            obciozenieStanPole.Text = przekaznik.PoliczObciozenie(idk).ToString();
            lokalizacjaPole.Text = przekaznik.lokalizuj(idk);

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


