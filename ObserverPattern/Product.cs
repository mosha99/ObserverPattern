using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern;
public class Product : IProduct
{
    private double _Discount = 0;
    public double Price { get; set; } = 0;
    public string Name { get; set; }

    public double GetDiscount()
    {
        return _Discount;
    }

    public double GetFinalPrice()
    {
        double FinalPrise = Price - _Discount;
        return FinalPrise;
    }

    public string GetName()
    {
        return Name;
    }

    public double GetPrice()
    {
        return Price;
    }

    public void SetDiscount(double Discount)
    {
        _Discount = Discount;
    }

    public void SetPrice(double price)
    {
        Price = price;
    }
    public override bool Equals(object obj)
    {
        if (obj is IProduct product)
        {
            bool Equal = this.GetName() == product.GetName();
            return Equal;
        }
        else
        {
            return base.Equals(obj);
        }
    }
}
