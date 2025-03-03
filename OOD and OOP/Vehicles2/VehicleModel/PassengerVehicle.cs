namespace VehicleModel;

public class PassengerVehicle : MotorizedVehicle
{
    public PassengerVehicle(string licensePlate, EnergySource energySource, 
        double baseSpeed, double baseConsumption, double fuelCapacity)
        : base(licensePlate, "Passenger Vehicle", energySource, baseSpeed, baseConsumption, fuelCapacity)
    {
    }
}