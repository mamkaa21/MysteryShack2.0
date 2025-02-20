using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;

namespace MysteryShack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private DB DB = new DB();
        public event PropertyChangedEventHandler? PropertyChanged;

        //private Category category;
        //public Category Category
        //{
        //    get => category;
        //    set
        //    {
        //        category = value;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Category)));
        //    }
        //}

        //private List<Category> categories;
        //public List<Category> Categories
        //{
        //    get => categories;
        //    set
        //    {
        //        categories = value;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Categories)));
        //    }
        //}

        //private Goods good;
        //public Goods Good
        //{
        //    get => good;
        //    set
        //    {
        //        good = value;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Good)));
        //    }
        //}

        //private List<Goods> goods;
        //public List<Goods> Goods
        //{
        //    get => goods;
        //    set
        //    {
        //        goods = value;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Goods)));
        //    }
        //}

        public MainWindow()
        {
            InitializeComponent();
            //GetData();
            DataContext = this;
        }

        private void Save(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteGoods(object sender, RoutedEventArgs e)
        {

        }

        private void ShowForm(object sender, RoutedEventArgs e)
        {

        }


        //private async void GetData()
        //{
        //    Goods = await DB.GetListGoods();
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Goods)));

        //}

        //private async void ShowForm(object sender, RoutedEventArgs e)
        //{
        //    FormGoods.IsEnabled = true;

        //}

        //private async void DeleteGoods(object sender, RoutedEventArgs e)
        //{
        //    await DB.DeleteGoods(Good);
        //    GetData();
        //}   

        //private async void Save(object sender, RoutedEventArgs e)
        //{
        //    if (Good == null)
        //    {
        //         await DB.AddGoods(Good);
        //            GetData();

        //    } 
        //    else
        //        {
        //            await DB.EditGoods(Good);
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Good)));
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Goods)));

        //            //GetData();
        //        }


        //}
    }
}