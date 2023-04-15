using System.Transactions;

ISpeed kmspeed = new kmSpeed(60.0f);
ISpeed mlspeed = new mlSpeed(60.0f);

Console.WriteLine(kmspeed.GetSpeed());
Console.WriteLine(mlspeed.GetSpeed());





interface ISpeed
{
    float GetSpeed();
    void AdJust();
}

class kmSpeed : ISpeed
{
    private float currentSpeed;
    public kmSpeed(float sp)
    { 
        currentSpeed = sp;
    }
    public void AdJust()
    {
        Console.WriteLine("KM Adjustment");
    }
    public float GetSpeed()
    {
        return currentSpeed;
    }
}

class mlSpeed
{
    private float currentSpeed;
    public mlSpeed(float sp)
    {
        currentSpeed = sp;
    }
    public float GetSpeed(float sp)
    {
        return currentSpeed;
    }
    protected void AdJust()
    {
        Console.WriteLine("ML Adjustment");
    }
}
class AdapterForMlSpeed : mlSpeed , ISpeed
{
    public AdapterForMlSpeed(float sp) : base(sp) { }
    float ISpeed.GetSpeed()
    {
        return base.GetSpeed(60) * 0.6f;
    }
    void ISpeed.AdJust()
    {
        base.AdJust();
        Console.WriteLine("İn The Adjust() Method");
    }
}