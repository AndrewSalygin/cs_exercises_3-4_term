using System;
using System.Collections.Generic;

namespace LastEx
{
    internal class Product : Goods 
    {
        string _name;
        double _price;
        DateTime _productionDate;
        TimeSpan _shelfLife;

        internal Product(string name, double price, DateTime productionDate, TimeSpan shelfLife) : base(name, price)
        {
            _name = name;
            _price = price;
            _productionDate = productionDate;
            _shelfLife = shelfLife;
        }
        
        /*
        internal Product(string name, double price, Product product) : base(name, price)
        {
            _name = name;
            _price = price;
            _productionDate = product.ProductionDate;
            _shelfLife = product.ShelfLife;
        }
        */
        override internal void PrintInfo()
        {
            Console.WriteLine("name: {0}, price: {1}, productionDate: {2}, shelfLife: {3}", Name, Price, 
                ProductionDate.ToShortDateString(), ShelfLife.Days);
        }

        override internal bool IsFresh(DateTime date)
        {
            return _productionDate.Add(_shelfLife) > date;
        }
        
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        
        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }

        public DateTime ProductionDate
        {
            get
            {
                return _productionDate;
            }
            set
            {
                _productionDate = value;
            }
        }
        
        public TimeSpan ShelfLife
        {
            get
            {
                return _shelfLife;
            }
            set
            {
                _shelfLife = value;
            }
        }
    }
}