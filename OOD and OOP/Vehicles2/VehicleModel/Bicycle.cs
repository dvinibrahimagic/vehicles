namespace VehicleModel;
public class Bicycle : Vehicle // bicycle inherits directly from vehicle as it has whole set of different rules
{
    private double Speed { get; }

    public Bicycle(string licensePlate, double speed)
        : base(licensePlate, "Bicycle")
    {
        Speed = speed;
    }

    public override double CalculateTime(double distance, RoadType roadType) // roadtype not used, because different surfaces shouldn't make much difference but method doesn't function without it
    {
        return distance / Speed;
    }
}