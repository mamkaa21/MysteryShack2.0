using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MysteryShack
{
    public class DB
    {
        private static DB instance;

        HttpClient client = new HttpClient();

        private List<Goods> Goods { get; set; }
        private List<Category> Categories { get; set; }
        private Goods Good { get; set; }
        private Category Category { get; set; }

        public static DB GetInstance()
        {
            if (instance == null)
                instance = new DB();
            return instance;
        }

        public DB()
        {
            client.BaseAddress = new Uri("");
        }

        public async Task<List<Goods>> GetListGoods()
        {
            var responce = await client.GetAsync($"Resignationletters/GetResignationletters");
            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Оши1бка", $"{result}", "ок");
                return null;
            }
            else
            {
                var letters = await responce.Content.ReadFromJsonAsync<List<Goods>>();
                foreach (var item in letters)
                {
                    item.SetStudent();
                }
                return letters;
            }
        }

        public async Task<List<Category>> GetListCategory()
        {
            var responce = await client.GetAsync($"Students/GetStudents");
            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("О2шибка", $"{result}", "ок");
                return null;
            }
            else
            {
                var students = await responce.Content.ReadFromJsonAsync<List<Student>>();
                return students;
            }
        }
    }
}
