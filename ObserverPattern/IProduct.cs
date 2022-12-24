using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern;

public interface IProduct
{
    public string GetName();
    public void SetDiscount(double Discount);
    public double GetDiscount();
    public double GetFinalPrice();
    public double GetPrice();
    public void SetPrice(double price);
}
