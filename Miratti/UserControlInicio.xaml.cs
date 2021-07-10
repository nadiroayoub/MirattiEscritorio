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
        public MainWindow mainWindow = Window.GetWindow(Application.Current.MainWindow) as MainWindow;
        public UserControlInicio()
        {
            InitializeComponent();
            checkColor();

        }
        public void checkColor()
        {
            if (((SolidColorBrush)mainWindow.gridPrincipalBackground.Background).Color == (Color)ColorConverter.ConvertFromString("#FFEEEEEE"))
            {
                slyg2.Foreground = new SolidColorBrush(Color.FromRgb(34, 34, 34));
                slug1.Foreground = new SolidColorBrush(Color.FromRgb(34, 34, 34));

            }
            else
            {

                slyg2.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            slug1.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

           
            MainWindow mainWindow = new MainWindow();
            //mainWindow.ListViewMenu.SelectedIndex = 2;
            //mainWindow.lvPuntoDeVenta.Selected(true);

            //MessageBox.Show(mainWindow.lvPuntoDeVenta.IsSelected.ToString(), "f");
            //mainWindow.Close();
            mainWindow.indice = 1;
            mainWindow.MoverCursorMenu(mainWindow.indice); //ERROR NO SE PPUEDE CAMBIAR 
            switch (mainWindow.indice)
            {
                case 1:
                    mainWindow.GridPrincipal.Children.Clear();
                    mainWindow.GridPrincipal.Children.Add(new UserControlPuntoDeVenta());

                    break;
                default:
                    break;
            }
        }
    }
}
