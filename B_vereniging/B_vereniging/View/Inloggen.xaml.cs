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

namespace B_vereniging.View
{
    /// <summary>
    /// Interaction logic for Inloggen.xaml
    /// </summary>
    public partial class Inloggen : Window
    {
        public Inloggen()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Eerste scherm verbergen
            this.Hide();

            //Nieuw scherm aanmaken en oproepen
            var mainscreen = new MainWindow();
            mainscreen.Show();
        }
    }
}
