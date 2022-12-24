using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern;

public class NewCustomer : ICustomer, IShopObserver
{
    private Func<IProduct, bool> _OrderConditions;

    public NewCustomer(Func<IProduct, bool> orderConditions)
    {
        _OrderConditions = orderConditions;
    }

    public string Name { get; set; }
    public string Discription { get; set; }

    public void ChangeSubject(IShop Subject, IProduct product)
    {
        bool Order = _OrderConditions(product);
        if (Order)
        {
            Subject.OrderProduct(this, product);
        }
    }

    public string GetName() => Name;
}

public class OldCustomer
{
    public string CustomerName { get; set; }
    public string CustomerDiscription { get; set; }

    public Func<Product, bool> OrderConditions { get; private set; }

    public OldCustomer(Func<Product, bool> orderConditions)
    {
        OrderConditions = orderConditions;
    }
    public void ChangeSubject(Product product)
    {
        bool Order = OrderConditions(product);
        if (Order)
        {
            Console.WriteLine("I Want To Go To The Store And Buy This Product Now");
        }
    }
    public double WaletBalance()
    {
        throw new NotImplementedException();
    }
    public List<Object> OrderList()
    {
        throw new NotImplementedException();
    }
}

public class OldCustomerAdapter : ICustomer, IShopObserver
{
    private OldCustomer _oldCustomer;
    public OldCustomerAdapter(OldCustomer oldCustomer)
    {
        _oldCustomer = oldCustomer;
    }

    public void ChangeSubject(IShop Subject, IProduct product)
    {
        if (product is Product _product)
        {
            bool Order = _oldCustomer.OrderConditions(_product);
            if (Order)
            {
                Subject.OrderProduct(this, product);
            }
        }

    }

    public string GetName() => _oldCustomer.CustomerName;
}














public interface ICustomer
{
    public string GetName();
}