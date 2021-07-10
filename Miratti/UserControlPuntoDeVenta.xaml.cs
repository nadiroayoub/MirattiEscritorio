using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
    

    public partial class UserControlPuntoDeVenta : UserControl, INotifyPropertyChanged
    {

        //mirattidbEntities1 db;

        public UserControlPuntoDeVenta()
        {
            InitializeComponent();
            //db = new mirattidbEntities1();
            RefreshCategoria();
            DataContext = this;
            listaDeCompra.ItemsSource = listaProductos;
            PrecioTotal = 0;
            checkLang();
        }
        public void checkLang()
        {
            if (Properties.Settings.Default.LanguageCode == "es-ES")
            {
                categorias.Text = "Categorias";
                articulos.Text = "Articulos";
                cobrar.Text = "Cobrar";
            }
            else if (Properties.Settings.Default.LanguageCode == "en-US")
            {
                categorias.Text = "Categories";
                articulos.Text = "Articles";
                cobrar.Text = "Charge";
            }
            else
            {
                categorias.Text = "Categories";
                articulos.Text = "Articles";
                cobrar.Text = "Recueillir";
            }
        }
        private decimal? precioTotal;
        public decimal? PrecioTotal
        {
            get { return precioTotal; }
            set
            {
                if(precioTotal != value)
                {
                    precioTotal = value;
                    OnPropertyChanged();
                }
            }
        }
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //System.Windows.Data.CollectionViewSource productoViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("productoViewSource")));

            //db.categorias.Load();
            //productoViewSource.Source = db.categorias.Local;
        }
        private void RefreshCategoria()
        {
            List<CategoriaViewModel> lst = new List<CategoriaViewModel>();
            using (mirattidbEntities1 db1 = new mirattidbEntities1())
            {
                lst = (from d in db1.categorias
                       select new CategoriaViewModel
                       {
                           id = d.idCategoria,
                           nombre = d.nombre
                       }).ToList();
            }
            itemsControl.ItemsSource = lst;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Clicked: " + this.Content);
            var keyword = (e.Source as Button).Content.ToString();
            GetProductos( keyword);
        }

        private void GetProductos(string sexo)
        {
            if (sexo == "Hombre")
            {
                //MessageBox.Show("Hombre");
                List<ProductosViewModel> lst = new List<ProductosViewModel>();
                using (mirattidbEntities1 db1 = new mirattidbEntities1())
                {
                    lst = (from d in db1.productos
                           select new ProductosViewModel
                           {
                               //if ()
                    
                               id = d.idProducto,
                               nombre = d.nombre,
                               imagen = d.imagen,
                               precio = d.precio,
                               idCategoria = d.idCategoria
                    
                           }).ToList();
                }
                List<ProductosViewModel> filtredList = new List<ProductosViewModel>();
                
                foreach(var element in lst)
                {
                    if(element.idCategoria == 1)
                    {
                        filtredList.Add(element);
                    }
                }
                listViewProducts.ItemsSource = filtredList;
                //var message = string.Join(Environment.NewLine, lst);
                /*MessageBox.Show(message);*/

            }
            else
            {
                //MessageBox.Show("Mujer");
                List<ProductosViewModel> lst = new List<ProductosViewModel>();
                using (mirattidbEntities1 db1 = new mirattidbEntities1())
                {
                    lst = (from d in db1.productos
                           select new ProductosViewModel
                           {
                               //if ()

                               id = d.idProducto,
                               nombre = d.nombre,
                               imagen = d.imagen,
                               precio = d.precio,
                               idCategoria = d.idCategoria

                           }).ToList();
                }
                List<ProductosViewModel> filtredList = new List<ProductosViewModel>();

                foreach (var element in lst)
                {
                    if (element.idCategoria == 2)
                    {
                        filtredList.Add(element);
                    }
                }
                listViewProducts.ItemsSource = filtredList;

            }
        }


        private ObservableCollection<ProductosViewModel> listaProductos = new ObservableCollection<ProductosViewModel>();

        //List<ProductosViewModel> listaProductos = new List<ProductosViewModel>();
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var button = e.Source as Button;
            var contentPresenter = button.TemplatedParent as ContentPresenter;
            var producto = (ProductosViewModel)contentPresenter.Content;

            //ProductosViewModel producto = new ProductosViewModel();
            Trace.TraceInformation("El precio se accumula");
            PrecioTotal += producto.precio;

            listaProductos.Add(producto);

            //MessageBox.Show(PrecioTotal.ToString());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            listaProductos.Clear();
            PrecioTotal = 0;
            //botonEditar.BorderBrush = new SolidColorBrush(Colors.Transparent);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if(PrecioTotal != 0)
            {
                MessageBoxResult result = MessageBox.Show("El cliente ya ha pagado en effectivo: \" " + PrecioTotal + "$\"!", "Miratti App", MessageBoxButton.YesNoCancel);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        Trace.TraceInformation("processo del pago por el cliente");

                        listaProductos.Clear();
                        PrecioTotal = 0;
                        break;
                    case MessageBoxResult.No:
                        MessageBox.Show("Se ha producido un error", "Miratti App");
                        break;
                    case MessageBoxResult.Cancel:

                        break;
                }
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (PrecioTotal != 0)
            {
            MessageBox.Show("El cliente Ya ha pagado con tarjeta", "Miratti App");
                PrecioTotal = 0;
                listaProductos.Clear();
            }
        }
        private Boolean isClicked = true;
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            //if (isClicked)
            //{
                
            //    botonEditar.BorderBrush = new SolidColorBrush(Colors.Red);
            //    isClicked = false;
            //}
            //else
            //{
            //    botonEditar.BorderBrush = new SolidColorBrush(Colors.Green);
            //        isClicked = true;
            //}
        }
        
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            //if (!isClicked)
            //{
            //    var button = e.sender as Button;
            //    var contentPresenter = button.TemplatedParent as ContentPresenter;
            //    var producto = (ProductosViewModel)contentPresenter.Content;
            //    button.Cea
            //}
        }
    }
    public class CategoriaViewModel
    {
        public int id
        {
            get;set;
        }
        public string nombre
        {
            get; set;
        }
    }
    public class ProductosViewModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string imagen { get; set; }
        public Nullable<decimal> precio { get; set; }
        public Nullable<int> idCategoria { get; set; }

        public virtual categoria categoria { get; set; }
    }
    //public class Compra : INotifyPropertyChanged
    //{
    //    private decimal? precioTotal;

    //    public event PropertyChangedEventHandler PropertyChanged;

    //    private void OnPropertyChanged(string property)
    //    {
    //        if(PropertyChanged != null)
    //        {
    //            PropertyChanged(this, new PropertyChangedEventArgs(property));
    //        }
    //    }
    //    public decimal? PrecioTotal
    //    {
    //        get { return precioTotal; }
    //        set { precioTotal = value; }
    //    }
    //}
}
