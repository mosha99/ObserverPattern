using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern;

public class Shop : IShop
{
    private List<IShopObserver> _ShopObservers = new List<IShopObserver>();
    private List<IProduct> _products = new List<IProduct>();
    public Shop(List<IProduct> products, string name)
    {
        _products = products;
        Name = name;
    }
    public string Name { get; set; }
    public string GetShopName() => Name;
    public void AddDiscountWeather(IShopObserver Observer)
    {
        _ShopObservers.Add(Observer);
    }
    public void RemoveDiscountWeather(IShopObserver Observer)
    {
        _ShopObservers.Remove(Observer);
    }
    public IList<IProduct> GetProducts()
    {
        return _products;
    }
    public void OrderProduct(ICustomer Customer, IProduct product)
    {
        Console.WriteLine($"{this.GetShopName()} : Product {product.GetName()} Order By Customer {Customer.GetName()} With Price {product.GetFinalPrice()}");
    }
    public void SetDiscount(IProduct product, double discount)
    {
        IProduct Findedproduct = _products.Single(P => P.Equals(product));
        Findedproduct.SetDiscount(discount);
        CallObserver(Findedproduct);
    }
    private void CallObserver(IProduct product)
    {
        _ShopObservers.ForEach(C =>
        {
            C.ChangeSubject(this, product);
        });
    }
    public override bool Equals(object? obj)
    {
        if (obj is IShop shop)
        {
            bool Equal = this.GetShopName() == shop.GetShopName();
            return Equal;
        }
        else
        {
            return base.Equals(obj);
        }
    }
}
