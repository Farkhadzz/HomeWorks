using System.Text;
using System.Threading.Channels;

ISite mySite = new SiteProxy(new Site());

Console.WriteLine(mySite.GetPage(1));
Console.WriteLine(mySite.GetPage(2));
Console.WriteLine(mySite.GetPage(3));

Console.WriteLine(mySite.GetPage(2));


interface ISite
{
    string GetPage(int num);
}

class Site : ISite
{
    public string GetPage(int num)
    {
        return "This Page : " + num;
    }
}

class SiteProxy : ISite
    {
        private ISite _site;
        private Dictionary<int, string> cache;
        
        public SiteProxy(ISite site)
        {
            this._site = site;
            cache = new Dictionary<int, string>();
        }
        public string GetPage(int num)
        {
            string page;
            if (cache.ContainsKey(num))
            {
                page = cache[num];
                page = "From Cache : " + page; 
            }
            else
            {
                page = _site.GetPage(num);
                cache.Add(num, page);
            }
            return page;
        }

}
