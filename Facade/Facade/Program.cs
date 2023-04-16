MarketPlace marketPlace = new MarketPlace();
marketPlace.ProductReceipt();
marketPlace.ProductRelease();


class Provider
{
    public void Receice()
    {
        Console.WriteLine("Receipt Of Products");
    }
    public void Payment()
    {
        Console.WriteLine("Payment To The Supplier");
    }
}

class Site
{
    public void Placment()
    {
        Console.WriteLine("Placement On The Site");
    }
    public void Delete()
    {
        Console.WriteLine("Removal From The Site");
    }
}

class DataBase
{
    public void Insert()
    {
        Console.WriteLine("Writing To The DataBase");
    }
    public void Delete()
    {
        Console.WriteLine("Deleting From The DataBase");
    }
}

class MarketPlace
{
    private Provider provider;
    private Site site;
    private DataBase dataBase;

    public MarketPlace()
    {
        provider = new Provider();
        site = new Site();
        dataBase = new DataBase();
    }

    public void ProductReceipt()
    {
        provider.Receice();
        site.Placment();
        dataBase.Insert();
    }

    public void ProductRelease()
    {
        provider.Payment();
        site.Delete();
        dataBase.Delete();
    }
}


