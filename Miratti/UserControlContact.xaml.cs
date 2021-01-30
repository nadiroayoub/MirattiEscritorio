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
    /// Lógica de interacción para UserControlContact.xaml
    /// </summary>
    public partial class UserControlContact : UserControl
    {
        public UserControlContact()
        {
            
            InitializeComponent();
            drvJSON datosContactos = new drvJSON();
            datosContactos.origen = "E:/A.Cursos oficiales/Segundo ano/PROGRAMACIÓN AVANZADA EN ENTORNOS DE ESCRITORIO (38208)/EL SEGUNDO AÑO/TF Escritorio/Miratti/Miratti/Recursos/InfoContactos.json";
            datosContactos.loadData();
            for (int i=0; i < datosContactos.getTotal(); i++)
            {
                Grid gridCard = new Grid
                {
                    Height = 300,
                    Background = new SolidColorBrush(Color.FromArgb(0, 243, 243, 100)),
                    //SE QUEDA Effect 
                };
                Grid.SetColumn(gridCard,i);
                gridPrincipal.Children.Add(gridCard);
                
                // add a stackpanel
                StackPanel stackPanel = new StackPanel
                {
                    Width = 200
                };
                // IMAGE
                Image imagenPersonal = new Image
                {
                    Margin = new Thickness(20),
                    Width = 200,
                    Height = 150,
                    Source = datosContactos.getDato(i)[datosContactos.getKey(0)]
                };
                //NOMBRE BLOCKTEXT
                TextBlock textBlockNombre = new TextBlock
                {
                    Margin = new Thickness(10),
                    FontFamily = FontFamily = new FontFamily("ShowCard Gothic"),
                    FontSize = 12,
                    Text = datosContactos.getDato(i)[datosContactos.getKey(1)]
                };
                textBlockNombre.HorizontalAlignment = HorizontalAlignment.Center;
                // DESCRIPCION BLOCKTEXT
                TextBlock textBlockDescripcion = new TextBlock
                {
                    Text = datosContactos.getDato(i)[datosContactos.getKey(2)],
                    FontSize = 10,

                    Margin = new Thickness(5),
                    FontFamily = new FontFamily("Champagne &amp; Limousines")
                };
                textBlockDescripcion.HorizontalAlignment = HorizontalAlignment.Center;
                textBlockDescripcion.TextWrapping = TextWrapping.Wrap;
                // Stackpanel segundario
                StackPanel stackPanel1 = new StackPanel();
                stackPanel1.Orientation = Orientation.Horizontal;
                stackPanel1.HorizontalAlignment = HorizontalAlignment.Center;
                // DOS BOTONES
                Button botonLLamar = new Button
                {
                    FontSize = 12,
                    Width = 80,
                    Content = "Llamar",
                    FontFamily = new FontFamily("Champagne &amp; Limousines"),
                    Margin = new Thickness(5),
                    Background = new SolidColorBrush(Color.FromRgb(189, 147, 2))
                };
                Button botonMensaje = new Button
                {
                    FontSize = 12,
                    Width = 80,
                    Content = "Mensaje",
                    FontFamily = new FontFamily("Champagne &amp; Limousines"),
                    Margin = new Thickness(5),
                    Background = new SolidColorBrush(Color.FromRgb(189, 147, 2))
                };
                stackPanel1.Children.Add(botonLLamar);
                stackPanel1.Children.Add(botonMensaje);
                
                stackPanel.Children.Add(imagenPersonal);
                stackPanel.Children.Add(textBlockNombre);
                stackPanel.Children.Add(textBlockDescripcion);
                stackPanel.Children.Add(stackPanel1);

                gridCard.Children.Add(stackPanel);
            }
        }
    }
}
