using Microsoft.EntityFrameworkCore;

void PrintProducts(List<Product> products)
{
    foreach (var product in products)
    {
        Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, CreatedAt: {product.CreatedAt}");
    }
}

Console.Write("Введите кол - во товаров :");
int count = int.Parse(Console.ReadLine());

using (var context = new AppContext())
{
    context.Database.EnsureCreated();

    Random random = new Random();
    for (int i = 0; i < count; i++)
    {
        Product product = new Product
        {
            Name = "Product " + i,
            Price = random.Next(1, 100),
            CreatedAt = DateTime.Now.AddDays(-random.Next(1, 30))
        };

        context.Products.Add(product);
    }

    context.SaveChanges();
}

using (var context = new AppContext())
{
    Console.WriteLine("Исходные данные : ");
    var products = context.Products.ToList();
    PrintProducts(products);

    Console.WriteLine("Введите минимальную цену:");
    decimal minPrice = decimal.Parse(Console.ReadLine());

    Console.WriteLine("Введите максимальную цену:");
    decimal maxPrice = decimal.Parse(Console.ReadLine());

    var filteredProducts = context.Products.Where(p => p.Price >= minPrice && p.Price <= maxPrice).ToList();
    PrintProducts(filteredProducts);

    Console.WriteLine("Сортировка данных по цене (по возрастанию):");
    var sortedProducts = context.Products.OrderBy(p => p.Price).ToList();
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class AppContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=EF #1;Trusted_Connection=True;");
    }
}