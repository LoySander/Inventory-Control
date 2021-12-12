using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseAccountingSystem;

namespace Model.Repositories.DAO
{
    //class ListStorageDao
    //{
    //    private List<Storage> productList;
    //    private static ListStorageDao INSTANCE;

    //    static public ListStorageDao getInstance()
    //    {
    //        if (INSTANCE == null)
    //            INSTANCE = new ListStorageDao();
    //        return INSTANCE;
    //    }

    //    private ListStorageDao()
    //    {
    //        productList = new List<Storage>();
    //        //прописать здесь тестовые продукты
    //        productList.Add(new Storage
    //        {
    //            NameProduct = "Телевизор, он же TV",
    //            CostProduct = 500,
    //            CountryProduct = "Беларусь",
    //            IdProduct = 111,
    //            WeightProduct = 10,
    //            type = ProductType.Manufacture,
    //             AmountProduct = 1
    //        });
    //        productList.Add(new Storage
    //        {
    //            NameProduct = "Компьютер",
    //            CostProduct = 1000,
    //            CountryProduct = "Тайвань",
    //            IdProduct = 1333,
    //            WeightProduct = 10,
    //            type = ProductType.Manufacture,
    //            AmountProduct = 1
    //        });
    //        productList.Add(new Storage
    //        {
    //            NameProduct = "Хлеб",
    //            CostProduct = 10,
    //            CountryProduct = "Беларусь",
              
    //            IdProduct = 222,
    //            WeightProduct = 1,
    //            type = ProductType.Food,
    //            AmountProduct = 10
    //        });

    //    }

    //    public void addProduct(Storage product)
    //    {
    //        productList.Add(product);
    //    }

    //    public void deleteProduct(long id)
    //    {
    //        productList.Remove(GetProduct(id));
    //    }

    //    public List<Storage> getAllProducts()
    //    {
    //        return new List<Storage>(productList);
    //    }

    //    public List<Storage> SortStorage()
    //    {
    //       var sortedList = from u in productList
    //                          orderby u.AmountProduct
    //                          select u;
    //        return (List<Storage>)sortedList;
    //    }

    //    // ?
    //    public Storage GetProduct(long id)
    //    {
    //        return productList.Where(product => product.IdProduct == id).First();
    //    }
    //}
}
