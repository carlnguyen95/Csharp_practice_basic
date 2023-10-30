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
            Product.AddProduct("Fruit", 20.1F, 50);
            Product.ListAllProduct();
            Product.Sum();
        }
    }
}