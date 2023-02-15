using System;
using System.Collections.Generic;

namespace LastEx
{
    internal class Set : Goods, ICloneable
    {
        string _name;
        double _price;
        Product[] _listOfProducts;

        internal Set(string name, double price, Product[] listOfProducts) : base(name, price)
        {
            _name = name;
            _price = price;
            _listOfProducts = (Product[])listOfProducts.Clone();
        }
        
        public object Clone()
        {
            var clone = new Set(_name, _price, _listOfProducts);
            return clone;
        }

        override internal void PrintInfo()
        {
            Console.WriteLine("name: {0}, price: {1}, listOfProducts:\n[", _name, _price);
            foreach (var p in _listOfProducts)
            {
                p.PrintInfo();
            }
            Console.WriteLine("]");
        }
        
        // если хотя бы один продукт из комплекта несвежий, то весь комплект невсвежий
        override internal bool IsFresh(DateTime date)
        {
            foreach (Product product in _listOfProducts)
            {
                if (!product.IsFresh(date))
                {
                    return false;
                }
            }

            return true;
        }
    }
}

/*
        public Product[] ListOfProducts
        {
            get => _listOfProducts;
            set => _listOfProducts = value;
        }
*/