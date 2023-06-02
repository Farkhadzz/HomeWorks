//S - Принцип единственной ответственности(Single Responsibility Principle): Каждый класс должен иметь только одну причину для изменения.

class Customer
{
    private string name;
    private string email;
    public Customer(string name, string email)
    {
        this.name = name;
        this.email = email;
    }

    public string GetName()
    {
        return name;
    }

    public string GetEmail()
    {
        return email;
    }

    public void SendEmail(string message)
    {
        // Отправка электронной почты
    }
}

//O - Принцип открытости / закрытости(Open / Closed Principle): Программные сущности должны быть открыты для расширения, но закрыты для модификации.

interface IShape
{
    double CalculateArea();
}

class Circle : IShape
{
    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public double CalculateArea()
    {
        return Math.PI * radius * radius;
    }
}

class Rectangle : IShape
{
    private double width;
    private double height;

    public Rectangle(double width, double height)
    {
        this.width = width;
        this.height = height;
    }

    public double CalculateArea()
    {
        return width * height;
    }
}

//L - Принцип подстановки Лисков(Liskov Substitution Principle): Объекты должны быть заменяемыми их подтипами без нарушения корректности программы.

class Animal
{
    public virtual void MakeSound()
    {
        Console.WriteLine("Animal makes a sound.");
    }
}

class Cat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Meow!");
    }
}

class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Woof!");
    }
}

//I - Принцип разделения интерфейса(Interface Segregation Principle): Клиенты не должны зависеть от интерфейсов, которые они не используют.

interface IEmailSender
{
    void SendEmail(string recipient, string message);
}

interface ISmsSender
{
    void SendSms(string recipient, string message);
}

class NotificationService : IEmailSender, ISmsSender
{
    public void SendEmail(string recipient, string message)
    {
        // Отправка электронной почты
    }

    public void SendSms(string recipient, string message)
    {
        // Отправка SMS
    }
}

//D - Принцип инверсии зависимостей(Dependency Inversion Principle): Зависимости должны строиться на абстракциях, а не на конкретных реализациях.

interface ILogger
{
    void Log(string message);
}

class FileLogger : ILogger
{
    public void Log(string message)
    {
        // Запись лога в файл
    }
}

class DatabaseLogger : ILogger
{
    public void Log(string message)
    {
        // Запись лога в базу данных
    }