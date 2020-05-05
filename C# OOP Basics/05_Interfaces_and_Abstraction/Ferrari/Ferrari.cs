public class Ferrari : IDriveable
{
    public string Model { get; private set; }
    public string  Driver { get; private set; }

    public Ferrari(string driver)
    {
        Model = "488-Spider";
        Driver = driver;
    }

    public string UseBrakes()
    {
        return "Brakes!";
    }

    public string PushTheGas()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return $"{this.Model}/{this.UseBrakes()}/{this.PushTheGas()}/{this.Driver}";
    }
}
