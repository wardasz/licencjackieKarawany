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
    /// Логика взаимодействия для authors.xaml
    /// </summary>
    public partial class authors : Window
    {
        public authors()
        {
            InitializeComponent();
        }

        private void bexit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
