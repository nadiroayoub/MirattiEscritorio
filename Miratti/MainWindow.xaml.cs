using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        mirattidbEntities1 db;
        public MainWindow()
        {
            InitializeComponent();
            //db = new mirattidbEntities1();
            checkLang();
            isLoaded = true;
        }

        public void checkLang()
        {
            //if (Properties.Settings.Default.LanguageCode == "es-ES")
            //{
            //    txtblock_inicio.Text = "Inicio";
            //    puntoDeVenta.Text = "Punto de venta";
            //    trabajadores.Text = "Trabajadores";
            //    configuracion.Text = "Configuración";
            //}
            //else if (Properties.Settings.Default.LanguageCode == "en-US")
            //{
            //    txtblock_inicio.Text = "Home";
            //    puntoDeVenta.Text = "Point of sale";
            //    trabajadores.Text = "Workers";
            //    configuracion.Text = "Configuration";
            //}
            //else
            //{
            //    txtblock_inicio.Text = "Inicial";
            //    puntoDeVenta.Text = "Point de vente";
            //    trabajadores.Text = "Travailleurs";
            //    configuracion.Text = "Configuration";
            //}
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonFecher_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        //public int indice;
        public int indice { get; set; }
        public bool isLoaded { get; set; }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            indice = ListViewMenu.SelectedIndex;
            MoverCursorMenu(indice);
            switch (indice)
            {
                case 0:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new UserControlInicio());
                    break;
                case 1:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new UserControlPuntoDeVenta());
                    break;
                case 2:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new UserControlContact());
                    break;
                case 3:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new UserControlAjustes());
                    break;
                default:
                    break;
            }
        }

        public void MoverCursorMenu(int indice)
        {
            TransitionigContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (100 + ( 60 * indice)), 0, 0);
        }

        private void ButtonFecher_Click_FB(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/mirattibags");
        }

        private void ButtonFecher_Click_IG(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/mirattibags/");
        }
    }
}
