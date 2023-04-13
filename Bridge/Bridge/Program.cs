
Sender sender = new EmailSender(new DataBaseReader());
sender.Send();

sender = new TelegramSender(new DataBaseReader());
sender.Send();

sender = new WhatsApp(new DataBaseReader());
sender.Send();


interface IDataReader
{
    void Read();
}


class DataBaseReader : IDataReader
{
   public void Read()
    {
        Console.WriteLine("Данные из DataBase");
    }
}
class FileReader : IDataReader
{
    public void Read()
    {
        Console.WriteLine("Данные из File");
    }
}

abstract class Sender
{
    protected IDataReader reader;
    public Sender(IDataReader dr)
    {
        reader = dr;
    }
    public void SetDataReader(IDataReader dr)
    {
        reader = dr;
    }
    public abstract void Send();
}
class EmailSender : Sender
{
 public EmailSender(IDataReader dr) : base(dr) { }
 public override void Send()
    {
        reader.Read();
        Console.WriteLine("Отправлены при помощи Email");
    }
}

class TelegramSender : Sender
{
    public TelegramSender(IDataReader dr) : base(dr) { }
    public override void Send()
    {
        reader.Read();
        Console.WriteLine("Отправлены при помощи TelegramSender");
    }
}

class WhatsApp : Sender
{
    public WhatsApp(IDataReader dr) : base(dr) { }
    public override void Send()
    {
        reader.Read();
        Console.WriteLine("Отправлены при помощи WhatsAppSender");
    }
}