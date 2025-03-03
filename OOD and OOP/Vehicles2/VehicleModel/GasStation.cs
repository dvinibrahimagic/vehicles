namespace VehicleModel;
public class GasStation
{
    public string Name { get; }
    private List<EnergySource> AvailableFuelTypes { get; }

    public GasStation(string name, List<EnergySource> availableFuelTypes)
    {
        Name = name;
        AvailableFuelTypes = availableFuelTypes;
    }

    public void Refuel(MotorizedVehicle vehicle, double amount)
    {
        if (AvailableFuelTypes.Contains(vehicle.EnergySource))
        {
            vehicle.Refuel(amount);
            Console.WriteLine($"{vehicle.Type} refueled with {amount} liters at {Name}.");
        }
        else
        {
            Console.WriteLine($"Fuel type not available at {Name} for {vehicle.Type}.");
        }
    }
}