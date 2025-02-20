using System.Net.Http;

namespace MysteryShack
{
    public class DB
    {
        private static DB instance;

        //HttpClient client = new HttpClient();

        /* private List<Goods> Goods { get; set; }
         private List<Category> Categories { get; set; }
         private Goods Good { get; set; }
         private Category Category { get; set; }
         private int LastGoodId;
         private int LastCategoryId;


         public DB()
         {
             Goods = new List<Goods>();
             Goods.Add(new Goods
             {
                 Id = LastGoodId++,
                 Title = "Дневник номер 3",
                 Description = "Дневник про аномалии Гравити Фолз",
                 Price = 1800000,
                 Amount = 1,
                 Id_Category = 1,
             });
             Categories = new List<Category>();
             Categories.Add(new Category
             {
                 Id = LastCategoryId++,
                 Title = "ха-ха, это подделка, дурень"
             });
             Goods.Add(new Goods
             {
                 Id = LastGoodId++,
                 Title = "aaa",
                 Description = "aaaa",
                 Price = 120,
                 Amount = 12,
                 Id_Category = 2,
             });
             Categories = new List<Category>();
             Categories.Add(new Category
             {
                 Id = LastCategoryId++,
                 Title = "это ориг честно"
             });
         }

         public static DB GetInstance()
         {
             if (instance == null)
                 instance = new DB();
             return instance;
         }

         //public DB()
         //{
         //    client.BaseAddress = new Uri("http://localhost:5103/api/");
         //}

         public async Task<List<Goods>> GetListGoods()
         {
             await Task.Delay(100);
             return new List<Goods>(Goods);
         }
         public async Task<List<Category>> GetListCategory()
         {
             await Task.Delay(100);
             return new List<Category>(Categories);
         }
         public async Task<Goods> GetGoodsById(int id)
         {
             var goods = Goods.FirstOrDefault(s => s.Id == id);
             await Task.Delay(100);
             if (goods == null)
             {
                 return null;
             }
             Goods getGoods = new Goods()
             {
                 Id = goods.Id,
                 Id_Category = goods.Id_Category,
                 Title = goods.Title,
                 Description = goods.Description,
                 Price = goods.Price,
                 Amount = goods.Amount
             };
             return getGoods;
         }
         public async Task<Category> GetCategoryById(int id)
         {
             var category = Categories.FirstOrDefault(s => s.Id == id);
             await Task.Delay(100);
             if (category == null)
             {
                 return null;
             }
             Category getCategory = new Category()
             {
                 Id = category.Id,
                 Title = category.Title
             };
             return getCategory;
         }

         public async Task AddGoods(Goods good)
         {
             await Task.Delay(100);           
             Goods newGoods = new Goods()
             {
                 Id = good.Id,
                 Id_Category = good.Id_Category,
                 Title = good.Title,
                 Description = good.Description,
                 Price = good.Price,
                 Amount = good.Amount
             };
             Goods.Add(newGoods);
         }
         //public async Task AddCategories(Category category)
         //{
         //    await Task.Delay(100);
         //    Category newCategories = new Category()
         //    {              
         //        Title = category.Title
         //    };
         //    Categories.Add(newCategories);
         //}

         public async Task EditGoods(Goods goods)
         {
             await Task.Delay(100);
             var good = Goods.FirstOrDefault(s => s.Id == goods.Id);
             good.Id = goods.Id;
             good.Title = goods.Title;
             good.Description = goods.Description;
             good.Price = goods.Price;  
             good.Amount = goods.Amount;
         }

         //public async Task EditCategories(Category category)
         //{
         //    await Task.Delay(100);

         //}

         public async Task DeleteGoods(Goods goods)
         {
             await Task.Delay(100);
             var good = Goods.FirstOrDefault(s => s.Id == goods.Id);
             if (goods.Id == good.Id)
             {
                 Goods.Remove(good);
             }
         }

         //public async Task DeleteCategoryById(Category category, int id)
         //{
         //    await Task.Delay(100);
         //    GetCategoryById(id);
         //    Categories.Remove(category);
         //}


     }*/
    }
}
