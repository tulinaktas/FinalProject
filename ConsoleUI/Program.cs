﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    //SOLID 
    //Open Closed Principle
    //IoC
    class Program
    {
        static void Main(string[] args)
        {
            ProductTest();
            //CategoryTest();

        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
            /*foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }*/
        }

        private static void ProductTest()
        {
            /*ProductManager productManager
                = new ProductManager(new EFProductDal());// new InMemoryProductDal();

            var result = productManager.GetProductDetails();
            if (result.Success == true)
            {
                foreach (var product in productManager.GetProductDetails().Data)
                {
                    Console.WriteLine(product.ProductName + "   " + product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }


            Console.WriteLine("\n");
            foreach (var product in productManager.GetByUnitPrice(50, 100).Data)
            {
                Console.WriteLine(product.ProductName);
            }*/
        }
    }
}
