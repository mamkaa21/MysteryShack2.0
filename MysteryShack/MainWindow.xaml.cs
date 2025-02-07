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
       
        public event PropertyChangedEventHandler? PropertyChanged;

        private Category category;
        public Category Category
        {
            get => category;
            set
            {
                category = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Category)));
            }
        }

        private List<Category> categories;
        public List<Category> Categories
        {
            get => categories;
            set
            {
                categories = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Categories)));
            }
        }

        private Goods good;
        public Goods Good
        {
            get => good;
            set
            {
                good = value;
                PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(Good)));
            }
        }

        private List<Goods> goods;
        public List<Goods> Goods
        {
            get => goods;
            set
            {
                goods = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Goods)));
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;
        }

        private void ShowForm(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteGoods(object sender, RoutedEventArgs e)
        {

        }

        private void Save(object sender, RoutedEventArgs e)
        {

        }
    }
}