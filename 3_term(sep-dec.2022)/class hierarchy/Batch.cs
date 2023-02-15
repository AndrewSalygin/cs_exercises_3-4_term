using System;
using System.Collections.Generic;

namespace LastEx
{
    internal class Batch : Goods, ICloneable
    {
        Product _product;
        int _count;

        internal Batch(Product product, int count) : base(product.Name, product.Price)
        {
            _product = product;
            _count = count;
        } 
        
        public object Clone()
        {
            var clone = new Batch(_product, _count);
            return clone;
        }
        
        override internal void PrintInfo()
        {
            Console.WriteLine("name: {0}, price: {1}, count: {2}, productionDate: {3}, shelfLife: {4}", _product.Name, 
                _product.Price, _count, _product.ProductionDate.ToShortDateString(), _product.ShelfLife.Days);
        }
        
        override internal bool IsFresh(DateTime date)
        {
            return _product.ProductionDate.Add(_product.ShelfLife) > date;
        }
        
    }
}

/*
public int Count
{
    get
    {
        return _count;
    }
    set
    {
        _count = value;
    }
}
*/