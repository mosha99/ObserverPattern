using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern;

public interface IShop
{
    public string GetShopName();
    public void SetDiscount(IProduct product,double discount);
    public void AddDiscountWeather(IShopObserver Observer);
    public void RemoveDiscountWeather(IShopObserver Observer);
    public IList<IProduct> GetProducts();
    public void OrderProduct(ICustomer Customer, IProduct product);
}
