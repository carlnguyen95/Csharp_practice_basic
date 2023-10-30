using System;
using System.Collections.Generic;

namespace Products
{
    public class Product
    {
        //Properties
        //Change to PascalCased
        public string Name { get; set; }
        public string Id { get; private set; }
        public float Price { get; set; }
        public int Stock { get; set; }

        //Should be private
        private static int productCount = 0;

        private static List<Product> ProductRecord = new List<Product>() {
            new Product("Silk", 10.2F, 100),
            new Product("Bread", 16.2F, 110)
        };

        //Constructor
        public Product()
        {

        }

        public Product(string _name, float _price, int _stock)
        {
            this.Name = _name;
            this.Price = _price;
            this.Stock = _stock;
            this.Id = this.name[0] + productCount.ToString();
            productCount++;
        }

        public void Rename(string _id, string newName)
        {
            bool match = false;
            foreach (Product p in ProductRecord)
            {
                if (p.ID == _id)
                {
                    Console.WriteLine($"Change the product ID={_id} name {p.name} with new name {newName}.");
                    p.Name = newName;
                    p.Id = p.name[0] + p.Id.Substring(1); //Change ID corresponding to the new name
                    match = true;
                    break;
                }
            }
            if (!match) Console.WriteLine($"Can't find the product with ID={_id}");
        }

        public void AddProduct(string name, float price, int stock)
        {
            Product p = new Product(name, price, stock);
            ProductRecord.Add(p);
        }

        public void ListAllProduct()
        {
            foreach (Product p in ProductRecord)
            {
                Console.WriteLine($"Name={p.Name,-7} -- ID={p.Id} -- Stock={p.Stock}");
            }
        }

        public void Sum()
        {
            int stock = 0;
            foreach (Product p in ProductRecord)
            {
                stock += p.Stock;
            }
            Console.WriteLine($"Our storage currently has {stock} products.");
        }
    }
}