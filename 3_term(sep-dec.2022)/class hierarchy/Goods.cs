using System;

namespace LastEx
{
    abstract internal class Goods : IComparable<Goods>
    {
        string _name;
        double _price;
        
        abstract internal void PrintInfo();
        abstract internal bool IsFresh(DateTime date);

        internal Goods(string name, double price)
        {
            _name = name;
            _price = price;
        }

        // 19 практикум
        public int CompareTo(Goods other)
        {
            return _price.CompareTo(other._price);
        }
        
    }
}
