using ObserverPattern;

List<IProduct> Product = new List<IProduct>();

Product milk = new Product()
{
    Name = "milk",
    Price = 10,
};

Product IceCream = new Product()
{
    Name = "IceCream",
    Price = 5,
};

Product Cheese = new Product()
{
    Name = "Cheese",
    Price = 50
};

Product.Add(milk);
Product.Add(IceCream);
Product.Add(Cheese);

Shop AliShop = new Shop(Product, "AliShop");
Shop MohammadShop = new Shop(Product, "MohammadShop");
Shop HosseinShop = new Shop(Product, "HosseinShop");
Shop MoeinShop = new Shop(Product, "MoeinShop");




NewCustomer AliMohammad = new NewCustomer(p => p.Equals(milk))
{
    Name = "AliMohammad",
    Discription = "",
};
NewCustomer MohammadMoein = new NewCustomer(p => p.Equals(IceCream))
{
    Name = "MohammadMoein",
    Discription = "",
};
NewCustomer MohamadAli = new NewCustomer(p => p.Equals(Cheese) || p.Equals(milk))
{
    Name = "MohamadAli",
    Discription = "",
};



OldCustomer valiallah = new OldCustomer(p => p.Equals(milk))
{
    CustomerName = "valiallah",
    CustomerDiscription = "",
};

IShopObserver AdaptedOldCustomer = new OldCustomerAdapter(valiallah);

AliShop.AddDiscountWeather(AdaptedOldCustomer);


AliShop.AddDiscountWeather(AliMohammad);
AliShop.AddDiscountWeather(MohamadAli);
HosseinShop.AddDiscountWeather(MohamadAli);
MohammadShop.AddDiscountWeather(MohammadMoein);
MohammadShop.AddDiscountWeather(AliMohammad);
MoeinShop.AddDiscountWeather(AliMohammad);
MoeinShop.AddDiscountWeather(MohammadMoein);
MoeinShop.AddDiscountWeather(MohamadAli);




AliShop.SetDiscount(milk , 2);
HosseinShop.SetDiscount(IceCream , 4);
MohammadShop.SetDiscount(Cheese , 40);
MoeinShop.SetDiscount(milk, 3);
MoeinShop.SetDiscount(IceCream, 3);
