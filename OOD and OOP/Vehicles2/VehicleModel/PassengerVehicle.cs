namespace VehicleModel;

public abstract class PassengerVehicle : MotorizedVehicle
{
    public PassengerVehicle(string make, string model, int year) : base(make, model, year)
    {
        
    }

    public override double Drive(double distance, RoadType roadType)
    {
        return 42.5;
    }
}