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
        private List<StorageProduct> productList;
        private static ListProductDao INSTANCE;

       static public ListProductDao getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new ListProductDao();
            return INSTANCE;
        }

        private ListProductDao()
        {
            productList = new List<StorageProduct>();
            //прописать здесь тестовые продукты
            productList.Add(new StorageProduct {
                NameProduct = "Телевизор",
                Stock = 150,
                CostProduct = 500,
                CountryProduct = "Беларусь",
                DescriptionProduct = "Норм",
                IdProduct = 111,
                WeightProduct = 10,
                type = ProductType.Manufacture }) ;
            productList.Add(new StorageProduct
            {
                NameProduct = "Компьютер",
                Stock = 9,
                CostProduct = 1000,
                CountryProduct = "Тайвань",
                DescriptionProduct = "Геймерский",
                IdProduct = 1333,
                WeightProduct = 10,
                type = ProductType.Manufacture
            });
            productList.Add(new StorageProduct
            {
                NameProduct = "Компьютер 2.0",
                Stock = 0,
                CostProduct = 1500,
                CountryProduct = "Тайвань",
                DescriptionProduct = "Геймерский",
                IdProduct = 1337,
                WeightProduct = 15,
                type = ProductType.Manufacture
            });
            productList.Add(new StorageProduct
            {
                NameProduct = "Хлеб",
                Stock = 1250,
                CostProduct = 10,
                CountryProduct = "Беларусь",
                DescriptionProduct = "Черствый",
                IdProduct = 222,
                WeightProduct = 1,
                type = ProductType.Food
            });

        }

        public void addProduct(StorageProduct product)
        {
            productList.Add(product);
        }

        public void deleteProduct(long id)
        {
            productList.Remove(GetProduct(id));
        }

        public List<StorageProduct> getAllProducts()
        {
            return new List<StorageProduct>(productList);
        }

        public StorageProduct GetProduct(long id)
        {
            return productList.Where(product => product.IdProduct == id).First();
        }

        public void RenewAllProduct(List<StorageProduct> products)
        {
            productList = products;
        }
    }
}
