using System;
using Products;

namespace ProductInventoryApp
{
    public class Program
    {
        //Properties

        //Constructor

        //Main method
        public static void Main(string[] args)
        {
            Product p = new Product();
            p.AddProduct("Fruit", 20.1F, 50);
            p.ListAllProduct();
        }
    }
}