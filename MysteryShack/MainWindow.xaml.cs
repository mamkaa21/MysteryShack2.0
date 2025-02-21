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
        public Good Good { get; set; }

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
        //public Good Good
        //{
        //    get => good;
        //    set
        //    {
        //        good = value;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Good)));
        //    }
        //}

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
        private DispatcherTimer timer = null;
        public void timerStart()
        {
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 10);
            timer.Start();
        }
        private void timerTick(object sender, EventArgs e) //к таймеру относится 
        {
            Thread thread1 = new Thread(GetGoods);
            thread1.Start();         
        }
        public MainWindow()
        {
            InitializeComponent();
           //GetGoods();
           httpClient.BaseAddress = new Uri("http://localhost:5134/api/");
           
            
           timerStart();
            DataContext = this;
        }

        public async void Add(object sender, RoutedEventArgs e)
        {
            
            string arg = JsonSerializer.Serialize(Good);
            var responce = await httpClient.PostAsync($"Goods/AddGoods", new StringContent(arg, Encoding.UTF8, "application/json"));
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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Goods)));
               
                MessageBox.Show("товар успешно добавлен");              
            }
        }
        public async void Edit(object sender, RoutedEventArgs e)
        {

            string arg = JsonSerializer.Serialize(Good);
            var responce = await httpClient.PostAsync($"Goods/EditGoods", new StringContent(arg, Encoding.UTF8, "application/json"));
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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Goods)));
                MessageBox.Show("товар успешно изменен");
            }
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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Goods)));
                MessageBox.Show("товар успешно изменен");
            }
        }
     
        public async void GetGoods()
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
                PropertyChanged?.Invoke(goods, new PropertyChangedEventArgs(nameof(Good)));
                PropertyChanged?.Invoke(goods, new PropertyChangedEventArgs(nameof(Goods)));
            }
        }


        private async void ShowForm(object sender, RoutedEventArgs e)
        {
            FormGoods.IsEnabled = true;

        }

       
    }
}