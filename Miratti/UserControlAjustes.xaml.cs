using Miratti.Properties.Langs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
    public class Lang
    {
        public string tema { get; set; }
        public string colorDeFondo { get; set; }
        public string traduccion { get; set; }
        public string ayudaText { get; set; }
        public string idioma { get; set; }
        public string LangName { get; set; }
        public string acercaDe { get; set; }
        public string cerrarSession { get; set; }
        public string menu { get; set; }
        public string Flag { get; set; }
    }
    public class Languages
    {
        public List<Lang> MyLangs { get; set; } = GetLangs();
        
        public static List<Lang> GetLangs()
        {
            var list = new List<Lang>() { new Lang() { tema = "Tema oscuro", colorDeFondo = "Color de fondo", traduccion = "Traducción", idioma="Idioma",ayudaText="Ayuda", acercaDe="Acerca de", cerrarSession="Cerrar sesión", LangName="Español", menu="Menú", Flag = "Spain_flag.png"},

                                          new Lang() { tema = "Dark theme", colorDeFondo = "Background Color", traduccion = "Translation", idioma="Language", ayudaText="Help", acercaDe="About", cerrarSession="Close session", LangName="English", menu="Menu" , Flag = "USA_flag.png"},

                                          new Lang() { tema = "Thème sombre", colorDeFondo = "Couleur de l'arrière plan", traduccion = "Traduction", idioma="Langue", ayudaText="Aider", acercaDe="à propos de", cerrarSession="Fermer la session", LangName="Français", menu="Menu" , Flag = "France_flag.png"},

            };
            return list;
        }
    }
    
    public partial class UserControlAjustes : UserControl
    {


        public static bool isClicked = false; 
        public static bool isChanged = false;
        public UserControlAjustes()
        {
            InitializeComponent();

            checkColor();
            checkIdioma();
            
        }

        public MainWindow mainWindow = Window.GetWindow(Application.Current.MainWindow) as MainWindow;
        public void checkIdioma()
        {
            if (isChanged) 
            {
                if (Properties.Settings.Default.LanguageCode == "es-ES")
                {
                    menuText.Text = "Menú";
                    temaOscuroText.Text = "Tema oscuro";
                    traduccionText.Text = "Traducción";
                    idiomaText.Text = "Idioma";
                    ayudaText.Text = "Ayuda";
                    acercaDeText.Text = "Acerca de";
                    cerrarSessionText.Text = "Cerrar sesión";
                }
                else if (Properties.Settings.Default.LanguageCode == "en-US")
                {
                    menuText.Text = "Menu";
                    temaOscuroText.Text = "Dark theme";
                    traduccionText.Text = "Translation";
                    idiomaText.Text = "Language";
                    ayudaText.Text = "Help";
                    acercaDeText.Text = "About";
                    cerrarSessionText.Text = "Close session";
                }
                else
                {
                    menuText.Text = "Menu";
                    temaOscuroText.Text = "Thème sombre";
                    traduccionText.Text = "Traduction";
                    idiomaText.Text = "Langue";
                    ayudaText.Text = "Aider";
                    acercaDeText.Text = "à propos de";
                    cerrarSessionText.Text = "Fermer la session";
                }
            }
            isChanged = false;
        }
        public void checkColor()
        {

            if (isClicked && ((SolidColorBrush)mainWindow.gridPrincipalBackground.Background).Color == (Color)ColorConverter.ConvertFromString("#FFEEEEEE"))
            {

                // Save Values
                //Properties.Settings.Default.textColor = Color.FromRgb(34, 34, 34);
                //Properties.Settings.Default.botonColor = Color.FromRgb(255, 255, 255);
                //Properties.Settings.Default.Save();

                btn_Modosc.Content = "ON";
                btn_Modosc.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                btn_Modosc.Background = new SolidColorBrush(Color.FromRgb(34, 34, 34));
                mainWindow.gridPrincipalBackground.Background = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                generalText.Foreground = new SolidColorBrush(Color.FromRgb(34, 34, 34));
                menuText.Foreground = new SolidColorBrush(Color.FromRgb(34, 34, 34));
                temaOscuroText.Foreground = new SolidColorBrush(Color.FromRgb(34, 34, 34));
                idiomaText.Foreground = new SolidColorBrush(Color.FromRgb(34, 34, 34));
                traduccionText.Foreground = new SolidColorBrush(Color.FromRgb(34, 34, 34));
                ayudaText.Foreground = new SolidColorBrush(Color.FromRgb(34, 34, 34));
                acercaDeText.Foreground = new SolidColorBrush(Color.FromRgb(34, 34, 34));
                cerrarSessionText.Foreground = new SolidColorBrush(Color.FromRgb(34, 34, 34));
                temaOscuroIcon.Foreground = new SolidColorBrush(Color.FromRgb(34, 34, 34));
                languageIcon.Foreground = new SolidColorBrush(Color.FromRgb(34, 34, 34));
                aboutIcon.Foreground = new SolidColorBrush(Color.FromRgb(34, 34, 34));
                WindowCloseIcon.Foreground = new SolidColorBrush(Color.FromRgb(34, 34, 34));
            }
            else if (isClicked && ((SolidColorBrush)mainWindow.gridPrincipalBackground.Background).Color != (Color)ColorConverter.ConvertFromString("#FFEEEEEE"))
            {
                // Save Values
                //Setting values
                btn_Modosc.Content = "OFF";
                btn_Modosc.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                btn_Modosc.Foreground = new SolidColorBrush(Color.FromRgb(34, 34, 34));

                mainWindow.gridPrincipalBackground.Background = new SolidColorBrush(Color.FromRgb(34, 34, 34));
                generalText.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                menuText.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                temaOscuroText.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                //colorFondoTexto.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                idiomaText.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                traduccionText.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                ayudaText.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                acercaDeText.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                cerrarSessionText.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                temaOscuroIcon.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                languageIcon.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                aboutIcon.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                WindowCloseIcon.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                UserControlInicio inicio = new UserControlInicio();
                inicio.slug1.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            }
        }
        public string[] lenguajes { get; set; }
       
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
        }
        
        private void StackPanel_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("OK");
        }
        // Converter for multilanguages

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            isClicked = true;

            if (((SolidColorBrush)mainWindow.gridPrincipalBackground.Background).Color == (Color)ColorConverter.ConvertFromString("#FFEEEEEE"))
            {
                // Save Values
                //Properties.Settings.Default.textColor = Color.FromRgb(255, 255, 255);
                //Properties.Settings.Default.botonColor = Color.FromRgb(34, 34, 34);
                //Properties.Settings.Default.Save();
                
                //Setting values
                btn_Modosc.Content = "OFF";
                btn_Modosc.Background = new SolidColorBrush(Color.FromRgb(255,255,255));
                btn_Modosc.Foreground = new SolidColorBrush(Color.FromRgb(34, 34, 34));

                mainWindow.gridPrincipalBackground.Background = new SolidColorBrush(Color.FromRgb(34, 34, 34));
                generalText.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                menuText.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                temaOscuroText.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                //colorFondoTexto.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                idiomaText.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                traduccionText.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                ayudaText.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                acercaDeText.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                cerrarSessionText.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                temaOscuroIcon.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                languageIcon.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                aboutIcon.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                WindowCloseIcon.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                UserControlInicio inicio = new UserControlInicio();
                inicio.slug1.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
               
            }
            else  
            {
                // Save Values
                //Properties.Settings.Default.textColor = Color.FromRgb(34, 34, 34);
                //Properties.Settings.Default.botonColor = Color.FromRgb(255, 255, 255);
                //Properties.Settings.Default.Save();

                btn_Modosc.Content = "ON";
                btn_Modosc.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                btn_Modosc.Background = new SolidColorBrush(Color.FromRgb(34, 34, 34));
                mainWindow.gridPrincipalBackground.Background = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                generalText.Foreground = new SolidColorBrush(Color.FromRgb(34, 34, 34));
                menuText.Foreground = new SolidColorBrush(Color.FromRgb(34, 34, 34));
                temaOscuroText.Foreground = new SolidColorBrush(Color.FromRgb(34, 34, 34));
                idiomaText.Foreground = new SolidColorBrush(Color.FromRgb(34, 34, 34));
                traduccionText.Foreground = new SolidColorBrush(Color.FromRgb(34, 34, 34));
                ayudaText.Foreground = new SolidColorBrush(Color.FromRgb(34, 34, 34));
                acercaDeText.Foreground = new SolidColorBrush(Color.FromRgb(34, 34, 34));
                cerrarSessionText.Foreground = new SolidColorBrush(Color.FromRgb(34, 34, 34));
                temaOscuroIcon.Foreground = new SolidColorBrush(Color.FromRgb(34, 34, 34));
                languageIcon.Foreground = new SolidColorBrush(Color.FromRgb(34, 34, 34));
                aboutIcon.Foreground = new SolidColorBrush(Color.FromRgb(34, 34, 34));
                WindowCloseIcon.Foreground = new SolidColorBrush(Color.FromRgb(34, 34, 34));

            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            isChanged = true;
            // internacionlizacion
            if (combobox.SelectedIndex == 0)
            {
             
                Trace.TraceInformation("Un cambio de idioma a Español");
                Properties.Settings.Default.LanguageCode = "es-ES";
                mainWindow.InitializeComponent();

            }
            else if(combobox.SelectedIndex == 1)
            {
                Trace.TraceInformation("Un cambio de idioma a English");
                Properties.Settings.Default.LanguageCode = "en-US";
                mainWindow.InitializeComponent();
            }
            else
            {
                Trace.TraceInformation("Un cambio de idioma a French");
                Properties.Settings.Default.LanguageCode = "fr-FR";
                mainWindow.InitializeComponent();
            }

        }

        private void StackPanel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void btn_guardar(object sender, RoutedEventArgs e)
        {
            string fichero = Properties.Settings.Default.fichero_config.ToString();
            StreamWriter fc = new StreamWriter(fichero, false);
            fc.WriteLine();
            fc.WriteLine();
            fc.WriteLine();
            fc.WriteLine();
            fc.WriteLine();
            fc.Close();
            MessageBox.Show("Configuración almacenada correctamente", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
            mainWindow.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Version 1.0","Miratti App", MessageBoxButton.OK ,MessageBoxImage.Information);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Quiere cerrar la aplicacion?", "Miratti App", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    mainWindow.Close();
                    break;
                case MessageBoxResult.No:
                    
                    break;
            }            
        }

    }
}
