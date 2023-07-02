using Microsoft.EntityFrameworkCore;






using (var db = new ApplicationContext())
{
    var car1 = new Car { Name = "BMW" };
    var car2 = new Car { Name = "Mercedes-Benz" };

    var showroom1= new Showroom { Name = "DubaiCars", Car = car1 };
    var showroom2= new Showroom { Name = "AzeCars", Car = car2 };


    db.Cars.Add(car1);
    db.Cars.Add(car2);
    db.Showrooms.AddRange(showroom1, showroom2);

    db.SaveChanges();

    var cars = db.Cars.Include(s => s.Showrooms).ToList();

    Console.WriteLine("Cars & Showrooms : ");
    foreach (var car in cars)
    {
        Console.WriteLine($"- {car.Name}");

        foreach (var showroom in car.Showrooms)
        {
            Console.WriteLine($"  * {showroom.Name}");
        }
    }

    var countryToUpdate = db.Cars.FirstOrDefault(c => c.Name == "BMW");
    if (countryToUpdate != null)
    {
        countryToUpdate.Name = "Updated Car";
        db.SaveChanges();
    }

    var showroomDelete = db.Showrooms.FirstOrDefault(s => s.Name == "AzeCars");
    if (showroomDelete != null)
    {
        db.Showrooms.Remove(showroomDelete);
        db.SaveChanges();
    }
}



public class Car
{
    public Car() 
    {

    }
    public Car(string name, uint year, string make, int hp)
    {
        Name = name;
        Year = year;
        Make = make;
        HP = hp;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public uint Year { get; set; }
    public string Make { get; set; }
    public int HP { get; set; }
    public List<Showroom> Showrooms { get; set; }
}

public class Showroom
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CarId { get; set; }
    public Car Car { get; set; }
}

public class ApplicationContext : DbContext
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<Showroom> Showrooms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=CarsDB V1;Trusted_Connection=True;";
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>()
            .HasMany(s => s.Showrooms)
            .WithOne(car => car.Car)
            .HasForeignKey(car => car.CarId);
    }
}
