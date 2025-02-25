namespace VehicleModel;

public class Greeter
{
    
    public Greeter(string name)
    {
        this.Name = name;
    }

    public string Name { get; }
    public string Greet()
    {
        return $"Hello, {this.Name}!";
    }
    
}
