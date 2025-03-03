namespace VehicleModel;

public class MaterialVehicle : MotorizedVehicle
{
    public MaterialVehicle(string licensePlate, EnergySource energySource,
        double baseSpeed, double baseConsumption, double fuelCapacity)
        : base(licensePlate, "Material Vehicle", energySource, baseSpeed, baseConsumption, fuelCapacity) {}
}