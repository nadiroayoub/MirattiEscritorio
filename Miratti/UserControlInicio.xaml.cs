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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Miratti
{
    /// <summary>
    /// Lógica de interacción para UserControlInicio.xaml
    /// </summary>
    public partial class UserControlInicio : UserControl
    {
        public UserControlInicio()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            gridInicio.Children.Clear();
            //Height = "450" Width = "700" user control inicio a 450 700
            
            gridInicio.Children.Add(new UserControlPuntoDeVenta());
        }
    }
}
