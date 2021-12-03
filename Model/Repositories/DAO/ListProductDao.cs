using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseAccountingSystem;

namespace Model.Repositories.DAO
{
    public class ListProductDao : IProductDao
    {
        private List<Product> productList;
        private static ListProductDao INSTANCE;

       static public ListProductDao getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new ListProductDao();
            return INSTANCE;
        }

        private ListProductDao()
        {
            productList = new List<Product>();
            //прописать здесь тестовые продукты
            productList.Add(new Product { 
                NameProduct = "Телевизор, он же TV", 
                CostProduct = 500, 
                CountryProduct = "Беларусь", 
                DescriptionProduct = "Норм",
                IdProduct = 111,
                WeightProduct = 10,
                  type = ProductType.Manufacture});
            productList.Add(new Product
            {
                NameProduct = "Компьютер",
                CostProduct = 1000,
                CountryProduct = "Тайвань",
                DescriptionProduct = "Геймерский",
                IdProduct = 1333,
                WeightProduct = 10,
                type = ProductType.Manufacture
            });
            productList.Add(new Product
            {
                NameProduct = "Хлеб",
                CostProduct = 10,
                CountryProduct = "Беларусь",
                DescriptionProduct = "Черствый",
                IdProduct = 222,
                WeightProduct = 1,
                type = ProductType.Food
            });

        }

        public void addProduct(Product product)
        {
            productList.Add(product);
        }

        public void deleteProduct(long id)
        {
            productList.Remove(GetProduct(id));
        }

        public List<Product> getAllProducts()
        {
            return new List<Product>(productList);
        }

        public Product GetProduct(long id)
        {
            return productList.Where(product => product.IdProduct == id).First();
        }
    }
}
