namespace VehicleModel;

public abstract class Vehicle
{
    public string LicensePlate { get; }
    public string Type { get; }

    protected Vehicle(string licensePlate, string type)
    {
        LicensePlate = licensePlate;
        Type = type;
    }

    public abstract double CalculateTime(double distance, RoadType condition);
}
