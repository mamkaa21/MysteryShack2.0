using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Microsoft.EntityFrameworkCore;

namespace MysteryShack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        // private DB DB = new DB();
        public event PropertyChangedEventHandler? PropertyChanged;
        HttpClient httpClient = new HttpClient();
        //public Good Good { get; set; } = new();

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

        private Good good;
        public Good Good
        {
            get => good;
            set
            {
                good = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Good)));
            }
        }

        private List<Good> goods;
        public List<Good> Goods
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
            httpClient.BaseAddress = new Uri("http://localhost:5134/api/");
            Good = new Good();

            Task.Run(async () =>
            {
                await GetCategories().ContinueWith(async s =>
                    await GetGoods());
            });



            DataContext = this;
        }

        public async void Add(object sender, RoutedEventArgs e)
        {
            if (Good.Id == 0)
            {
                Good.IdCategory = Category.Id;
                string arg = JsonSerializer.Serialize(Good);
                var responce = await httpClient.PostAsync($"Goods/CreateGoods", new StringContent(arg, Encoding.UTF8, "application/json"));
                if (responce.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    var result = await responce.Content.ReadAsStringAsync();
                    MessageBox.Show(result);
                    return;
                }
                else
                    MessageBox.Show("товар успешно добавлен");
            }
            else
            {
                string arg = JsonSerializer.Serialize(Good);
                var responce = await httpClient.PostAsync($"Goods/EditGoods", new StringContent(arg, Encoding.UTF8, "application/json"));
                if (responce.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    var result = await responce.Content.ReadAsStringAsync();
                    MessageBox.Show(result);
                    return;
                }
                else
                    MessageBox.Show("товар успешно изменен");
            }
            GetGoods();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Goods)));
        }


        private async void DeleteGoods(object sender, RoutedEventArgs e)
        {
            string arg = JsonSerializer.Serialize(Good);
            var responce = await httpClient.PostAsync($"Goods/DeleteGoods", new StringContent(arg, Encoding.UTF8, "application/json"));
            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await responce.Content.ReadAsStringAsync();
                MessageBox.Show("Ошибка подключения");
                return;
            }
            else
            {
                var result = await responce.Content.ReadAsStringAsync();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Good)));
                MessageBox.Show(result);
                GetGoods();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Goods)));
            }
        }

        public async Task GetGoods()
        {
            var responce = await httpClient.GetAsync($"Goods/GetGoods");
            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await responce.Content.ReadAsStringAsync();
                MessageBox.Show("все плохо");
                return;
            }
            else
            {
                var goods = await responce.Content.ReadFromJsonAsync<List<Good>>();
                Goods = new List<Good>(goods);
                Goods.ForEach(s => s.IdCategoryNavigation = Categories.FirstOrDefault(c => c.Id == s.IdCategory));
                PropertyChanged?.Invoke(goods, new PropertyChangedEventArgs(nameof(Good)));
                PropertyChanged?.Invoke(goods, new PropertyChangedEventArgs(nameof(Goods)));
            }
        }

        public async Task GetCategories()
        {
            try
            {
                var responce = await httpClient.GetAsync($"Category/GetCategories");
                responce.EnsureSuccessStatusCode();
                var answer = await responce.Content.ReadFromJsonAsync<List<Category>>();
                Categories = new List<Category>(answer);

                PropertyChanged?.Invoke(goods, new PropertyChangedEventArgs(nameof(Categories)));


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private async void ShowForm(object sender, RoutedEventArgs e)
        {
            FormGoods.IsEnabled = true;

        }

        private void ShowAddForm(object sender, RoutedEventArgs e)
        {
            FormGoods.IsEnabled = true;
            Good = new Good();
        }
    }
}