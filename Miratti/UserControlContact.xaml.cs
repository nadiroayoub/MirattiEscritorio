using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
        public MainWindow mainWindow = Window.GetWindow(Application.Current.MainWindow) as MainWindow;
        public UserControlContact()
        {
            
            InitializeComponent();
            LoadGrid();
            checkColor();
            checkLang();
        }
        public void checkLang()
        {
            if (Properties.Settings.Default.LanguageCode == "es-ES")
            {
                nombre.Content = "Nombre";
                puesto.Content = "Puesto";
                fotoPersonal.Content = "Foto personal";
                updateBtn.Content = "Editar";
                insertBtn.Content = "Insertar";
                deleteBtn.Content = "Eliminar";
                clearBtn.Content = "Vaciar formulario";
                btnUploadImage.Content = "Imagen";
            }
            else if (Properties.Settings.Default.LanguageCode == "en-US")
            {
                nombre.Content = "Name";
                puesto.Content = "Job";
                fotoPersonal.Content = "Peronal photo";
                updateBtn.Content = "Edit";
                insertBtn.Content = "Insert";
                deleteBtn.Content = "Delete";
                clearBtn.Content = "Clear form";
                btnUploadImage.Content = "Image";
            }
            else
            {
                nombre.Content = "Nom";
                puesto.Content = "Poste de travail";
                fotoPersonal.Content = "Photo personnelle";
                updateBtn.Content = "Modifier";
                insertBtn.Content = "Inserter";
                deleteBtn.Content = "Eliminer";
                clearBtn.Content = "Formulaire vide";
                btnUploadImage.Content = "Imagen";
            }
        }

        public void checkColor()
        {
            if (((SolidColorBrush)mainWindow.gridPrincipalBackground.Background).Color == (Color)ColorConverter.ConvertFromString("#FFEEEEEE")){
                id.Foreground = new SolidColorBrush(Color.FromRgb(34, 34, 34));
                nombre.Foreground = new SolidColorBrush(Color.FromRgb(34, 34, 34));
                puesto.Foreground = new SolidColorBrush(Color.FromRgb(34, 34, 34));
                fotoPersonal.Foreground = new SolidColorBrush(Color.FromRgb(34, 34, 34));

            } else
            {
                id.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                nombre.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                puesto.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                fotoPersonal.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));

                nombre_txt.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                puesto_txt.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                //foto_txt.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                buscar_txt.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7JLILKO\SQLEXPRESS;Initial Catalog=mirattidb;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
        
        public void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("Select * from trabajadores", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            datagrid.ItemsSource = dt.DefaultView;
        }
        public void clearData()
        {
            nombre_txt.Clear();
            puesto_txt.Clear();
            //foto_txt.Clear();
            buscar_txt.Clear();
        }
        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            clearData();
        }
        public bool isValid()
        {
            if(nombre_txt.Text == string.Empty)
            {
                MessageBox.Show("Nombre es obligatorio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (puesto_txt.Text == string.Empty)
            {
                MessageBox.Show("Puesto es obligatorio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;

        }
        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isValid())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO trabajadores VALUES (@nombre, @puesto, @imagen)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nombre", nombre_txt.Text);
                    cmd.Parameters.AddWithValue("@puesto", puesto_txt.Text);
                    cmd.Parameters.AddWithValue("@imagen", filepath);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    LoadGrid();
                    MessageBox.Show("Datos del trabajador Han sido regitrados", "Registrados", MessageBoxButton.OK, MessageBoxImage.Information);
                    clearData();
                }
            } catch (SqlException ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from trabajadores where id = " + buscar_txt.Text + " ", con);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Datos eliminados", "Eliminado", MessageBoxButton.OK, MessageBoxImage.Information);
                con.Close();
                clearData();
                LoadGrid();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Datos no eliminados, error es " + ex.Message);
            }finally
            {
                con.Close();
            }
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update trabajadores set nombre = '"+ nombre_txt.Text +"', puesto = '" + puesto_txt.Text + "', imagen = '" + filepath + "' WHERE id = '" + buscar_txt.Text + "' ", con);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Datos han sido cambiados", "Modificados", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }finally
            {
                con.Close();
                clearData();
                LoadGrid();
            }
        }
        public static string filepath;
        private void btnUploadImage_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            bool? response = openFileDialog.ShowDialog();
            if(response == true)
            {
                filepath = openFileDialog.FileName;
                MessageBox.Show("Su imagen" + filepath + " se ha guardado");
            }
        }


        private void btnUploadImage_Copy_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}